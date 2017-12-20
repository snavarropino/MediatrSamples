using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Library
{
    public class Event1 : INotification
    {
        public string Source { get; set; }
    }

    public class Listener1 : INotificationHandler<Event1>
    {
        public Task Handle(Event1 notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    public class Listener2 : INotificationHandler<Event1>
    {
        public Task Handle(Event1 notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
