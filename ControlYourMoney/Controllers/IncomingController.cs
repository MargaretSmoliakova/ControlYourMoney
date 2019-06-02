using ControlYourMoney.Events;
using Microsoft.AspNetCore.Mvc;

namespace ControlYourMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Initial()
        {
            return TestEvent.CreateEvent();
        }

        [HttpGet]
        [Route("{mobileInput}")]
        public ActionResult<string> GetModifiedMobileInput(string mobileInput)
        {
            return $"{mobileInput}_Returned_From_API";
        }
    }
}
