using System.Threading.Tasks;

namespace ControlYourMoney_Framework
{
    public interface IAggregateRepository
    {
        Task Save(IAggregateRoot aggregateRoot);
    }
}
