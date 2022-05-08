
namespace FicMapGen
{
    internal class PaintLayer : Layer
    {
        private int radius = 15;
        private int brushMode=0;
        private Brush whiteBrush;
        private Brush blackBrush;
        private Graphics g;
        public PaintLayer(int w,int h) : base(w,h,1)
        {
            whiteBrush = new SolidBrush(Color.White);
            blackBrush = new SolidBrush(Color.Black);
            g = Graphics.FromImage(content.Bitmap);
        }

        //use System.Drawing to paint an ellipse on bitmap
        public void paintOn(int x,int y)
        {
            if(brushMode==0)
            {
                g.FillEllipse(whiteBrush, new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius));
            }
            else
            {
                g.FillEllipse(blackBrush, new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius));
            }
        }

        public void setRadius(int r)
        {
            radius = r;
        }

        public void setBrushMode(int m)
        {
            brushMode = m;
        }

        protected override void clearContent()
        {
            Graphics g = Graphics.FromImage(content.Bitmap);
            g.Clear(Color.Gray);
            g.Dispose();
        }

        public override void Dispose()
        {
            g.Dispose();
            whiteBrush.Dispose();
            blackBrush.Dispose();
            content.Dispose();
        }
    }
}
