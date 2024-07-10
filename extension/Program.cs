using System;
using extension.Pet.extension; // Importing the namespace

namespace extension
{
    public class Pet
    {
        public string PetType { get; set; }
        public string PetSound { get; set; }
        public Pet(string petType, string petSound = "")
        {
            PetType = petType;
            PetSound = petSound;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet(petType: "cat");

            // Creating an instance of PetExtension
            extension.Pet.extension.PetExtension petExtension = new extension.Pet.extension.PetExtension();

            // Accessing the Sound method
            Console.WriteLine(petExtension.Sound(pet));
        }
    }
}
