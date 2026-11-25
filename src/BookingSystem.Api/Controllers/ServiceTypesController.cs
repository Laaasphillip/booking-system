using BookingSystem.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypesController : ControllerBase
    {
        private readonly BookingSystemDbContext _context;

        public ServiceTypesController(BookingSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetServiceTypes()
        {
            var result = _context.ServiceTypes.ToList();
            return Ok(result);
        }

    }
}
