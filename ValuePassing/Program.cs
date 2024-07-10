Rectangle rectangle1 = new Rectangle(200, 300);
Console.WriteLine($"outside: {rectangle1.Height}");
ChangeHeight.Change(rectangle1);
Console.WriteLine($"outside2: {rectangle1.Height}");

public struct Rectangle
{
    public double Width { get; set; }
    public double Height{ get; set; }
    public Rectangle (double width, double height)
    {
        Width = width;
        Height = height;
    }

}
public class ChangeHeight
{
   public static void Change(Rectangle rect)
    {
        rect.Height = 500;
        Console.WriteLine($"method inside {rect.Height}");
    }
}

