using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace MvvmUtility.Infrastructure.Commanding {
    public class PrismCommandRegistry : CommandRegistry {
        public override ICommand Add(Action<object> executeFn, Func<object, bool> canExecuteFn) {
            var cmd = new DelegateCommand<object>(executeFn, canExecuteFn);

            if (null != canExecuteFn) {
                AddRaiseCanExecuteChangedToList(cmd.RaiseCanExecuteChanged);
            }

            return cmd;
        }
    }
}