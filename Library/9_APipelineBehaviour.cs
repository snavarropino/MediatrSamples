using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Command6: IRequest<Response6>
    {
        public string Name { get; set; }
    }

    public class Response6 
    {
        public int Id { get; set; }
    }

    public class Handler6 : AsyncRequestHandler<Command6,Response6>
    {
        protected override async Task<Response6> HandleCore(Command6 request)
        {
            await Task.Delay(1);
            return new Response6(){Id = 1};
        }
    }

    public class LoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> 
    {
        private readonly ILogger<LoggingBehavior<TReq, TRes>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TReq, TRes>> logger)
        {
            _logger = logger;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            //Uncomment logs in order to se what the behaviour is doing
            //_logger.LogInformation("Before...");
            var response = await next();
            //_logger.LogInformation("After...");
            
            return response;
        }
    }

    public class SecondLoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> 
    {
        private readonly ILogger<SecondLoggingBehavior<TReq, TRes>> _logger;

        public SecondLoggingBehavior(ILogger<SecondLoggingBehavior<TReq, TRes>> logger)
        {
            _logger = logger;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            //Uncomment logs in order to se what the behaviour is doing
            //_logger.LogInformation("Second before...");
            var response = await next();
            //_logger.LogInformation("Second after...");
            return response;
        }
    }

    public class SpecializedBehavior<Command6, Response6> : IPipelineBehavior<Command6, Response6> 
    {
        private readonly ILogger<SpecializedBehavior<Command6, Response6>> _logger;

        public SpecializedBehavior(ILogger<SpecializedBehavior<Command6, Response6>> logger)
        {
            _logger = logger;
        }

        public async Task<Response6> Handle(Command6 request, CancellationToken cancellationToken, RequestHandlerDelegate<Response6> next)
        {
            //Uncomment logs in order to realize that specialized behaviour is not working
            //All commands are handled here :-(
            //_logger.LogInformation("SpecializedBehavior Before...");
            var response = await next();
            //_logger.LogInformation("SpecializedBehavior After...");
            return response;
        }
    }
}