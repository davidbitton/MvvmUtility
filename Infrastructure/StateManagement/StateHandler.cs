using System.ComponentModel.Composition.Hosting;

namespace MvvmUtility.Infrastructure.StateManagement {
    public class StateHandler {
        private readonly CompositionContainer _container;

        public StateHandler(CompositionContainer container) {
            _container = container;
        }

        public T SetState<T>(T context) {
            return SetCurrentState(context);
        }

        private T SetCurrentState<T>(T context) {
            var currentState = GetInstance<ICurrentState<T>>();
            var previousValue = currentState.Value;
            currentState.Value = context;

            return previousValue;
        }

        private T GetInstance<T>() {
            return _container.GetExportedValue<T>();
        }
    }
}