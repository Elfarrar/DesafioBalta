using Model;
using System.Text.Json;

namespace IBGE.Model
{
    public class IBGE : Entity
    {
        public override string SerializedEntity()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
