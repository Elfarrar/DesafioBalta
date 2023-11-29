using Repository;
using Template.Data;

namespace Template.Repository
{
    public class TemplateRepository : Repository<Model.Template>, ITemplateRepository
    {
        public TemplateRepository(TemplateContext db) : base(db) { }
    }
}
