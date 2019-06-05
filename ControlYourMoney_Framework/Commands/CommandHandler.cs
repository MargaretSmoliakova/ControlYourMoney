using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlYourMoney_Framework.Commands
{
    public class CommandHandler
    {
        private Dictionary<Type, Func<object, Task>> _handlers = new Dictionary<Type, Func<object, Task>>();

        public void Register<T>(Func<T, Task> command) where T : class
        {
            _handlers.Add(typeof(T), x => command((T)x));
        }

        public Func<object, Task> Get<T>(T command)
        {
            return _handlers[typeof(T)];
        }
    }
}
