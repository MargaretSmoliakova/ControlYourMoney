using System;
using ControlYourMoney_Commands.Models;

namespace ControlYourMoney_Commands.Events
{
    public class IncomingCreated
    {
        public IncomingCreated(Guid incomingId, Category category, double amount, string comment)
        {
            IncomingId = incomingId;
            Category = category;
            Amount = amount;
            Comment = comment;
        }

        public Guid IncomingId { get; }

        public Category Category { get; }

        public double Amount { get; }

        public string Comment { get; }
    }
}
