using System.Xml.Linq;

namespace classExp
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            
        }
        
        public string Greeting()
        {
            return $"Hello {Name}, they said your age is {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What is your age: ");
            int age = int.Parse(Console.ReadLine());
            Person person = new Person("",age);
            person.name = "Abdullahi";
            string greet = person.Greeting();
            Console.WriteLine(greet);
        }
    }
}
