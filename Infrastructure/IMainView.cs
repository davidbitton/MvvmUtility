using System.Windows.Controls;

namespace MvvmUtility.Infrastructure {
    public interface IMainView {
        UserControl CurrentView { get; set; }
    }
}