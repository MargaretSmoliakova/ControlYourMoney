using System;
using System.Collections.Generic;

namespace ControlYourMoney_Framework
{
    public class AggregateRoot : IAggregateRoot
    {
        public readonly Dictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();

        public readonly List<object> _events = new List<object>();

        public List<object> GetEvents() => _events;

        public Guid Id { get; protected set; }

        public int Version { get; protected set; } = -1;

        public void Register<T>(Action<T> when)
        {
            _handlers.Add(typeof(T), o => when((T) o));
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public void Apply(object obj)
        {
            Rise(obj);
            Version++;
        }

        protected void Rise(object obj)
        {
            _handlers[obj.GetType()](obj);
            _events.Add(obj);
        }
    }
}
