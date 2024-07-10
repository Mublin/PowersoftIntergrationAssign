using exp.Interfaces;

namespace exp.exp1;

internal class forClass
{
    public class Person : InterfaceRoles
    {
        public string Name { get; set; }
        public string Occupation { get; private set; }

        public Person (string name, string occupation)
        {
            Name = name;
            Occupation = occupation;
        }
        public void ChangeOccupation (string occupation)
        {
            Occupation = occupation;
        }
        public string RoleName()
        {
            return Occupation;
        }
    }
}
