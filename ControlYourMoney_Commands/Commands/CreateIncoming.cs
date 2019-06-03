using System;
using ControlYourMoney_Commands.Models;

namespace ControlYourMoney_Commands.Commands
{
    public class CreateIncoming
    {
        public CreateIncoming(Guid incomingId, Category category, double amount, string comment, DateTime createDateTime)
        {
            IncomingId = incomingId;
            Category = category;
            Amount = amount;
            Comment = comment;
            CreateDateTime = createDateTime;
        }

        public Guid IncomingId { get; }

        public Category Category { get; }

        public double Amount { get; }

        public string Comment { get; }

        public DateTime CreateDateTime { get; }
    }
}
