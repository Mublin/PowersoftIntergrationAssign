using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extenson_2
{
    public static class PetExtension
    {
        public static string PetSound(this Pet pet)
        {
            switch (pet.PetType)
            {
                case "cat":
                    return "meow";
                case "dog":
                    return "woof-woof";
                case "cow":
                    return "moo-moo";
                case "chicken":
                    return "kukkuruku";
                default:
                    return "";
            }
        }
    }
    internal class Class1
    {

    }
}
