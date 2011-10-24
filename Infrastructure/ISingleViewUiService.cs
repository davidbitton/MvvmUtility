namespace MvvmUtility.Infrastructure {
    public interface ISingleViewUiService {
        IMainView MainWindow { get; }
        void ShowView(string viewName);
        void ShowView<T>(string viewName, T context);
    }
}