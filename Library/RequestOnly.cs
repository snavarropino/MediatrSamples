using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Comando2: IRequest
    {
        
        public string Name { get; set; }
    }

    

    public class Manejador2 : IRequestHandler<Comando2>
    {
        private readonly IMediator _mediator;

        public Manejador2(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        public async Task Handle(Comando2 request, CancellationToken cancellationToken)
        {
             await Task.Delay(1,cancellationToken);
        }
    }
}
