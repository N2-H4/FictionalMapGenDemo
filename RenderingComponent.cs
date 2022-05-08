using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace FicMapGen
{
    //possible jobs that rendering component can do
    public enum RenJobs
    {
        SetThreshold,
        SetFrequency,
        SetOctaves,
        SetSeed,
        SetMaskThreshold,
        SetMaskFrequency,
        SetMaskOctaves,
        SetMaskSeed,
        SetMix,
        PlaceLandmass,
        AddNewLayer,
        DeleteLayer,
        LayerUp,
        LayerDown,
        PaintOn,
        SetRadius,
        SetBrushMode,
        SetDisplacement,
        SetVisibility,
        SetSubstract
    }

    //structure used to send rendering jobs to rendering thread
    public struct RenderingJob
    {
        public RenJobs job;
        public int layer;
        public float value;
        public int xcoord = 0, ycoord = 0, width = 200, height = 200;

        public RenderingJob(RenJobs job,int layer,float value)
        {
            this.job = job;
            this.layer = layer;
            this.value = value;
        }

        public void setCoords(int x,int y,int w,int h)
        {
            xcoord = x;
            ycoord = y;
            width = w;
            height = h;
        }
    }

    internal class RenderingComponent
    {
        //size of proceesed images
        private static int width,height;

        //if any changes have been made there is need to recombine layers
        private static bool changesMade = false;
        private static bool reseting = false;

        //bitmap with result of combining layers
        private static DirectBitmap bmpLive;
        //bitmap which is used for passing result from rendering thread to gui thread
        private static Bitmap bmpLast;

        //list with all layers
        private static List<Layer> layers = new List<Layer>();

        //rendering thread
        private Thread renderThread;
        //used for restarting thread after it has been stopped
        private static AutoResetEvent signal = new AutoResetEvent(false);
        //queue used for passing information between threads. Gui thread is a producer and rendering thread is a consumer
        private static ConcurrentQueue<RenderingJob> jobs = new ConcurrentQueue<RenderingJob>();

        //initialize fields, add first layer and start the rendering thread in background(it will be stopped when main thread stops)
        public RenderingComponent(int w,int h)
        {
            width = w;
            height = h;

            bmpLast = new Bitmap(width, height);
            bmpLive = new DirectBitmap(width, height);

            layers.Add(new NoiseLayer(width, height));

            renderThread = new Thread(new ThreadStart(renderView));
            renderThread.IsBackground = true;
            renderThread.Start();
        }

        //when there is a need to change resolution of the image rendering thread must be stopped and new bitmaps must be created
        public void reset(int w,int h)
        {
            reseting = true;
            width = w;
            height = h;
            bmpLast?.Dispose();
            bmpLive?.Dispose();
            bmpLast = new Bitmap(width, height);
            bmpLive = new DirectBitmap(width, height);
            foreach (Layer l in layers)
            {
                l.Dispose();
            }
            layers.Clear();
            layers.Add(new NoiseLayer(width, height));
            jobs.Clear();
            changesMade = true;

            reseting = false;
            signal.Set();
        }

        //combine layers from the list, layers on the bottom of the stack are processed first and are overwritten by on top 
        private static void combineLayers()
        {
            //for every pixel
            for(int i=0;i<bmpLive.Width;i++)
            {
                for(int j=0;j<bmpLive.Height;j++)
                {
                    bmpLive.SetPixel(i, j, Color.Black);
                    //for every layer
                    for (int k = layers.Count-1; k >=0 ; k--)
                    {
                        //process only if layer is set to visable
                        if (layers[k].Visibility)
                        {
                            //case when layer is noise layer
                            if (layers[k].getLayerType() == 0)
                            {
                                //when pixel on layer is white then we set pixel on result bitmap to white or black if layer is in substract mode
                                if (layers[k].getBitmap().GetPixel(i, j).R == 255)
                                {
                                    if((layers[k] as NoiseLayer).Substract)
                                    {
                                        bmpLive.SetPixel(i, j, Color.Black);
                                    }
                                    else
                                    {
                                        bmpLive.SetPixel(i, j, Color.White);
                                    }
                                }
                            }
                            //case when layer is paint layer
                            if (layers[k].getLayerType() == 1)
                            {
                                //pixels on paint layer are gray if neutral or white/black when we want to overwrite pixels form lower layers 
                                if (layers[k].getBitmap().GetPixel(i, j).R == 255)
                                {
                                    bmpLive.SetPixel(i, j, Color.White);
                                }
                                if (layers[k].getBitmap().GetPixel(i, j).R == 0)
                                {
                                    bmpLive.SetPixel(i, j, Color.Black);
                                }
                            }
                        }
                    }
                }
            }
        }

        //add rendering job to queue (gui thread is calling this method)
        public void addRenderingJob(RenderingJob j)
        {
            jobs.Enqueue(j);
        }

        //returns the result of rendering to gui thread
        public Bitmap getBitmap()
        {
            lock(bmpLast)
            {
                return (Bitmap)bmpLast.Clone();
            }
        }

        //rendering thread runs this method
        private static void renderView()
        {
            double maxFPS = 60;
            double minFramePeriodMsec = 1000.0 / maxFPS;
            Stopwatch stopwatch = Stopwatch.StartNew();

            combineLayers();
            changesMade = true;

            while (true)
            {
                //wait for reset to be completed
                if(reseting)
                {
                    if (signal.WaitOne()) { }
                }

                //process all jobs that are currently in queue
                while (jobs.Count>0)
                {
                    changesMade = true;
                    RenderingJob currentJob;
                    //try getting job out of the queue until succesfull
                    while (!jobs.TryDequeue(out currentJob)) { }
                    //process the job
                    switch(currentJob.job)
                    {
                        case RenJobs.PlaceLandmass:
                            (layers[currentJob.layer] as NoiseLayer)?.placeLandmassOn(currentJob.xcoord, currentJob.ycoord, currentJob.width, currentJob.height);
                            break;
                        case RenJobs.SetThreshold:
                            (layers[currentJob.layer] as NoiseLayer)?.setThreshold(currentJob.value);
                            break;
                        case RenJobs.SetFrequency:
                            (layers[currentJob.layer] as NoiseLayer)?.setFrequency(currentJob.value);
                            break;
                        case RenJobs.SetOctaves:
                            (layers[currentJob.layer] as NoiseLayer)?.setOctaves((int)currentJob.value);
                            break;
                        case RenJobs.SetSeed:
                            (layers[currentJob.layer] as NoiseLayer)?.setSeed((int)currentJob.value);
                            break;
                        case RenJobs.SetMaskThreshold:
                            (layers[currentJob.layer] as NoiseLayer)?.setMaskThreshold(currentJob.value);
                            break;
                        case RenJobs.SetMaskFrequency:
                            (layers[currentJob.layer] as NoiseLayer)?.setMaskFrequency(currentJob.value);
                            break;
                        case RenJobs.SetMaskOctaves:
                            (layers[currentJob.layer] as NoiseLayer)?.setMaskOctaves((int)currentJob.value);
                            break;
                        case RenJobs.SetMaskSeed:
                            (layers[currentJob.layer] as NoiseLayer)?.setMaskSeed((int)currentJob.value);
                            break;
                        case RenJobs.SetMix:
                            (layers[currentJob.layer] as NoiseLayer)?.setMix(currentJob.value);
                            break;
                        case RenJobs.AddNewLayer:
                            if(currentJob.value==0)
                            {
                                layers.Add(new NoiseLayer(width, height));
                            }
                            else
                            {
                                layers.Add(new PaintLayer(width, height));
                            }
                            break;
                        case RenJobs.DeleteLayer:
                            layers[currentJob.layer].Dispose();
                            layers.RemoveAt(currentJob.layer);
                            break;
                        case RenJobs.LayerUp:
                            Layer tmp = layers[currentJob.layer];
                            layers[currentJob.layer] = layers[currentJob.layer - 1];
                            layers[currentJob.layer - 1] = tmp;
                            break;
                        case RenJobs.LayerDown:
                            Layer tmp2 = layers[currentJob.layer];
                            layers[currentJob.layer] = layers[currentJob.layer + 1];
                            layers[currentJob.layer + 1] = tmp2;
                            break;
                        case RenJobs.PaintOn:
                            PaintLayer pl = layers[currentJob.layer] as PaintLayer;
                            if(pl!=null) pl.paintOn(currentJob.xcoord, currentJob.ycoord);
                            break;
                        case RenJobs.SetRadius:
                            (layers[currentJob.layer] as PaintLayer)?.setRadius((int)currentJob.value);
                            break;
                        case RenJobs.SetBrushMode:
                            (layers[currentJob.layer] as PaintLayer)?.setBrushMode((int)currentJob.value);
                            break;
                        case RenJobs.SetDisplacement:
                            (layers[currentJob.layer] as NoiseLayer)?.setDisplacement(currentJob.xcoord, currentJob.ycoord);
                            break;
                        case RenJobs.SetVisibility:
                            if(currentJob.value==0.0f)
                            {
                                layers[currentJob.layer].Visibility = false;
                            }
                            else
                            {
                                layers[currentJob.layer].Visibility = true;
                            }
                            break;
                        case RenJobs.SetSubstract:
                            if (currentJob.value == 0.0f)
                            {
                                (layers[currentJob.layer] as NoiseLayer).Substract = false;
                            }
                            else
                            {
                                (layers[currentJob.layer] as NoiseLayer).Substract = true;
                            }
                            break;

                    }
                }

                //if changes were made recombine layers and put ready bitmap in bmpLast
                if(changesMade)
                {
                    combineLayers();
                    changesMade = false;
                    lock (bmpLast)
                    {
                        bmpLast.Dispose();
                        bmpLast = (Bitmap)bmpLive.Bitmap.Clone();
                    }
                }

                //lock rendering on 60 fps
                double msToWait = minFramePeriodMsec - stopwatch.ElapsedMilliseconds;
                if (msToWait > 0)
                {
                    Thread.Sleep((int)msToWait);
                }
                stopwatch.Restart();
            }
        }
    }
}
