namespace Projects.Domain.Entities
{
    public class Atividade : BaseEntity
    {
        public Atividade(string activityName, DateTime deadLine, int idUser, int idProject)
        {
            ActivityName = activityName;
            IdUser = idUser;
            IdProject = idProject;
            DeadLine = deadLine;
            
        }

        public string ActivityName { get; private set; }
        public User Client { get; private set; }
        public Project ProjectName { get; private set; }
        public DateTime DeadLine { get; private set; }
        public int IdUser { get; private set; }
        public int IdProject { get; private set; }
        public DateTime FinishedAt { get; private set; }
        

        public void FinishActivity()
        {
            IsActive = false;
            FinishedAt = DateTime.Now;
        }
    }
}
