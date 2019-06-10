using ControlYourMoney_Commands.Commands;
using System;
using ControlYourMoney_Commands.AggregateRoots;

namespace ControlYourMoney_Framework.Commands
{
    public class CommandHandlers : CommandHandler
    {
        public CommandHandlers(AggregateRepository repository)
        {
            Register<CreateIncoming>(async x =>
            {
                var aggregateRoot = new IncomingAggregateRoot(Guid.NewGuid(), x.Category, x.Amount, x.Comment);
                await repository.Save(aggregateRoot);
            });
        }
    }
}
