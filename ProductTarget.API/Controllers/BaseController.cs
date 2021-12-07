using Management.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ProductTarget.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BaseController() { }
        public BaseController(AppDbContext context)
        {
            _context = context;
        }
    }
}
