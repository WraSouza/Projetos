namespace Projects.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Today.AddYears(-2);
            IsActive = true;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; set; }
    }
}
