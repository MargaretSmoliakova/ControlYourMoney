using System.Threading.Tasks;

namespace ControlYourMoney_Framework.Commands
{
    public class Dispatcher
    {
        private readonly CommandHandler _commandHandler;

        public Dispatcher(CommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public Task Dispatch<T>(T command) where T : class
        {
            var handler = _commandHandler.Get(command);

            return handler(command);
        }
    }
}
