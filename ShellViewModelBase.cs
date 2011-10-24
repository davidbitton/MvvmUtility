using Microsoft.Practices.Prism.Events;
using MvvmUtility.Infrastructure.Converters;
using MvvmUtility.Infrastructure.Eventing;
using MvvmUtility.Infrastructure.ViewUtility;

namespace MvvmUtility {
    public abstract class ShellViewModelBase : WorkspaceViewModel {
        protected ShellViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator) {
            Subscribe();
        }

        public abstract string Version { get; }

        private void Subscribe() {
            EventAggregator.GetEvent<StatusEvent>().Subscribe(
                OnStatusEvent,
                ThreadOption.UIThread,
                true,
                StatusEventPredicate
                );
            EventAggregator.GetEvent<BusyEvent>().Subscribe(
                OnBusyEvent,
                ThreadOption.UIThread,
                true,
                BusyEventPredicate
                );
        }

        protected virtual bool BusyEventPredicate(BusyEventPayload obj) {
            return true;
        }

        protected virtual void OnBusyEvent(BusyEventPayload obj) {
            
        }

        protected virtual void OnStatusEvent(StatusEventPayload obj) {
            //MessageBox.Show(obj.Status);
        }

        protected virtual bool StatusEventPredicate(StatusEventPayload payload) {
            return true;
        }

        
    }
}