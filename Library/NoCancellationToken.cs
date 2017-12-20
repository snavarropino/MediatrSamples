using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Comando3: IRequest
    {
        
        public string Name { get; set; }
    }

    

    public class Manejador3 : AsyncRequestHandler<Comando3>
    {
        private readonly IMediator _mediator;

        public Manejador3(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        protected override async Task HandleCore(Comando3 request)
        {
            await Task.Delay(1);
        }
    }
}
