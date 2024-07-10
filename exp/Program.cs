using static exp.exp1.forClass;
using static exp.exp1.forStruct;
using static exp.exp1.forRecord;
using static exp.exp1.Math;
using System.Collections.Generic;


Person person1 = new Person("Nick", "student");
Console.WriteLine($"{person1.Name} , {person1.Occupation}");
person1.ChangeOccupation("singer");
Console.WriteLine($"{person1.Name} , {person1.Occupation}");
Rectangle rectangle1 = new Rectangle(5, 7);
int result = rectangle1.Perimeter();
Console.WriteLine(result);
PersonRecord personRecord = new PersonRecord("Wale", "prof", "male");
Console.WriteLine(personRecord.UpdateName());
PersonRecord2 personRecord2 = new("Henry", gender: "male", id: 4);
Console.WriteLine(personRecord2);
double? result1 = MathTest.MakeCalc(34, "*", 5);
Console.WriteLine(result1);
Random random = new Random(10);
Console.WriteLine(random.Next(1,10));
bool game = NumberGuesser.GuessNumber(1);
Console.WriteLine(game);


var todos = new List<TodoModel>();
todos.Add(new ("football", ["red", "black", "yellow"], 1, 1, 25));
foreach (var item in todos)
{
    Console.WriteLine(item);
}

record TodoModel(string Name, List<string> Colors, int Quantity, int Id, int Instock);

public class NumberGuesser
{
    public static bool GuessNumber(int value)
    {
        Random random1 = new Random();
        int number = random1.Next(1, 5);;
        Console.WriteLine($"chosenNmber: {value}, GeneratedNumber: {number}");
        return number == value;
    }
}
