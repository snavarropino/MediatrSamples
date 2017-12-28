using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class MyCommand: IRequest<MyCommandResponse>
    {
        public MyCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class MyCommandResponse
    {
        public int Id { get; set; }
    }

    public class MyHandler : IRequestHandler<MyCommand, MyCommandResponse>
    {
        private readonly ILogger<MyHandler> _logger;

        public MyHandler(ILogger<MyHandler> logger)
        {
            _logger = logger;
        }
        
        public async Task<MyCommandResponse> Handle(MyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling command {command} with name: {name} ",request,request.Name);
            await Task.Delay(1,cancellationToken);
            return new MyCommandResponse(){Id = 5};
        }
    }
}
