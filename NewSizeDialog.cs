
namespace FicMapGen
{
    internal static class NewSizeDialog
    {
        //spawns a dialog window that lets user choose size of new map
        public static Size showDialog()
        {
            Size res = new Size(-1, -1);
            Form sizeDialog = new Form();
            sizeDialog.Width = 275;
            sizeDialog.Height = 175;
            sizeDialog.Text = "Create New Map";
            sizeDialog.BackColor = Color.FromArgb(26, 24, 37);
            Label wLabel = new Label() { ForeColor=Color.White, Left = 20, Top = 25, Width=50, Text = "Width" };
            Label hLabel = new Label() { ForeColor = Color.White, Left = 20, Top = 55, Width=50, Text = "Height" };
            NumericUpDown wInput = new NumericUpDown() { ForeColor = Color.White, BackColor = Color.FromArgb(16,16,24),
                Left = 70, Top = 20, Width = 90, Maximum=2000, Minimum=1, Increment=100, Value=500 };
            NumericUpDown hInput = new NumericUpDown() { ForeColor = Color.White, BackColor = Color.FromArgb(16,16,24),
                Left = 70, Top = 50, Width = 90, Maximum=2000, Minimum=1, Increment=100, Value=500 };
            Button confirmation = new Button() { BackColor = Color.White, Text = "Ok", Left = 20, Width = 60, Top = 85 };
            Button cancellation = new Button() { BackColor = Color.White, Text = "Cancel", Left = 100, Width = 60, Top = 85 };
            confirmation.Click += (sender, e) => { res.Width = (int)wInput.Value; res.Height = (int)hInput.Value; sizeDialog.Close(); };
            cancellation.Click += (sender, e) => { sizeDialog.Close(); };
            sizeDialog.Controls.Add(confirmation);
            sizeDialog.Controls.Add(cancellation);
            sizeDialog.Controls.Add(wLabel);
            sizeDialog.Controls.Add(hLabel);
            sizeDialog.Controls.Add(wInput);
            sizeDialog.Controls.Add(hInput);
            sizeDialog.ShowDialog();
            return res;
        }
    }
}
