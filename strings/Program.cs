namespace strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string quote = "Love the way you lie";
            // using double qoute "
            string doubleQuote = "hey\"s its me";
            string empty = string.Empty;
            Console.WriteLine(quote.Length);
            Console.WriteLine($"{quote} {doubleQuote}");
            // substring
            Console.WriteLine(quote.Substring(0, 6));
            // parsing string "16" to 16
            string temperature = "16";
            int parseTemp = int.Parse(temperature);
            Console.ReadKey();
        }
    }
}
