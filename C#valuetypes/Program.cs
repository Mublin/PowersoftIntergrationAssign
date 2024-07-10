namespace C_valuetypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool enabled = false;
            Console.WriteLine($"enabled : {enabled}");
            enabled = true;
            Console.WriteLine($"enabled: {enabled}");
            //Note that char has '' and string has ""
            char a = 'a';
            char b = 'b';
            Console.WriteLine($"char : {b}");
            Console.WriteLine($"char : {a}");

            // int
            int no1 = 5;
            int no2 = -7;
            int multiply = no1 * no2;
            int subtract = no1 - no2;
            Console.WriteLine(subtract);
            Console.WriteLine(multiply);
            // long
            long i = 507;
            Console.WriteLine(i);
            // other numeric types
            float j = 3.5f;
            double k = 9.8d;
            decimal l = 4.55667m;
            Console.WriteLine($"float: {j}, double: {k}, decimal: {l}");
            Console.WriteLine(10f / 3f);
            Console.WriteLine(10d / 3d);
            Console.WriteLine(10m / 3m);
            // copying values
            int a1 = 5;
            int a2 = a1;
            a1 = 3;
            Console.WriteLine($"a1 : {a1}, a2: {a2}");
            // Null
            int? a5 = null;
            bool? gaskiya = null;

        }
    }
}
