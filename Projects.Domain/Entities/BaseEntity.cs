namespace Projects.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }
    }
}
