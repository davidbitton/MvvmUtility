using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;

namespace MvvmUtility.Infrastructure {
    public class ViewFactory {
        private readonly CompositionContainer _container;

        public ViewFactory(CompositionContainer container) {
            _container = container;
        }

        public UserControl GetView(string viewName) {
            var view = _container.GetExportedValueOrDefault<UserControl>(viewName);
            if (view == null)
                throw new InvalidOperationException(String.Format("Unable to locate view with name {0}.", viewName));
            return view;
        }

        public T GetView<T>() where T : ContentControl {
            var view = _container.GetExportedValueOrDefault<T>();
            if (view == null)
                throw new InvalidOperationException(String.Format("Unable to locate view with type {0}.", typeof (T)));
            return view;
        }
    }
}