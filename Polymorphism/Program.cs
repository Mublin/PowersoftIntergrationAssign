namespace Polymorphism
{
    public class Pet
    {
        public virtual string sayPetType()
        {
            return "I am a pet";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
