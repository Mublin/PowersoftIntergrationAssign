namespace Static
{
    public static class Operation
    {
        public static double PI
        {
            get { return 3.14d; }
        }
        
        public static decimal calc(decimal a,decimal b, char op) { 
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '/':
                    return a / b;
                case 'x':
                    return a * b;
                default:
                    return (a*b);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal result = Operation.calc(20, 3, '/');
            Console.WriteLine(result);
        }
    }
}
