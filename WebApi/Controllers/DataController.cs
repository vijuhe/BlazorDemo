using Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository repository;

        public DataController(IDataRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DataRequest request)
        {
            var data = repository.GetData(request.RowCount);
            return Ok(new DataResponse { Values = data });
        }
    }
}