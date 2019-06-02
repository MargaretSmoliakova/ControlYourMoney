using EventStore.ClientAPI;
using System;
using System.Net;
using System.Text;

namespace ControlYourMoney.Events
{
    public class TestEvent
    {
        public static string CreateEvent()
        {
            //WRITE EVENT
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var myEvent = new EventData(Guid.NewGuid(), "testEvent", false,
                            Encoding.UTF8.GetBytes("some data"),
                            Encoding.UTF8.GetBytes("some metadata"));

            connection.AppendToStreamAsync("test-stream", ExpectedVersion.Any, myEvent).Wait();

            //READ EVENT
            var streamEvents = connection.ReadStreamEventsForwardAsync("test-stream", 0, 1, false).Result;
            var returnedEvent = streamEvents.Events[0].Event;
            return String.Format("Read event with data: {0}, metadata: {1}",
                Encoding.UTF8.GetString(returnedEvent.Data),
                Encoding.UTF8.GetString(returnedEvent.Metadata));
        }
    }
}
