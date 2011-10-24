using System.ComponentModel.Composition;
using System.Windows.Controls;
using MvvmUtility.Infrastructure.StateManagement;

namespace MvvmUtility.Infrastructure {
    public abstract class SingleViewUiService<TMainView> : ISingleViewUiService
        where TMainView : ContentControl, IMainView, new() {
        private /*readonly*/ TMainView _mainWindow;

        [Import(typeof (ViewFactory))]
        public ViewFactory ViewFactory { get; set; }

        [Import(typeof (StateHandler))]
        public StateHandler StateHandler { get; set; }

        #region ISingleViewUiService Members

        public IMainView MainWindow {
            get { return _mainWindow ?? (_mainWindow = ViewFactory.GetView<TMainView>()); }
        }

        public void ShowView(string viewName) {
            var view = ViewFactory.GetView(viewName);
            MainWindow.CurrentView = view;
        }

        public void ShowView<T>(string viewName, T context) {
            var previousValue = StateHandler.SetState(context);
            try {
                ShowView(viewName);
            }
            finally {
                StateHandler.SetState(previousValue);
            }
        }

        #endregion
        }
}