using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using System.IO;

namespace Library
{
    public class Comando6: IRequest<Respuesta6>
    {
        
        public string Name { get; set; }
    }

    public class Respuesta6 
    {

        public int Id { get; set; }
    }



    public class Manejador6 : AsyncRequestHandler<Comando6,Respuesta6>
    {
        
        protected override async Task<Respuesta6> HandleCore(Comando6 request)
        {
            await Task.Delay(1);
            return new Respuesta6(){Id = 1};
        }
    }

    public class LoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> 
    {
        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next) {
            
            System.Console.WriteLine("Before...");
            
            var response = await next();
            
            System.Console.WriteLine("After...");
            
            return response;
        }
    }

    public class SecondLoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> 
    {
        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next) {
            
            System.Console.WriteLine("Second Before...");
            
            var response = await next();
            
            System.Console.WriteLine("Second After...");
            
            return response;
        }
    }

    public class SpecializedBehavior<Comando6, Respuesta6> : IPipelineBehavior<Comando6, Respuesta6> 
    {
        public async Task<Respuesta6> Handle(Comando6 request, CancellationToken cancellationToken, RequestHandlerDelegate<Respuesta6> next) {
            
            System.Console.WriteLine("Second Before...");
            
            var response = await next();
            
            System.Console.WriteLine("Second After...");
            
            return response;
        }
    }
}
