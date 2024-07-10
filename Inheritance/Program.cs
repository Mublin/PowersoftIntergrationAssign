namespace Inheritance
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public Person (int id, string name, string age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public string Greeting()
        {
            return $"Hi, my name is {Name}, I am {Age}";
        }
        public virtual string Job() {
            return "I am a student";
        }

    }
    public class Occupation : Person
    {
        public string Occupant {  get; set; }
        public Occupation (int id, string name, string age, string occupant) : base(id, name, age) {
            Occupant = occupant;
        }
        public override string Job()
        {
            return $"I am a {Occupant}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(1, "Abdul", "23");
            Occupation occupation1 = new Occupation(1, "Abdul", "23", "football");
            Console.WriteLine(person1.Job());
            Console.WriteLine(occupation1.Job());
        }
    }
}
