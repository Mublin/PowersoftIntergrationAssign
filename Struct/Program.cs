namespace Struct
{
    public class Animal
    {
        public Animal (string name, string animalType)
        {
            Name = name;
            AnimalType = animalType;
        }
        public string Name { get;  set; }
        public string AnimalType { get; set;}

    }
    public struct Rectangle
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Width { get; set; }
        public double Height { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle(200,300);
            Console.WriteLine($"{rectangle1.Width}, {rectangle1.Height}");
            rectangle1.Height = 500;
            Console.WriteLine($"{rectangle1.Width}, {rectangle1.Height}");

        }
    }
}
