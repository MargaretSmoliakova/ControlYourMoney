using System.Threading.Tasks;

namespace ControlYourMoney_Framework
{
    public class AggregateRepository : IAggregateRepository
    {
    private IEventStoreConnection _connection;

    public AggregateRepository(IEventStoreConnection connection)
    {
        _connection = connection;
    }

    public Task Save<T>(T command)
    {

    }
    }
}
