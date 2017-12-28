using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class MyCommand2: IRequest
    {
        public string Name { get; set; }
    }

    public class MyHandler2 : IRequestHandler<MyCommand2>
    {
        private readonly ILogger<MyHandler2> _logger;

        public MyHandler2(ILogger<MyHandler2> logger)
        {
            _logger = logger;
        }
       
        public async Task Handle(MyCommand2 request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling command {command} with name: {name} ", request, request.Name);
            await Task.Delay(1,cancellationToken);
        }
    }
}
