using Model;
using System.Text.Json;

namespace Template.Model
{
    public class Template : Entity
    {
        public override string SerializedEntity()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
