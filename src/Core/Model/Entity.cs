using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Model
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            Audit = new List<Audit>();
        }

        [Key]
        public Guid Id { get; private set; }

        public bool IsDeleted { get; private set; }

        [JsonIgnore]
        public List<Audit>? Audit { get; private set; }

        public virtual string SerializedEntity()
        {
            return JsonSerializer.Serialize(this);
        }

        public void DeleteEntity()
        {
            IsDeleted = true;
        }

        public void AddAudit(Audit audit)
        {
            Audit.Add(audit);
        }

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(null, compareTo)) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return this.GetType() == obj?.GetType() && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() + Id.GetHashCode());
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
