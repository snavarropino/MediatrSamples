using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class MyCommand3: IRequest
    {
        public string Name { get; set; }
    }
    
    public class NoCancellationTokenHandler : AsyncRequestHandler<MyCommand3>
    {
        private readonly ILogger<NoCancellationTokenHandler> _logger;

        public NoCancellationTokenHandler(ILogger<NoCancellationTokenHandler> logger)
        {
            _logger = logger;
        }
        
        protected override async Task HandleCore(MyCommand3 request)
        {
            _logger.LogInformation("Handling command {command} with name: {name} ", request, request.Name);
            await Task.Delay(1);
        }
    }
}
