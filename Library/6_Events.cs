using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Event1 : INotification
    {
        public string Source { get; set; }
    }

    public class Listener1 : INotificationHandler<Event1>
    {
        private readonly ILogger<Listener1> _logger;

        public Listener1(ILogger<Listener1> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Event1 notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling event {notification} with source: {name} ", notification, notification.Source);
            await Task.Delay(1, cancellationToken);
        }
    }
    public class Listener2 : INotificationHandler<Event1>
    {
        private readonly ILogger<Listener2> _logger;

        public Listener2(ILogger<Listener2> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Event1 notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling event {notification} with source: {name} ", notification, notification.Source);
            await Task.Delay(1, cancellationToken);
        }
    }
}
