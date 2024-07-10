namespace Extenson_2
{
    public interface IIdentification
    {
        int id { get; }
    }
    public static class Auth
    {
        public static bool AuthId (this IIdentification identification)
    {
        if (identification.id > 0)
        {
            return true;
        }
        return false;
    }
    }
    public class Pet : IIdentification
    {
        public string PetType { get; set; }
        public Pet( string petType ) 
        {
            PetType = petType;
        }
        public int id { get
            {
                return 7;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet pet1 = new Pet("cat");
            Console.WriteLine(pet1.PetSound());
            Console.WriteLine(pet1.AuthId());
        }
    }
}
