using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using MvvmUtility.Infrastructure.Commanding;
using MvvmUtility.Infrastructure.Converters;
using MvvmUtility.Infrastructure.Eventing;

namespace MvvmUtility.Infrastructure.ViewUtility {
    /// <summary>
    /// This ViewModelBase subclass requests to be removed 
    /// from the UI when its CloseCommand executes.
    /// This class is abstract.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModelBase {
        #region Fields

        protected readonly ICommandRegistry CommandRegistry = new PrismCommandRegistry();
        protected readonly IEventAggregator EventAggregator;

        #endregion // Fields

        #region Constructor

        protected WorkspaceViewModel(IEventAggregator eventAggregator) {
            EventAggregator = eventAggregator;
        }

        protected WorkspaceViewModel() {
        }

        #endregion

        #region CloseCommand

        private ICommand _closeCommand;

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand {
            get { return _closeCommand ?? (_closeCommand = CommandRegistry.Add(OnRequestClose, CanClose)); }
        }

        private static bool CanClose(object arg) {
            return true;
        }

        #endregion // CloseCommand

        #region RequestClose [event]

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        protected virtual void OnRequestClose() {
            var handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion // RequestClose [event]

        protected void UpdateStatus(string status, Exception error = null) {
            //var update = error == null ? status : String.Format("Exception: {0}", error);
            EventAggregator.GetEvent<StatusEvent>().Publish(new StatusEventPayload(status, error));
        }

        protected void UpdateBusy(bool isBusy) {
            EventAggregator.GetEvent<BusyEvent>().Publish(new BusyEventPayload() { IsBusy = isBusy });
        }
    }
}