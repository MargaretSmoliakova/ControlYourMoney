using System;
using System.Linq;
using System.Threading.Tasks;
using ControlYourMoney_Framework.Helpers;
using EventStore.ClientAPI;

namespace ControlYourMoney_Framework
{
    public class AggregateRepository : IAggregateRepository
    {
        private IEventStoreConnection _connection;

        public AggregateRepository(IEventStoreConnection connection)
        {
            _connection = connection;
        }

        public Task Save(IAggregateRoot aggregateRoot)
        {
            var events = aggregateRoot.GetEvents().Select(ToEventData);

            return _connection.AppendToStreamAsync(
                StreamName(aggregateRoot.GetType(), aggregateRoot.Id), 
                aggregateRoot.Version, 
                events);
        }

        public static EventData ToEventData(object o)
        {
            return new EventData(Guid.NewGuid(), o.GetType().Name, true, o.Serialize(), null);
        }

        private string StreamName(Type aggregateType, Guid id)
        {
            return $"{aggregateType.Name}-{id}";
        }
    }
}
