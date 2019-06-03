using System;

namespace ControlYourMoney_Commands.Models
{
    public class Category
    {
        public Category(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public Guid CategoryId { get; }

        public string Name { get; }
    }
}
