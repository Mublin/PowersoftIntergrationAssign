namespace CastingValueType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // casting
            int age = 32;
            float preciseAge = 32.9f;
            // we can change int to long no problem float to double no problem but the other way round is a problem
            long sAge = age;
            double sPrecise = preciseAge;
            // notice the syntax
            int preciseAgeInt = (int)preciseAge;
            long bigNo = 1111111111111111111;
            int smallNo = (int)bigNo;
            Console.WriteLine($"bigNo: {bigNo}, smallNo: {smallNo}");
        }
    }
}
