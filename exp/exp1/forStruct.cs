namespace exp.exp1;

internal class forStruct
{
    public struct Rectangle
    {
        public int Height;
        public int Width;
        public Rectangle(int height, int width) {
            Height = height;
            Width = width;
        }
        public int Perimeter()
        {
            return (2 * Height) + (2 * Width);
        }
    }
}
