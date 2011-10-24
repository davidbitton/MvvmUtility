namespace MvvmUtility.Infrastructure.StateManagement {
    public abstract class CurrentState<T> : ICurrentState<T> {
        #region ICurrentState<T> Members

        public T Value { get; set; }

        #endregion
    }
}