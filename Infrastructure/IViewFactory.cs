using System.Windows.Controls;

namespace MvvmUtility.Infrastructure {
    public interface IViewFactory {
        UserControl GetView(string viewName);
        T GetView<T>() where T : ContentControl;
    }
}