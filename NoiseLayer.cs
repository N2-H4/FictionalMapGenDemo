using System.Drawing.Drawing2D;

namespace FicMapGen
{
    internal class NoiseLayer : Layer
    {
        private bool substract = false;

        private float threshold = 0.1f;
        private float frequency = 0.002f;
        private int octaves = 5;
        private int seed = 0;

        private float maskThreshold = 0.15f;
        private float maskFrequency = 0.01f;
        private int maskOctaves = 5;
        private int maskSeed = 1;
        private float maskMix = 0.25f;

        private float displacementX = 0.0f;
        private float displacementY = 0.0f;

        //objects which generate noise
        private FastNoiseLite noise;
        private FastNoiseLite maskNoise;

        //array for storing noise values
        private float[,] noiseTable;
        private float[,] maskNoiseTable;

        private DirectBitmap mask;
        private DirectBitmap ellipticMask;

        private int landmassX = 0, landmassY = 0, landmassWidth = 100, landmassHeight = 100;

        public NoiseLayer(int w,int h) : base(w,h,0)
        {
            noise = new FastNoiseLite();
            maskNoise = new FastNoiseLite();
            noiseTable = new float[width, height];
            maskNoiseTable = new float[width, height];
            mask = new DirectBitmap(width, height);
            ellipticMask = new DirectBitmap(width, height);
            initNoise();
        }

        public bool Substract { get => substract; set => substract = value; }

        public void setThreshold(float t)
        {
            threshold = t;
            renderMaskedRegion();
        }

        public void setOctaves(int o)
        {
            octaves = o;
            noise.SetFractalOctaves(octaves);
            resampleNoise();
            renderMaskedRegion();
        }

        public void setFrequency(float f)
        {
            frequency = f;
            noise.SetFrequency(frequency);
            resampleNoise();
            renderMaskedRegion();
        }

        public void setSeed(int s)
        {
            seed = s;
            noise.SetSeed(seed);
            resampleNoise();
            renderMaskedRegion();
        }

        public void setMaskThreshold(float t)
        {
            maskThreshold = t;
            mixMasks();
            renderMaskedRegion();
        }

        public void setMaskOctaves(int o)
        {
            maskOctaves = o;
            maskNoise.SetFractalOctaves(maskOctaves);
            resampleMaskNoise();
            mixMasks();
            renderMaskedRegion();
        }

        public void setMaskFrequency(float f)
        {
            maskFrequency = f;
            maskNoise.SetFrequency(maskFrequency);
            resampleMaskNoise();
            mixMasks();
            renderMaskedRegion();
        }

        public void setMaskSeed(int s)
        {
            maskSeed = s;
            maskNoise.SetSeed(maskSeed);
            resampleMaskNoise();
            mixMasks();
            renderMaskedRegion();
        }

        public void setMix(float m)
        {
            maskMix = m;
            mixMasks();
            renderMaskedRegion();
        }

        public void setDisplacement(float x,float y)
        {
            displacementX = x;
            displacementY = y;
            resampleNoise();
            renderMaskedRegion();
        }

        public void placeLandmassOn(int x, int y, int width, int height)
        {
            landmassX = x;
            landmassY = y;
            landmassWidth = width;
            landmassHeight = height;
            genEllipseMask(landmassX, landmassY, landmassWidth, landmassHeight);
            mixMasks();
            renderMaskedRegion();
        }

        private void initNoise()
        {
            noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
            noise.SetSeed(seed);
            noise.SetFrequency(frequency);
            noise.SetFractalType(FastNoiseLite.FractalType.FBm);
            noise.SetFractalOctaves(octaves);
            noise.SetFractalLacunarity(2.0f);
            noise.SetFractalGain(0.5f);

            maskNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
            maskNoise.SetSeed(maskSeed);
            maskNoise.SetFrequency(maskFrequency);
            maskNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
            maskNoise.SetFractalOctaves(maskOctaves);
            maskNoise.SetFractalLacunarity(2.0f);
            maskNoise.SetFractalGain(0.5f);

            for (int i = 0; i < noiseTable.GetLength(0); i++)
            {
                for (int j = 0; j < noiseTable.GetLength(1); j++)
                {
                    noiseTable[i, j] = noise.GetNoise((i / 2.0f)+displacementX, (j / 2.0f)+displacementY);
                    maskNoiseTable[i, j] = maskNoise.GetNoise(i / 2.0f, j / 2.0f);
                }
            }
        }

        //fill noise array with values
        private void resampleNoise()
        {
            for (int i = 0; i < noiseTable.GetLength(0); i++)
            {
                for (int j = 0; j < noiseTable.GetLength(1); j++)
                {
                    noiseTable[i, j] = noise.GetNoise((i / 2.0f)+displacementX, (j / 2.0f)+displacementY);
                }
            }
        }

        //fill mask noise with values
        private void resampleMaskNoise()
        {
            for (int i = 0; i < maskNoiseTable.GetLength(0); i++)
            {
                for (int j = 0; j < maskNoiseTable.GetLength(1); j++)
                {
                    maskNoiseTable[i, j] = maskNoise.GetNoise(i / 2.0f, j / 2.0f);
                }
            }
        }

        //draw elliptical gradient in given location
        private void genEllipseMask(int x, int y, int width, int height)
        {
            Graphics g = Graphics.FromImage(ellipticMask.Bitmap);

            GraphicsPath path = new GraphicsPath();
            if (width <= 0) width = 1;
            if (height <= 0) height = 1;
            path.AddEllipse(x, y, width, height);

            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.FromArgb(255, 255, 255);
            Color[] colors = { Color.FromArgb(0, 0, 0) };
            brush.SurroundColors = colors;
            brush.FocusScales = new PointF(0.3f, 0.3f);

            g.Clear(Color.Black);
            g.FillEllipse(brush, x, y, width, height);
            brush.Dispose();
            g.Dispose();
            path.Dispose();
        }

        //mix elliptical gradient and mask noise
        private void mixMasks()
        {
            for (int i = 0; i < maskNoiseTable.GetLength(0); i++)
            {
                for (int j = 0; j < maskNoiseTable.GetLength(1); j++)
                {
                    float value = (maskMix * maskNoiseTable[i, j] + (1 - maskMix) * (ellipticMask.GetPixel(i, j).R / 255.0f)) / 2;
                    if (value > maskThreshold) mask.SetPixel(i, j, Color.White);
                    else mask.SetPixel(i, j, Color.Black);
                }
            }
        }

        //apply mask to noise
        private void renderMaskedRegion()
        {
            for (int i = 0; i < noiseTable.GetLength(0); i++)
            {
                for (int j = 0; j < noiseTable.GetLength(1); j++)
                {
                    content.SetPixel(i, j, Color.Black);
                    if (mask.GetPixel(i, j).R == 255 && noiseTable[i, j] > threshold) content.SetPixel(i, j, Color.White);
                }
            }
        }

        public override void Dispose()
        {
            content.Dispose();
            mask.Dispose();
            ellipticMask.Dispose();
        }

    }
}
