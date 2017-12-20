using System.Threading.Tasks;
using MediatR;

namespace Library
{
    
    public class AllEventslListener : AsyncNotificationHandler<INotification>
    {
        
        protected override Task HandleCore(INotification notification)
        {
            return Task.CompletedTask;
        }
    }
}
