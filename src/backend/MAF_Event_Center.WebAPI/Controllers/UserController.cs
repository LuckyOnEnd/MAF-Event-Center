using Microsoft.AspNetCore.Mvc;

namespace MAF_Event_Center.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUserById() 
        {
            return Ok();
        }
    }
}
