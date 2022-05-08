
namespace FicMapGen
{
    internal static class HelpDialog
    {
        //method spawns a window with help information
        public static void showDialog()
        {
            Form helpDialog = new Form();
            helpDialog.Width = 520;
            helpDialog.Height = 500;
            helpDialog.Text = "Help Information";
            helpDialog.BackColor = Color.FromArgb(26, 24, 37);

            TextBox txt1 = new TextBox() { Multiline=true, ReadOnly=true, ForeColor=Color.White,
                BackColor= Color.FromArgb(26, 24, 37), Width=500,Height=500,BorderStyle=BorderStyle.None};
            txt1.AppendText("Making new map");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("In order to make a new map go to File>New in menu strip and choose a resolution.");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Exporting a map");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Go to File>Save and choose location, file name and file format to save map as an image.");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Noise Layer");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Noise layer will place a landmass generated with a noise texture on top of layers beneath it." +
                " Area in which the landmass will be placed must be marked by left clicking and draging on the image." +
                " Area can be changed after marking. Values in Noise properties define shape of the landmass. Mask Properties" +
                "define shape of edges of the landmass. Mask is created from the mix of elliptical gradient and noise texture" +
                "(separate from main noise texture). Mix attribute defines the influence of gradient and noise, where mix=0 " +
                "means mask is composed in 100% of elliptical gradient and mix=1 means that mask is compsed in 100% of the " +
                "noise. Invert checkbox changes behavior in such way that layer will substract white pixels from layers beneath.");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Paint Layer");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Paint layer can be freely painted on by left clicking and draging on image. Layer will either add " +
                "pixels on top of layers beneath or substract from them.");
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText(Environment.NewLine);
            txt1.AppendText("Every layer can be renamed by double clicking on it or disabled by clicking on checkbox. Layers can" +
                " be deleted or moved around by using arrow buttons.");

            helpDialog.Controls.Add(txt1);
            helpDialog.ShowDialog();
        }
    }
}
