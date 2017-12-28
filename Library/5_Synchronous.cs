using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Command5: IRequest
    {
        public string Name { get; set; }
    }

    public class SynchronousHandler : RequestHandler<Command5>
    {
        private readonly ILogger<SynchronousHandler> _logger;

        public SynchronousHandler(ILogger<SynchronousHandler> logger)
        {
            _logger = logger;
        }

        protected override void HandleCore(Command5 message)
        {
            _logger.LogInformation("Handling command {command} with name: {name} ", message, message.Name);
            Task.Delay(1);
        }
    }
}
