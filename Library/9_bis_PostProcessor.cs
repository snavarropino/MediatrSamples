using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Command7: IRequest<Response7>
    {        
        public string Name { get; set; }
    }

    public class Response7 
    {
        public int Id { get; set; }
    }

    public class Handler7 : AsyncRequestHandler<Command7,Response7>
    {
        
        protected override async Task<Response7> HandleCore(Command7 request)
        {
            await Task.Delay(1);
            return new Response7(){Id = 1};
        }
    }

    public class PostProcessor <TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger<PostProcessor<TRequest, TResponse>> _logger;

        public PostProcessor(ILogger<PostProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, TResponse response)
        {
            //Uncomment logs in order to realize that this post-processor is working
            await Task.Delay(1);
            //
            //_logger.LogInformation("Postprocessor handler...");

            if (response is Response7)
            {
                (response as Response7 ).Id=69;
                //_logger.LogInformation("Postprocessor is handling and specilized response...");
            }
        }
    }
}
