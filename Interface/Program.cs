namespace Interface
{
    public interface IAvatar
    {
        string PlayerType();
        string PlayerPowers();
    }
    public class Player : IAvatar
    {
        public string PlayerType()
        {
            return "Wizard";
        }
        public string PlayerPowers()
        {
            return "Telekonesis";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IAvatar wizard = new Player();
            Console.WriteLine(wizard.PlayerPowers());
            Console.WriteLine(wizard.PlayerType());

        }
    }
}
