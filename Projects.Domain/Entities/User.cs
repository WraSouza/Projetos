namespace Projects.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string password, string email) : base()
        {            
            FullName = fullName;
            Email = email;
            Password = password;
            Role = "";

            Projects = [];
            Atividades = [];
        }
        
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public List<Project> Projects { get; private set; }
        public List<Atividade> Atividades { get; private set; }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

    }
}
