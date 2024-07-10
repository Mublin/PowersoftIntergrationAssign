namespace extension.Pet
{
    namespace extension
    {
        public class PetExtension
        {
            public string Sound (Pet pet)
            {
                return pet.PetType == "cat" ? "meow" : pet.PetType == "dog" ? "woof woof" : pet.PetType == "cow" ? "moo-moo" : "";
            }
        }
        internal class PetMethod
        {

        }
    }
}
