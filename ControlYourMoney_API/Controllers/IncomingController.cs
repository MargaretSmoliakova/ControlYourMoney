using System;
using System.Net;
using System.Threading.Tasks;
using ControlYourMoney_Commands.Commands;
using ControlYourMoney_Framework;
using ControlYourMoney_Framework.Commands;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Mvc;

namespace ControlYourMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> CreateIncoming(CreateIncoming createIncoming)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            await connection.ConnectAsync();
            var aggregateRepository = new AggregateRepository(connection);
            var commandHandler = new CommandHandlers(aggregateRepository);
            var dispatcher = new Dispatcher(commandHandler);
            var createIncomingCommand = new CreateIncoming(Guid.NewGuid(), createIncoming.Category, createIncoming.Amount, createIncoming.Comment, DateTime.Now);
            await dispatcher.Dispatch(createIncomingCommand);

            return "command issued / event created";
        }

        [HttpGet]
        [Route("{mobileInput}")]
        public ActionResult<string> GetModifiedMobileInput(string mobileInput)
        {
            return $"{mobileInput}_Returned_From_API";
        }
    }
}
