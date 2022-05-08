using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FicMapGen
{
    public partial class Form1 : Form
    {
        //component responsible for rendering images in separate thread
        private RenderingComponent renComp;

        //stores last mouse position
        private Point mouseLocation;
        private bool mouseIsDown = false;

        //pen for drawing lines on picturebox (marking range of brush etc.)
        private Pen dashedPen = new Pen(Color.Gray);

        //list of labels that represent layers in gui
        private List<Label> layerLabels = new List<Label>();
        //list of properties of layers
        private List<float[]> layerProps = new List<float[]>();
        //index of currently selected layer
        private int focusedLayer = 0;
        //0 means noise layer mode, 1 means paint layer mode
        private int layerMode = 0;

        public Form1()
        {
            //initialize ui elements
            InitializeComponent();

            //initialize rendering component of size (800,800)
            renComp = new RenderingComponent(800,800);

            //create pen
            dashedPen.DashCap = DashCap.Round;
            float[] dashValues = { 10, 10 };
            dashedPen.DashPattern = dashValues;

            //create one layer on start
            Label tmp = new Label();
            tmp.Text = "Noise";
            tmp.ForeColor = Color.White;
            tmp.BackColor = Color.FromArgb(30, 30, 45);
            tmp.TextAlign = ContentAlignment.MiddleLeft;
            tmp.Size = new Size(120, 40);
            tmp.Padding = new Padding(15, 0, 0, 0);
            tmp.Margin = new Padding(5, 5, 0, 0);
            tmp.Click += new System.EventHandler(layerLabel_Click);
            tmp.DoubleClick += new System.EventHandler(layerLabel_DoubleClick);

            CheckBox vis = new CheckBox() { Location = new Point(3, 10),Width=15,Checked=true };
            vis.CheckedChanged += checkBoxChanged;
            tmp.Controls.Add(vis);

            layerList.Controls.Add(tmp);
            layerLabels.Add(tmp);

            float[] tmpProps = { 0.0f, 0.002f, 0.1f, 5.0f, 0.0f, 0.01f, 0.15f, 5.0f, 1.0f, 0.25f, 0.0f, 0.0f, 0.0f };
            layerProps.Add(tmpProps);

            //start the timer
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //enable double buffering on picturebox
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //poll rendering component for new rendered image when timer ticks
            pictureBox1.Image?.Dispose();
            if(renComp!=null)
            {
                pictureBox1.Image = renComp.getBitmap();
            }
        }

        //methods for chnaging properties of layers
        private void mainScale_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetFrequency, focusedLayer, (float)mainScale.Value));
            layerProps[focusedLayer][1] = (float)mainScale.Value;
        }

        private void mainThreshold_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetThreshold, focusedLayer, (float)mainThreshold.Value));
            layerProps[focusedLayer][2] = (float)mainThreshold.Value;
        }

        private void mainOctaves_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetOctaves, focusedLayer, (float)mainOctaves.Value));
            layerProps[focusedLayer][3] = (float)mainOctaves.Value;
        }

        private void mainSeed_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetSeed, focusedLayer, (float)mainSeed.Value));
            layerProps[focusedLayer][4] = (float)mainSeed.Value;
        }

        private void maskScale_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetMaskFrequency, focusedLayer, (float)maskScale.Value));
            layerProps[focusedLayer][5] = (float)maskScale.Value;
        }

        private void maskThreshold_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetMaskThreshold, focusedLayer, (float)maskThreshold.Value));
            layerProps[focusedLayer][6] = (float)maskThreshold.Value;
        }

        private void maskOctaves_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetMaskOctaves, focusedLayer, (float)maskOctaves.Value));
            layerProps[focusedLayer][7] = (float)maskOctaves.Value;
        }

        private void maskSeed_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetMaskSeed, focusedLayer, (float)maskSeed.Value));
            layerProps[focusedLayer][8] = (float)maskSeed.Value;
        }

        private void maskMix_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetMix, focusedLayer, (float)maskMix.Value));
            layerProps[focusedLayer][9] = (float)maskMix.Value;
        }

        private void offsetX_ValueChanged(object sender, EventArgs e)
        {
            RenderingJob j = new RenderingJob(RenJobs.SetDisplacement, focusedLayer, 0);
            j.setCoords((int)offsetX.Value, (int)offsetY.Value,0,0);
            renComp.addRenderingJob(j);
            layerProps[focusedLayer][10] = (float)offsetX.Value;
        }

        private void offsetY_ValueChanged(object sender, EventArgs e)
        {
            RenderingJob j = new RenderingJob(RenJobs.SetDisplacement, focusedLayer, 0);
            j.setCoords((int)offsetX.Value, (int)offsetY.Value, 0, 0);
            renComp.addRenderingJob(j);
            layerProps[focusedLayer][11] = (float)offsetY.Value;
        }

        private void substractCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (substractCheckBox.Checked)
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetSubstract, focusedLayer, 1.0f));
                layerProps[focusedLayer][12] = 1.0f;
            }
            else
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetSubstract, focusedLayer, 0.0f));
                layerProps[focusedLayer][12] = 0.0f;
            }
        }

        //send PaintOn job when mouse button pressed down on paint layer
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (layerMode == 1)
            {
                RenderingJob j = new RenderingJob(RenJobs.PaintOn, focusedLayer, 0.0f);
                j.setCoords(e.X, e.Y, 0, 0);
                renComp.addRenderingJob(j);
            }
            mouseLocation = e.Location;
            mouseIsDown = true;
        }

        //send PaintOn job when mouse button pressed down on paint layer
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseIsDown)
            {
                RenderingJob j = new RenderingJob(RenJobs.PaintOn, focusedLayer, 0.0f);
                j.setCoords(e.X, e.Y, 0, 0);
                renComp.addRenderingJob(j);
            }
        }

        //send Place Landmass job when mouse button is relesed on noise layer
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(layerMode==0)
            {
                int left = Math.Min(mouseLocation.X, e.Location.X);
                int top = Math.Min(mouseLocation.Y, e.Location.Y);
                int w = Math.Max(mouseLocation.X, e.Location.X)-left;
                int h = Math.Max(mouseLocation.Y, e.Location.Y)-top;
                RenderingJob j = new RenderingJob(RenJobs.PlaceLandmass, focusedLayer, 0.0f);
                j.setCoords(left, top, w, h);
                renComp.addRenderingJob(j);
            }
            mouseIsDown = false;
        }

        //draw dashed lines on picturebox when selecting area on noise layer on painting on paint layer
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mouseIsDown && layerMode==0)
            {
                Point mouseCurrent = pictureBox1.PointToClient(Control.MousePosition);
                e.Graphics.DrawLine(dashedPen, mouseLocation, new Point(mouseLocation.X, mouseCurrent.Y));
                e.Graphics.DrawLine(dashedPen, mouseLocation, new Point(mouseCurrent.X, mouseLocation.Y));
                e.Graphics.DrawLine(dashedPen, mouseCurrent, new Point(mouseCurrent.X, mouseLocation.Y));
                e.Graphics.DrawLine(dashedPen, mouseCurrent, new Point(mouseLocation.X, mouseCurrent.Y));
            }
            if(layerMode==1)
            {
                Point mouseCurrent = pictureBox1.PointToClient(Control.MousePosition);
                e.Graphics.DrawEllipse(dashedPen, mouseCurrent.X - layerProps[focusedLayer][1], mouseCurrent.Y - layerProps[focusedLayer][1], 2* layerProps[focusedLayer][1], 2* layerProps[focusedLayer][1]);
            }
        }

        //add new noise layer when button is clicked
        private void addNoiseLayerButton_Click(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.AddNewLayer, 0, 0.0f));

            Label tmp = new Label();
            tmp.Text = "Noise";
            tmp.ForeColor = Color.White;
            tmp.BackColor = Color.FromArgb(30, 30, 45);
            tmp.TextAlign = ContentAlignment.MiddleLeft;
            tmp.Size = new Size(120, 40);
            tmp.Padding = new Padding(15, 0, 0, 0);
            tmp.Margin = new Padding(5, 5, 0, 0);
            tmp.Click += new System.EventHandler(layerLabel_Click);
            tmp.DoubleClick += new System.EventHandler(layerLabel_DoubleClick);

            CheckBox vis = new CheckBox() { Location = new Point(3, 10), Width = 15, Checked = true };
            vis.CheckedChanged += checkBoxChanged;
            tmp.Controls.Add(vis);

            layerList.Controls.Add(tmp);
            layerLabels.Add(tmp);

            float[] tmpProps = { 0.0f, 0.002f, 0.1f, 5.0f, 0.0f, 0.01f, 0.15f, 5.0f, 1.0f, 0.25f, 0.0f, 0.0f, 0.0f };
            layerProps.Add(tmpProps);
        }

        //add new paint layer when button is clicked
        private void addPaintLayerButton_Click(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.AddNewLayer, 0, 1.0f));

            Label tmp = new Label();
            tmp.Text = "Paint";
            tmp.ForeColor = Color.White;
            tmp.BackColor = Color.FromArgb(30, 30, 45);
            tmp.TextAlign = ContentAlignment.MiddleLeft;
            tmp.Size = new Size(120, 40);
            tmp.Padding = new Padding(15, 0, 0, 0);
            tmp.Margin = new Padding(5, 5, 0, 0);
            tmp.Click += new System.EventHandler(layerLabel_Click);
            tmp.DoubleClick += new System.EventHandler(layerLabel_DoubleClick);

            CheckBox vis = new CheckBox() { Location = new Point(3, 10), Width = 15, Checked = true };
            vis.CheckedChanged += checkBoxChanged;
            tmp.Controls.Add(vis);

            layerList.Controls.Add(tmp);
            layerLabels.Add(tmp);

            float[] tmpProps = { 1.0f, 15.0f, 0.0f };
            layerProps.Add(tmpProps);
        }

        //chnage selected layer when label is clicked and properties displayed on gui
        private void layerLabel_Click(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;
            layerLabels[focusedLayer].BackColor = Color.FromArgb(30, 30, 45);
            focusedLayer =layerLabels.IndexOf(tmp);
            tmp.BackColor = Color.FromArgb(45, 45, 65);

            if(layerProps[focusedLayer][0]==0.0f)
            {
                layerMode = 0;

                panel1.Visible = true;
                panel2.Visible = true;
                brushPanel.Visible = false;

                mainScale.Value = (decimal)layerProps[focusedLayer][1];
                mainThreshold.Value = (decimal)layerProps[focusedLayer][2];
                mainOctaves.Value = (decimal)layerProps[focusedLayer][3];
                mainSeed.Value = (decimal)layerProps[focusedLayer][4];
                maskScale.Value = (decimal)layerProps[focusedLayer][5];
                maskThreshold.Value = (decimal)layerProps[focusedLayer][6];
                maskOctaves.Value = (decimal)layerProps[focusedLayer][7];
                maskSeed.Value = (decimal)layerProps[focusedLayer][8];
                maskMix.Value = (decimal)layerProps[focusedLayer][9];
                offsetX.Value = (decimal)layerProps[focusedLayer][10];
                offsetY.Value = (decimal)layerProps[focusedLayer][11];
                if (layerProps[focusedLayer][12] == 0.0f) substractCheckBox.Checked = false;
                else substractCheckBox.Checked = true;

            }
            if(layerProps[focusedLayer][0]==1.0f)
            {
                layerMode = 1;

                panel1.Visible = false;
                panel2.Visible = false;
                brushPanel.Visible = true;

                brushSize.Value = (decimal)layerProps[focusedLayer][1];
                if (layerProps[focusedLayer][2] == 0.0f) radioAdd.Checked = true;
                else radioDelete.Checked = true;
            }

        }

        //add textbox for renaming layer when label is double clicked
        private void layerLabel_DoubleClick(object sender,EventArgs e)
        {
            Label tmp = (Label)sender;
            if (tmp.Controls.Count > 1) return;
            int indexOf = layerLabels.IndexOf(tmp);
            TextBox txt = new TextBox();
            txt.Location = new Point(17, 8);
            txt.BackColor = Color.FromArgb(16, 16, 24);
            txt.ForeColor = Color.White;
            txt.Text = tmp.Text;
            txt.LostFocus += new System.EventHandler(changeNameLostFocus);
            tmp.Controls.Add(txt);
            tmp.Controls.SetChildIndex(txt, 0);
            txt.Select();
        }

        //rename layer when renaming textbox loses focus
        private void changeNameLostFocus(object sender,EventArgs e)
        {
            TextBox tmp = (TextBox)sender;
            Label l = (Label)tmp.Parent;
            if(tmp.Text!="")
            {
                l.Text = tmp.Text;
            }
            else
            {
                l.Text = "Layer";
            }
            tmp.Dispose();
        }

        //change focus to form when it it clicked in order to validate renaming textbox
        private void Form1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        //change focus to layerlist when it it clicked in order to validate renaming textbox
        private void layerList_Click(object sender, EventArgs e)
        {
            layerList.Focus();
        }

        //change focus to panel1 when it it clicked in order to validate renaming textbox
        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        //change focus to panel1 when it it clicked in order to validate renaming textbox
        private void panel2_Click(object sender, EventArgs e)
        {
            panel2.Focus();
        }

        //delete focused layer and change focus to diffrent layer
        private void deleteLayerButton_Click(object sender, EventArgs e)
        {
            layerLabels[focusedLayer].Dispose();
            layerLabels.RemoveAt(focusedLayer);
            layerProps.RemoveAt(focusedLayer);
            renComp.addRenderingJob(new RenderingJob(RenJobs.DeleteLayer, focusedLayer, 0));
            focusedLayer--;
            if (focusedLayer < 0) focusedLayer = 0;
            if (layerLabels.Count == 0) return;
            layerLabels[focusedLayer].BackColor = Color.FromArgb(45, 45, 65);

            if(layerProps[focusedLayer][0]==0.0f)
            {
                layerMode = 0;

                panel1.Visible = true;
                panel2.Visible = true;
                brushPanel.Visible = false;

                mainScale.Value = (decimal)layerProps[focusedLayer][1];
                mainThreshold.Value = (decimal)layerProps[focusedLayer][2];
                mainOctaves.Value = (decimal)layerProps[focusedLayer][3];
                mainSeed.Value = (decimal)layerProps[focusedLayer][4];
                maskScale.Value = (decimal)layerProps[focusedLayer][5];
                maskThreshold.Value = (decimal)layerProps[focusedLayer][6];
                maskOctaves.Value = (decimal)layerProps[focusedLayer][7];
                maskSeed.Value = (decimal)layerProps[focusedLayer][8];
                maskMix.Value = (decimal)layerProps[focusedLayer][9];
                offsetX.Value = (decimal)layerProps[focusedLayer][10];
                offsetY.Value = (decimal)layerProps[focusedLayer][11];
                if (layerProps[focusedLayer][12] == 0.0f) substractCheckBox.Checked = false;
                else substractCheckBox.Checked = true;
            }
            if(layerProps[focusedLayer][0]==1.0f)
            {
                layerMode = 1;

                panel1.Visible = false;
                panel2.Visible = false;
                brushPanel.Visible = true;

                brushSize.Value = (decimal)layerProps[focusedLayer][1];
                if (layerProps[focusedLayer][2] == 0.0f) radioAdd.Checked = true;
                else radioDelete.Checked = true;

            }
        }

        //swap layers when layer up button is clicked
        private void layerUp_Click(object sender, EventArgs e)
        {
            if (focusedLayer == 0) return;
            renComp.addRenderingJob(new RenderingJob(RenJobs.LayerUp, focusedLayer, 0));
            layerList.Controls.SetChildIndex(layerLabels[focusedLayer], focusedLayer-1);

            Label tmp = layerLabels[focusedLayer];
            layerLabels[focusedLayer] = layerLabels[focusedLayer - 1];
            layerLabels[focusedLayer - 1] = tmp;

            float[] tmp2 = layerProps[focusedLayer];
            layerProps[focusedLayer] = layerProps[focusedLayer - 1];
            layerProps[focusedLayer - 1] = tmp2;

            focusedLayer--;
        }

        //swap layers when layer down is clicked
        private void layerDown_Click(object sender, EventArgs e)
        {
            if (focusedLayer == layerLabels.Count-1) return;
            renComp.addRenderingJob(new RenderingJob(RenJobs.LayerDown, focusedLayer, 0));
            layerList.Controls.SetChildIndex(layerLabels[focusedLayer], focusedLayer + 1);

            Label tmp = layerLabels[focusedLayer];
            layerLabels[focusedLayer] = layerLabels[focusedLayer + 1];
            layerLabels[focusedLayer + 1] = tmp;

            float[] tmp2 = layerProps[focusedLayer];
            layerProps[focusedLayer] = layerProps[focusedLayer + 1];
            layerProps[focusedLayer + 1] = tmp2;

            focusedLayer++;
        }

        //change brush size on layer
        private void brushSize_ValueChanged(object sender, EventArgs e)
        {
            renComp.addRenderingJob(new RenderingJob(RenJobs.SetRadius, focusedLayer, (float)brushSize.Value));
            layerProps[focusedLayer][1] = (float)brushSize.Value;
        }

        //change brush mode on paint layer
        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            if(radioAdd.Checked)
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetBrushMode, focusedLayer, 0.0f));
                layerProps[focusedLayer][2] = 0.0f;
            }
            else
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetBrushMode, focusedLayer, 1.0f));
                layerProps[focusedLayer][2] = 1.0f;
            }
        }

        //open save file dialog when menu button os clicked
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Png Image|*.png|Bitmap Image|*.bmp|Jpg Image|*.jpg";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                
                if(saveFileDialog1.FilterIndex == 1)
                {
                    pictureBox1.Image.Save(fs, ImageFormat.Png);
                }
                if(saveFileDialog1.FilterIndex == 2)
                {
                    pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                }
                if(saveFileDialog1.FilterIndex == 3)
                {
                    pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                }

                fs.Close();
            }
        }

        //open new map dialog when menu button is clicked
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make new map
            Size res = NewSizeDialog.showDialog();
            if(res.Width!=-1)
            {
                pictureBox1.Width = res.Width;
                pictureBox1.Height = res.Height;
                renComp.reset(res.Width, res.Height);
                foreach(Label l in layerLabels)
                {
                    l.Dispose();
                }
                layerLabels.Clear();
                layerProps.Clear();

                //add first layer
                Label tmp = new Label();
                tmp.Text = "Noise";
                tmp.ForeColor = Color.White;
                tmp.BackColor = Color.FromArgb(30, 30, 45);
                tmp.TextAlign = ContentAlignment.MiddleLeft;
                tmp.Size = new Size(120, 40);
                tmp.Padding = new Padding(15, 0, 0, 0);
                tmp.Margin = new Padding(5, 5, 0, 0);
                tmp.Click += new System.EventHandler(layerLabel_Click);
                tmp.DoubleClick += new System.EventHandler(layerLabel_DoubleClick);

                CheckBox vis = new CheckBox() { Location = new Point(3, 10), Width = 15, Checked = true };
                vis.CheckedChanged += checkBoxChanged;
                tmp.Controls.Add(vis);

                layerList.Controls.Add(tmp);
                layerLabels.Add(tmp);

                float[] tmpProps = { 0.0f, 0.002f, 0.1f, 5.0f, 0.0f, 0.01f, 0.15f, 5.0f, 1.0f, 0.25f, 0.0f, 0.0f, 0.0f };
                layerProps.Add(tmpProps);

                focusedLayer = 0;
                layerMode = 0;
            }
        }

        //change layer visibility when checkbox clicked
        private void checkBoxChanged(object sender, EventArgs e)
        {
            CheckBox tmp = sender as CheckBox;
            if(tmp.Checked)
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetVisibility, layerLabels.IndexOf(tmp.Parent as Label), 1.0f));
            }
            else
            {
                renComp.addRenderingJob(new RenderingJob(RenJobs.SetVisibility, layerLabels.IndexOf(tmp.Parent as Label), 0.0f));
            }
        }

        //show help dialog when menu button is clicked
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog.showDialog();
        }
    }
}