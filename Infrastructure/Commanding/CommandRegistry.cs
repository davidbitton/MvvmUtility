using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MvvmUtility.Infrastructure.Commanding {
    public class CommandRegistry : ICommandRegistry {
        private readonly IList<Action> _raiseCanExecuteChangedList = new List<Action>();

        #region ICommandRegistry Members

        public ICommand Add(Action executeFn) {
            return Add(p => executeFn(), null);
        }

        public ICommand Add(Action executeFn, Func<object, bool> canExecuteFn) {
            return Add(p => executeFn(), canExecuteFn);
        }

        public ICommand Add(Action<object> executeFn) {
            return Add(executeFn, null);
        }

        public virtual ICommand Add(Action<object> executeFn, Func<object, bool> canExecuteFn) {
            var cmd = new BasicCommand(executeFn, canExecuteFn);

            if (null != canExecuteFn) {
                AddRaiseCanExecuteChangedToList(cmd.RaiseCanExecuteChanged);
            }

            return cmd;
        }

        public void RaiseCanExecuteChanged() {
            foreach (Action each in _raiseCanExecuteChangedList)
                each();
        }

        #endregion

        protected void AddRaiseCanExecuteChangedToList(Action raiser) {
            _raiseCanExecuteChangedList.Add(raiser);
        }
    }
}