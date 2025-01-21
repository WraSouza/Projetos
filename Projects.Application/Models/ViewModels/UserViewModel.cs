using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id,string fullName,string email, List<Project> projetos, List<Atividade> atividades)
        {
            Id = id;
            FullName = fullName;
            Email = email;  
            Projetos = projetos;
            Atividades = atividades;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Project> Projetos { get;  set; }
        public List<Atividade> Atividades { get; set; }

        public static UserViewModel FromEntity(User entity)
           => new(entity.Id,entity.FullName, entity.Email, entity.Projects, entity.Atividades);
    }
}
