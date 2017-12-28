using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Event2 : INotification
    {
        public string Source { get; set; }
    }

    public class SynchronousListener : NotificationHandler<Event2>
    {
        private readonly ILogger<SynchronousListener> _logger;

        public SynchronousListener(ILogger<SynchronousListener> logger)
        {
            _logger = logger;
        }

        protected override void HandleCore(Event2 notification)
        {
            _logger.LogInformation("Handling event {notification} with source: {name} ", notification, notification.Source);
            Task.Delay(1);
        }
    }
    public class NoCancelTokenListener : AsyncNotificationHandler<Event2>
    {
        private readonly ILogger<NoCancelTokenListener> _logger;

        public NoCancelTokenListener(ILogger<NoCancelTokenListener> logger)
        {
            _logger = logger;
        }

        protected override Task HandleCore(Event2 notification)
        {
            _logger.LogInformation("Handling event {notification} with source: {name} ", notification, notification.Source);
            return Task.CompletedTask;
        }
    }
}