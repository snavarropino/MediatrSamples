using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Command4: IRequest<Command4Response>
    {
        public Command4(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class Command4Response
    {
        public int Id { get; set; }
    }

    public class Handler4 : IRequestHandler<Command4, Command4Response>
    {
        private readonly ILogger<Handler4> _logger;

        public Handler4(ILogger<Handler4> logger)
        {
            _logger = logger;
        }

        public async Task<Command4Response> Handle(Command4 request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler4 is handling command {command} with name: {name} ", request, request.Name);
            await Task.Delay(1,cancellationToken);
            return new Command4Response(){Id = 5};
        }
    }

    public class AnotherHandler4 : IRequestHandler<Command4, Command4Response>
    {
        private readonly ILogger<MyHandler> _logger;

        public AnotherHandler4(ILogger<MyHandler> logger)
        {
            _logger = logger;
        }
        public async Task<Command4Response> Handle(Command4 request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AnotherHandle4 is handling command {command} with name: {name} ", request, request.Name);
            await Task.Delay(1, cancellationToken);
            return new Command4Response() { Id = 55 };
        }
    }
}
