using static exp.Interfaces.InterfaceRoles;
using static exp.exp1.forClass;
namespace exp.exp1;


internal class forRecord 
{
    public record PersonRecord : IRole
    {
        public string Name { get; init; }
        public string Occupation { get; init; }
        public string Gender { get; init; }
        string IRole.Name { get; set; }

        public PersonRecord(string name, string occupation, string gender)
        {
            Name = name;
            Occupation = occupation;
            Gender = gender;
        }
        public string UpdateName()
        {
            
            return Name.ToUpper();
        }

        public string RoleName()
        {
            return "";
        }
    }
    public record PersonRecord2(string name, string gender, int id);
}
