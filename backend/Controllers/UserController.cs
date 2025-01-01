using Microsoft.AspNetCore.Mvc;

namespace NutriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(new[] { "User1", "User2", "User3" });
        }
    }
}
