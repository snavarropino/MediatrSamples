using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class AllEventslListener : AsyncNotificationHandler<INotification>
    {
        private readonly ILogger<AllEventslListener> _logger;

        public AllEventslListener(ILogger<AllEventslListener> logger)
        {
            _logger = logger;
        }
        protected override Task HandleCore(INotification notification)
        {
            //Set up a break point or uncomment the log in order to realize tghat this listener is receiving all events
            //_logger.LogInformation("Handling event {notification} with a listener that receives all events", notification);
            return Task.CompletedTask;
        }
    }
}