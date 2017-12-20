using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Comando4: IRequest<RespuestaComando4>
    {
        public Comando4(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class RespuestaComando4
    {
        public int Id { get; set; }
    }

    public class Manejador4 : IRequestHandler<Comando4, RespuestaComando4>
    {
        public Manejador4()
        {}
        public async Task<RespuestaComando4> Handle(Comando4 request, CancellationToken cancellationToken)
        {
            await Task.Delay(1,cancellationToken);
            return new RespuestaComando4(){Id = 5};
        }
    }

    public class Manejador4bis : IRequestHandler<Comando4, RespuestaComando4>
    {
        public Manejador4bis()
        { }
        public async Task<RespuestaComando4> Handle(Comando4 request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return new RespuestaComando4() { Id = 5 };
        }
    }
}
