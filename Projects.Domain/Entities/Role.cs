namespace Projects.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(string roleName) : base()
        {
            RoleName = roleName;
        }

        public string RoleName { get; private set; }
    }
}
