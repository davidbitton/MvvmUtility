using System;
using System.Windows.Input;

namespace MvvmUtility.Infrastructure.Commanding {
    public class BasicCommand : ICommand {
        private static readonly Func<object, bool> AlwaysTrue = p => true;
        private readonly Func<object, bool> _canExecuteFn;
        private readonly Action<object> _executeFn;

        public BasicCommand(Action<object> executeFn, Func<object, bool> canExecuteFn) {
            _executeFn = executeFn;
            _canExecuteFn = canExecuteFn ?? AlwaysTrue;
        }

        public bool CanExecute(object parameter) {
            return _canExecuteFn(parameter);
        }

        public void Execute(object parameter) {
            if (CanExecute(parameter)) _executeFn(parameter);
        }

        public void RaiseCanExecuteChanged() {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}