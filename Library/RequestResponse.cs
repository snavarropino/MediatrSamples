using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Comando1: IRequest<RespuestaComando>
    {
        private Comando1()
        {
        }

        public Comando1(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class RespuestaComando
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<Comando1, RespuestaComando>
    {
        private readonly IMediator _mediator;

        public Manejador(IMediator mediator)
        {
            _mediator = mediator;
        }
        private Manejador()
        {}
        public async Task<RespuestaComando> Handle(Comando1 request, CancellationToken cancellationToken)
        {
            await Task.Delay(1,cancellationToken);
            return new RespuestaComando(){Id = 5};
        }
    }
}
