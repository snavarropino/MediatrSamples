using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Event2 : INotification
    {
        public string Source { get; set; }
    }

    public class SyncListener : NotificationHandler<Event2>
    {
        
        protected override void HandleCore(Event2 notification)
        {
            Task.Delay(1);
        }
    }
    public class NoCancelListener : AsyncNotificationHandler<Event2>
    {
        
        protected override Task HandleCore(Event2 notification)
        {
            return Task.CompletedTask;
        }
    }
}
