using Model.Enums;

namespace Model
{
    public class Audit
    {
        public Audit(AuditType type, Guid createUser, string state)
        {
            Id = Guid.NewGuid();
            Type = type;
            CreateUser = createUser;
            CreateDate = DateTime.UtcNow;
            State = state;
        }

        public Guid Id { get; private set; }
        public AuditType Type { get; private set; }
        public Guid CreateUser { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string State { get; private set; }
    }
}
