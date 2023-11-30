using IBGE.Data;
using Repository;

namespace IBGE.Repository
{
    public class IBGERepository : Repository<Model.IBGE>, IIBGERepository
    {
        public IBGERepository(IBGEContext db) : base(db) { }
    }
}
