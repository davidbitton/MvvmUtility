using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Events;

namespace MvvmUtility.Infrastructure.Eventing {
    [Export(typeof (IEventAggregator))]
    public class TicketDispatcherEventAggregator : EventAggregator {
    }
}