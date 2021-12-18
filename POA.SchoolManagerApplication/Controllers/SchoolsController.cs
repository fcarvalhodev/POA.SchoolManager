using Microsoft.AspNetCore.Mvc;


namespace POA.SchoolManagerApplication.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchoolsController : ControllerBase
    {

        [Route("health")]
        [HttpGet]
        public string Health()
        {
            return "OK";
        }
    }
}
