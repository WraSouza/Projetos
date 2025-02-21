

namespace Projects.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Project(string projectName,DateTime deadLine, int idUser) : base()
        {
            ProjectName = projectName;            
            DeadLine = deadLine;
            IdUser = idUser;
            Atividades = [];  
            
            IsFinished = false;

        }

        public string ProjectName { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public DateTime DeadLine { get; private set; }
        public User User { get; private set; }
        public int IdUser { get; private set; }
        public List<Atividade> Atividades { get; private set; }
        public bool IsFinished { get; private set; }

        public void FinishProject()
        {
            IsFinished = true;
            FinishedAt = DateTime.Now;
        }

    }
}
