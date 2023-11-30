using Base.Controllers;
using IBGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IBGE.Controllers
{
    [ApiController]
    [Route("IBGE")]
    public class IBGEController : BaseController<Model.IBGE>
    {
        public IBGEController(IIBGERepository repository) : base(repository) { }
    }
}
