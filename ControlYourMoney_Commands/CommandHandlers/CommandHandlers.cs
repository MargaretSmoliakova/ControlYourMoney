using ControlYourMoney_Commands.Commands;
using System;

namespace ControlYourMoney_Framework.Commands
{
    public class CommandHandlers : CommandHandler
    {
        public CommandHandlers(AggregateRepository repository)
        {
            Register<CreateIncoming>(async x =>
            {
                var aggregateRoot = new CreateIncoming(Guid.NewGuid(), x.Category, x.Amount, x.Comment, x.CreateDateTime);

                await repository.Save(aggregateRoot);
            });
        }
    }
}
