namespace classPrep
{
    public class Person
    {
        private int Age { get; set; }
        private string Name;
        private string Hobby;
        private string PhoneNumber;
        public Person ( string name, int age, string hobby, string phoneNumber)
        {
            Name = name;
            Age = age;
            Hobby = hobby;
            PhoneNumber = phoneNumber;
        }
        public string userDetails()
        {
            return $"name: {Name}, age: {Age}, hobby: {Hobby}, phoneNumber: {PhoneNumber}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("What is your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your hobby: ");
            string hobby = Console.ReadLine();
            Console.WriteLine("What is your phoneNumber: ");
            string phoneNumber = Console.ReadLine();
            Person person = new Person(name, age, hobby, phoneNumber);
            string details = person.userDetails();
            Console.WriteLine(details);
        }
    }
}
