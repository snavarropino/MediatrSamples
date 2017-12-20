using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Comando5: IRequest
    {
        
        public string Name { get; set; }
    }

    

    public class ManejadorSincrono : RequestHandler<Comando5>
    {
        
        protected override void HandleCore(Comando5 message)
        {
            Task.Delay(1);
        }
    }
}
