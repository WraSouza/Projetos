namespace Projects.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string password, string userName) : base()
        {            
            FullName = fullName;
            UserName = userName;
            Password = password;

            Projects = [];
            Atividades = [];
        }
        
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
        public List<Project> Projects { get; private set; }
        public List<Atividade> Atividades { get; private set; }

    }
}
