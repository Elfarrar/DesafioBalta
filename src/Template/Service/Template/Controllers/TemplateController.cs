using Base.Controllers;
using Microsoft.AspNetCore.Mvc;
using Template.Repository;

namespace Template.Controllers
{
    [ApiController]
    [Route("Template")]
    public class TemplateController : BaseController<Model.Template>
    {
        public TemplateController(ITemplateRepository repository) : base(repository) { }
    }
}
