namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string content = "";
            try {
                content = File.ReadAllText("doc.txt");
                Console.WriteLine(content);
            }catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
            finally
            {
                Console.WriteLine(content.Length);
            }
        }
    }
}
