using System;
using ControlYourMoney_Commands.Events;
using ControlYourMoney_Commands.Models;
using ControlYourMoney_Framework;

namespace ControlYourMoney_Commands.AggregateRoots
{
    public class IncomingAggregateRoot : AggregateRoot
    {
        private Category _category;

        private double _amount;

        private string _comment;

        public IncomingAggregateRoot(Guid incomingId, Category category, double amount, string comment) : this()
        {
            Rise(new IncomingCreated(incomingId, category, amount, comment));
        }

        private IncomingAggregateRoot()
        {
            Register<IncomingCreated>(When);
        }

        public void When(IncomingCreated incomingCreated)
        {
            Id = incomingCreated.IncomingId;
            _category = incomingCreated.Category;
            _amount = incomingCreated.Amount;
            _comment = incomingCreated.Comment;
        }
    }
}
