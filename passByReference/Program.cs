namespace passByReference
{
    public struct Crystal
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public Crystal (double height, double width, double breadth)
        {
            Height = height;
            Width = width;
            Breadth = breadth;
        }
    }
    public class ChangeDimension
    {
        public static void changeBreadth(ref Crystal crystal)
        {
            crystal.Breadth = 800;
            Console.WriteLine($"inside Change: {crystal.Breadth}");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public Person(string name, string level)
        {
            Name = name;
            Level = level;
        }
    }
    public class Update
    {
        public static void UpdateDetial(ref Person person)
        {
            person.Name = "Haleemah";
            person = new Person("Yusuf", "6");
            Console.WriteLine($"from inside function: {person.Name}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Crystal crystal1 = new Crystal(100, 200, 300);
            Console.WriteLine(crystal1.Breadth);
            ChangeDimension.changeBreadth(ref crystal1);
            Console.WriteLine(crystal1.Breadth);
            Person person1 = new Person("Billy", "5");
            Console.WriteLine(person1.Name);
            Update.UpdateDetial(ref person1);
            Console.WriteLine(person1.Name);
        }
    }
}
