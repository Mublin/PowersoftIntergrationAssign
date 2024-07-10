namespace exp.Interfaces;

internal interface InterfaceRoles
{
    public interface IRole
    {
        string Name { get; set; }
        string RoleName();

    }
}
