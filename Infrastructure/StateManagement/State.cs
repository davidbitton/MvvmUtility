using System.ComponentModel.Composition;

namespace MvvmUtility.Infrastructure.StateManagement {
    public class State<T> : IState<T> {
        [Import]
        public ICurrentState<T> CurrentState {
            set { Value = value.Value; }
        }

        #region IState<T> Members

        public T Value { get; private set; }

        #endregion
    }
}