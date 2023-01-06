using Microsoft.AspNetCore.Mvc;
using SearchName.Application;
using System.Net;

namespace SearchNameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly IRequests _requests;

        public SearchController(IRequests requests)
        {
            _requests = requests;
        }


        [HttpPost("first-request")]
        public IActionResult PostFirst(string key)
        {
            string response= _requests.Request1(key);
            return Ok(response);
        }
        [HttpGet("second-request")]
        public IActionResult GetSecond()
        {
            string response = _requests.Request2();
            return Ok(response);
        }
        [HttpGet("system-all-datas")]
        public IActionResult RedisTop()
        {
            var top = _requests.RedisTop();
            return Ok(top);
        }
    }
}
