// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<int> brain = SwitchIn.SwitchInAlgo(50);
Console.WriteLine($"{string.Join(",", brain)}");
class SwitchIn
{
    public static List<int> SwitchInAlgo(int no) 
    {
        var arr = new List<int>();
        List<int> color = new List<int>{1,2,3,4};
        int indexesNo = color.Count;
        for (int i = 0; i < no; i++)
        {
            Random number = new Random();
            int newIndex = number.Next(0, indexesNo);
            arr.Add(color[newIndex]);
        }
        Console.WriteLine($"{string.Join(",", arr)}");
        return arr;
    }
}