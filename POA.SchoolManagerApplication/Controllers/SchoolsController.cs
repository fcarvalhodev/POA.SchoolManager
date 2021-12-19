using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POA.SchoolManagerApplication.Models;
using POA.SchoolManagerApplication.Services;
using System.Threading.Tasks;

namespace POA.SchoolManagerApplication.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolsService _schoolService;
        public SchoolsController(ISchoolsService schoolService)
        {
            _schoolService = schoolService;
        }

        [Route("health")]
        [HttpGet]
        public string Health()
        {
            return "OK";
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<SchoolModel>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<SchoolModel>>> GetSchools()
        {
           return await _schoolService.GetAll();
        }

        [Route("GetByQuery")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<SchoolModel>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<SchoolModel>>> GetByParameters([FromQuery] SearchSchoolRequest request)
        {
            return await _schoolService.GetByQuery(request);
        }
    }
}
