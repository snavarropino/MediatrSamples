using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;

namespace Library
{
    public class Comando7: IRequest<Respuesta7>
    {        
        public string Name { get; set; }
    }

    public class Respuesta7 
    {
        public int Id { get; set; }
    }

    public class Manejador7 : AsyncRequestHandler<Comando7,Respuesta7>
    {
        
        protected override async Task<Respuesta7> HandleCore(Comando7 request)
        {
            await Task.Delay(1);
            return new Respuesta7(){Id = 1};
        }
    }

    public class Postprocesado <TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {      
        public async Task Process(TRequest request, TResponse response)
        {
            await Task.Delay(1);

            if(response is Respuesta7)
            {
                (response as Respuesta7 ).Id=69;
            }
        }
    }
}
