
namespace FicMapGen
{
    //abstract class representing general layer
    internal abstract class Layer : IDisposable
    {
        protected int width;
        protected int height;

        protected int layerType;

        private bool visibility = true;

        protected DirectBitmap content;

        public Layer(int w,int h,int type)
        {
            width = w;
            height = h;
            content = new DirectBitmap(width, height);
            clearContent();
            layerType = type;
        }

        public DirectBitmap getBitmap()
        {
            return content;
        }

        public int getLayerType()
        {
            return layerType;
        }

        public bool Visibility { get => visibility; set => visibility = value; }

        protected virtual void clearContent()
        {
            Graphics g = Graphics.FromImage(content.Bitmap);
            g.Clear(Color.Black);
            g.Dispose();
        }

        public abstract void Dispose();
    }
}
