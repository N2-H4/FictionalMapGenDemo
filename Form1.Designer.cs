namespace FicMapGen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.substractCheckBox = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.offsetY = new System.Windows.Forms.NumericUpDown();
            this.offsetX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.mainSeed = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainOctaves = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mainThreshold = new System.Windows.Forms.NumericUpDown();
            this.mainScaleLabel = new System.Windows.Forms.Label();
            this.mainScale = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.maskSeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.maskMix = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskOctaves = new System.Windows.Forms.NumericUpDown();
            this.maskScale = new System.Windows.Forms.NumericUpDown();
            this.maskThreshold = new System.Windows.Forms.NumericUpDown();
            this.layerList = new System.Windows.Forms.FlowLayoutPanel();
            this.addNoiseLayerButton = new System.Windows.Forms.Button();
            this.deleteLayerButton = new System.Windows.Forms.Button();
            this.layerUp = new System.Windows.Forms.Button();
            this.layerDown = new System.Windows.Forms.Button();
            this.addPaintLayerButton = new System.Windows.Forms.Button();
            this.brushPanel = new System.Windows.Forms.Panel();
            this.brushModeBox = new System.Windows.Forms.GroupBox();
            this.radioDelete = new System.Windows.Forms.RadioButton();
            this.radioAdd = new System.Windows.Forms.RadioButton();
            this.brushSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainScale)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskMix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskThreshold)).BeginInit();
            this.brushPanel.SuspendLayout();
            this.brushModeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(507, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.panel1.Controls.Add(this.substractCheckBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.offsetY);
            this.panel1.Controls.Add(this.offsetX);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.mainSeed);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mainOctaves);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mainThreshold);
            this.panel1.Controls.Add(this.mainScaleLabel);
            this.panel1.Controls.Add(this.mainScale);
            this.panel1.Location = new System.Drawing.Point(12, 436);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 245);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // substractCheckBox
            // 
            this.substractCheckBox.AutoSize = true;
            this.substractCheckBox.ForeColor = System.Drawing.SystemColors.Info;
            this.substractCheckBox.Location = new System.Drawing.Point(68, 211);
            this.substractCheckBox.Name = "substractCheckBox";
            this.substractCheckBox.Size = new System.Drawing.Size(15, 14);
            this.substractCheckBox.TabIndex = 11;
            this.substractCheckBox.UseVisualStyleBackColor = true;
            this.substractCheckBox.CheckedChanged += new System.EventHandler(this.substractCheckBox_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.Info;
            this.label15.Location = new System.Drawing.Point(3, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 10;
            this.label15.Text = "Invert";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.Info;
            this.label14.Location = new System.Drawing.Point(3, 184);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Offset Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Info;
            this.label13.Location = new System.Drawing.Point(3, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Offset X";
            // 
            // offsetY
            // 
            this.offsetY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.offsetY.ForeColor = System.Drawing.SystemColors.Info;
            this.offsetY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.offsetY.Location = new System.Drawing.Point(68, 182);
            this.offsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.offsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.offsetY.Name = "offsetY";
            this.offsetY.Size = new System.Drawing.Size(63, 23);
            this.offsetY.TabIndex = 7;
            this.offsetY.ValueChanged += new System.EventHandler(this.offsetY_ValueChanged);
            // 
            // offsetX
            // 
            this.offsetX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.offsetX.ForeColor = System.Drawing.SystemColors.Info;
            this.offsetX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.offsetX.Location = new System.Drawing.Point(68, 153);
            this.offsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.offsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.offsetX.Name = "offsetX";
            this.offsetX.Size = new System.Drawing.Size(63, 23);
            this.offsetX.TabIndex = 6;
            this.offsetX.ValueChanged += new System.EventHandler(this.offsetX_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(3, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Seed";
            // 
            // mainSeed
            // 
            this.mainSeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.mainSeed.ForeColor = System.Drawing.SystemColors.Info;
            this.mainSeed.Location = new System.Drawing.Point(68, 124);
            this.mainSeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mainSeed.Name = "mainSeed";
            this.mainSeed.Size = new System.Drawing.Size(63, 23);
            this.mainSeed.TabIndex = 3;
            this.mainSeed.ValueChanged += new System.EventHandler(this.mainSeed_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Noise Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(3, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detail";
            // 
            // mainOctaves
            // 
            this.mainOctaves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.mainOctaves.ForeColor = System.Drawing.SystemColors.Info;
            this.mainOctaves.Location = new System.Drawing.Point(68, 95);
            this.mainOctaves.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mainOctaves.Name = "mainOctaves";
            this.mainOctaves.Size = new System.Drawing.Size(63, 23);
            this.mainOctaves.TabIndex = 4;
            this.mainOctaves.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mainOctaves.ValueChanged += new System.EventHandler(this.mainOctaves_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Threshold";
            // 
            // mainThreshold
            // 
            this.mainThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.mainThreshold.DecimalPlaces = 2;
            this.mainThreshold.ForeColor = System.Drawing.SystemColors.Info;
            this.mainThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mainThreshold.Location = new System.Drawing.Point(68, 66);
            this.mainThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mainThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.mainThreshold.Name = "mainThreshold";
            this.mainThreshold.Size = new System.Drawing.Size(63, 23);
            this.mainThreshold.TabIndex = 2;
            this.mainThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.mainThreshold.ValueChanged += new System.EventHandler(this.mainThreshold_ValueChanged);
            // 
            // mainScaleLabel
            // 
            this.mainScaleLabel.AutoSize = true;
            this.mainScaleLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.mainScaleLabel.Location = new System.Drawing.Point(3, 39);
            this.mainScaleLabel.Name = "mainScaleLabel";
            this.mainScaleLabel.Size = new System.Drawing.Size(34, 15);
            this.mainScaleLabel.TabIndex = 1;
            this.mainScaleLabel.Text = "Scale";
            // 
            // mainScale
            // 
            this.mainScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.mainScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainScale.DecimalPlaces = 3;
            this.mainScale.ForeColor = System.Drawing.SystemColors.Info;
            this.mainScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.mainScale.Location = new System.Drawing.Point(68, 37);
            this.mainScale.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mainScale.Name = "mainScale";
            this.mainScale.Size = new System.Drawing.Size(63, 23);
            this.mainScale.TabIndex = 0;
            this.mainScale.Value = new decimal(new int[] {
            2,
            0,
            0,
            196608});
            this.mainScale.ValueChanged += new System.EventHandler(this.mainScale_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.maskSeed);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.maskMix);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.maskOctaves);
            this.panel2.Controls.Add(this.maskScale);
            this.panel2.Controls.Add(this.maskThreshold);
            this.panel2.Location = new System.Drawing.Point(198, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 245);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(3, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Seed";
            // 
            // maskSeed
            // 
            this.maskSeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.maskSeed.ForeColor = System.Drawing.SystemColors.Info;
            this.maskSeed.Location = new System.Drawing.Point(68, 124);
            this.maskSeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maskSeed.Name = "maskSeed";
            this.maskSeed.Size = new System.Drawing.Size(63, 23);
            this.maskSeed.TabIndex = 3;
            this.maskSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maskSeed.ValueChanged += new System.EventHandler(this.maskSeed_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Mask Properties";
            // 
            // maskMix
            // 
            this.maskMix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.maskMix.DecimalPlaces = 2;
            this.maskMix.ForeColor = System.Drawing.SystemColors.Info;
            this.maskMix.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.maskMix.Location = new System.Drawing.Point(68, 154);
            this.maskMix.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maskMix.Name = "maskMix";
            this.maskMix.Size = new System.Drawing.Size(63, 23);
            this.maskMix.TabIndex = 9;
            this.maskMix.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.maskMix.ValueChanged += new System.EventHandler(this.maskMix_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mix";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(3, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Detail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scale";
            // 
            // maskOctaves
            // 
            this.maskOctaves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.maskOctaves.ForeColor = System.Drawing.SystemColors.Info;
            this.maskOctaves.Location = new System.Drawing.Point(68, 95);
            this.maskOctaves.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.maskOctaves.Name = "maskOctaves";
            this.maskOctaves.Size = new System.Drawing.Size(63, 23);
            this.maskOctaves.TabIndex = 3;
            this.maskOctaves.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maskOctaves.ValueChanged += new System.EventHandler(this.maskOctaves_ValueChanged);
            // 
            // maskScale
            // 
            this.maskScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.maskScale.DecimalPlaces = 3;
            this.maskScale.ForeColor = System.Drawing.SystemColors.Info;
            this.maskScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.maskScale.Location = new System.Drawing.Point(68, 37);
            this.maskScale.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.maskScale.Name = "maskScale";
            this.maskScale.Size = new System.Drawing.Size(63, 23);
            this.maskScale.TabIndex = 3;
            this.maskScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.maskScale.ValueChanged += new System.EventHandler(this.maskScale_ValueChanged);
            // 
            // maskThreshold
            // 
            this.maskThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.maskThreshold.DecimalPlaces = 2;
            this.maskThreshold.ForeColor = System.Drawing.SystemColors.Info;
            this.maskThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.maskThreshold.Location = new System.Drawing.Point(68, 66);
            this.maskThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maskThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.maskThreshold.Name = "maskThreshold";
            this.maskThreshold.Size = new System.Drawing.Size(63, 23);
            this.maskThreshold.TabIndex = 3;
            this.maskThreshold.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            this.maskThreshold.ValueChanged += new System.EventHandler(this.maskThreshold_ValueChanged);
            // 
            // layerList
            // 
            this.layerList.AutoScroll = true;
            this.layerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.layerList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layerList.Location = new System.Drawing.Point(12, 36);
            this.layerList.Name = "layerList";
            this.layerList.Size = new System.Drawing.Size(145, 382);
            this.layerList.TabIndex = 3;
            this.layerList.WrapContents = false;
            this.layerList.Click += new System.EventHandler(this.layerList_Click);
            // 
            // addNoiseLayerButton
            // 
            this.addNoiseLayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addNoiseLayerButton.Location = new System.Drawing.Point(163, 42);
            this.addNoiseLayerButton.Name = "addNoiseLayerButton";
            this.addNoiseLayerButton.Size = new System.Drawing.Size(106, 23);
            this.addNoiseLayerButton.TabIndex = 4;
            this.addNoiseLayerButton.Text = "Add Noise Layer";
            this.addNoiseLayerButton.UseVisualStyleBackColor = true;
            this.addNoiseLayerButton.Click += new System.EventHandler(this.addNoiseLayerButton_Click);
            // 
            // deleteLayerButton
            // 
            this.deleteLayerButton.Location = new System.Drawing.Point(163, 100);
            this.deleteLayerButton.Name = "deleteLayerButton";
            this.deleteLayerButton.Size = new System.Drawing.Size(49, 23);
            this.deleteLayerButton.TabIndex = 5;
            this.deleteLayerButton.Text = "Delete";
            this.deleteLayerButton.UseVisualStyleBackColor = true;
            this.deleteLayerButton.Click += new System.EventHandler(this.deleteLayerButton_Click);
            // 
            // layerUp
            // 
            this.layerUp.Location = new System.Drawing.Point(218, 100);
            this.layerUp.Name = "layerUp";
            this.layerUp.Size = new System.Drawing.Size(23, 23);
            this.layerUp.TabIndex = 6;
            this.layerUp.Text = "^";
            this.layerUp.UseVisualStyleBackColor = true;
            this.layerUp.Click += new System.EventHandler(this.layerUp_Click);
            // 
            // layerDown
            // 
            this.layerDown.Location = new System.Drawing.Point(246, 100);
            this.layerDown.Name = "layerDown";
            this.layerDown.Size = new System.Drawing.Size(23, 23);
            this.layerDown.TabIndex = 7;
            this.layerDown.Text = "v";
            this.layerDown.UseVisualStyleBackColor = true;
            this.layerDown.Click += new System.EventHandler(this.layerDown_Click);
            // 
            // addPaintLayerButton
            // 
            this.addPaintLayerButton.Location = new System.Drawing.Point(163, 71);
            this.addPaintLayerButton.Name = "addPaintLayerButton";
            this.addPaintLayerButton.Size = new System.Drawing.Size(106, 23);
            this.addPaintLayerButton.TabIndex = 8;
            this.addPaintLayerButton.Text = "Add Paint Layer";
            this.addPaintLayerButton.UseVisualStyleBackColor = true;
            this.addPaintLayerButton.Click += new System.EventHandler(this.addPaintLayerButton_Click);
            // 
            // brushPanel
            // 
            this.brushPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.brushPanel.Controls.Add(this.brushModeBox);
            this.brushPanel.Controls.Add(this.brushSize);
            this.brushPanel.Controls.Add(this.label12);
            this.brushPanel.Controls.Add(this.label11);
            this.brushPanel.Location = new System.Drawing.Point(12, 436);
            this.brushPanel.Name = "brushPanel";
            this.brushPanel.Size = new System.Drawing.Size(180, 245);
            this.brushPanel.TabIndex = 9;
            this.brushPanel.Visible = false;
            // 
            // brushModeBox
            // 
            this.brushModeBox.Controls.Add(this.radioDelete);
            this.brushModeBox.Controls.Add(this.radioAdd);
            this.brushModeBox.ForeColor = System.Drawing.SystemColors.Info;
            this.brushModeBox.Location = new System.Drawing.Point(3, 77);
            this.brushModeBox.Name = "brushModeBox";
            this.brushModeBox.Size = new System.Drawing.Size(174, 54);
            this.brushModeBox.TabIndex = 3;
            this.brushModeBox.TabStop = false;
            this.brushModeBox.Text = "Brush Mode";
            // 
            // radioDelete
            // 
            this.radioDelete.AutoSize = true;
            this.radioDelete.Location = new System.Drawing.Point(95, 22);
            this.radioDelete.Name = "radioDelete";
            this.radioDelete.Size = new System.Drawing.Size(58, 19);
            this.radioDelete.TabIndex = 2;
            this.radioDelete.TabStop = true;
            this.radioDelete.Text = "Delete";
            this.radioDelete.UseVisualStyleBackColor = true;
            // 
            // radioAdd
            // 
            this.radioAdd.AutoSize = true;
            this.radioAdd.Checked = true;
            this.radioAdd.Location = new System.Drawing.Point(21, 22);
            this.radioAdd.Name = "radioAdd";
            this.radioAdd.Size = new System.Drawing.Size(47, 19);
            this.radioAdd.TabIndex = 1;
            this.radioAdd.TabStop = true;
            this.radioAdd.Text = "Add";
            this.radioAdd.UseVisualStyleBackColor = true;
            this.radioAdd.CheckedChanged += new System.EventHandler(this.radioAdd_CheckedChanged);
            // 
            // brushSize
            // 
            this.brushSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.brushSize.ForeColor = System.Drawing.SystemColors.Info;
            this.brushSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.brushSize.Location = new System.Drawing.Point(49, 37);
            this.brushSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.brushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(63, 23);
            this.brushSize.TabIndex = 2;
            this.brushSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.brushSize.ValueChanged += new System.EventHandler(this.brushSize_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Info;
            this.label12.Location = new System.Drawing.Point(3, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.Info;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Brush Settings";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1524, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "New";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1524, 1021);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addPaintLayerButton);
            this.Controls.Add(this.layerDown);
            this.Controls.Add(this.layerUp);
            this.Controls.Add(this.deleteLayerButton);
            this.Controls.Add(this.addNoiseLayerButton);
            this.Controls.Add(this.layerList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.brushPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FicMapGenDemo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainScale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskMix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskThreshold)).EndInit();
            this.brushPanel.ResumeLayout(false);
            this.brushPanel.PerformLayout();
            this.brushModeBox.ResumeLayout(false);
            this.brushModeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private NumericUpDown mainScale;
        private Label mainScaleLabel;
        private NumericUpDown mainThreshold;
        private Label label1;
        private NumericUpDown mainOctaves;
        private Label label2;
        private Panel panel2;
        private NumericUpDown maskThreshold;
        private NumericUpDown maskScale;
        private NumericUpDown maskOctaves;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown maskMix;
        private Label label7;
        private Label label8;
        private Label label10;
        private NumericUpDown mainSeed;
        private Label label9;
        private NumericUpDown maskSeed;
        private FlowLayoutPanel layerList;
        private Button addNoiseLayerButton;
        private Button deleteLayerButton;
        private Button layerUp;
        private Button layerDown;
        private Button addPaintLayerButton;
        private Panel brushPanel;
        private Label label11;
        private NumericUpDown brushSize;
        private Label label12;
        private GroupBox brushModeBox;
        private RadioButton radioDelete;
        private RadioButton radioAdd;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private NumericUpDown offsetY;
        private NumericUpDown offsetX;
        private Label label14;
        private Label label13;
        private CheckBox substractCheckBox;
        private Label label15;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}