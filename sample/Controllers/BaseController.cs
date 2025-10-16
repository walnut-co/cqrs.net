using CQRS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IRequestDispatcher requestDispatcher;
        protected IRequestDispatcher RequestDispatcher => requestDispatcher ??= HttpContext.RequestServices.GetService<IRequestDispatcher>();
    }
}
