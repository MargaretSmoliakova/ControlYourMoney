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
        [Route("CreateIncoming")]
        public async Task<ActionResult<string>> CreateIncoming(CreateIncoming createIncoming)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            await connection.ConnectAsync();
            var aggregateRepository = new AggregateRepository(connection);
            var commandHandlers = new CommandHandlers(aggregateRepository);
            var dispatcher = new Dispatcher(commandHandlers);
            var createIncomingCommand = new CreateIncoming(Guid.NewGuid(), createIncoming.Category, createIncoming.Amount, createIncoming.Comment, DateTime.Now);
            await dispatcher.Dispatch(createIncomingCommand);

            return "command issued / event created";
        }

        [HttpGet]
        [Route("TestInput")]
        public ActionResult GetModifiedMobileInput()
        {
            return Ok(new CreateIncoming(Guid.NewGuid(), new ControlYourMoney_Commands.Models.Category(Guid.NewGuid(), "Salary"), 5700, "test comment", DateTime.Now));
        }
    }
}
