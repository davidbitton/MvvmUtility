using System.Windows;
using System.Windows.Controls;

namespace MvvmUtility.Infrastructure.Interactivity {
    /// <summary>
    /// Interaction logic for RootElement.xaml
    /// </summary>
    public partial class ChildWindow {

        public static readonly DependencyProperty TitleProperty =
           DependencyProperty.Register(
           "Title", 
           typeof(string),
           typeof(ChildWindow)
           );

        public static readonly DependencyProperty ClientTemplateProperty =
            DependencyProperty.Register(
            "ClientTemplate",
            typeof(UserControl),
            typeof(ChildWindow),
            new PropertyMetadata(null)
        );

        public ChildWindow() {
            InitializeComponent();
        }

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public UserControl ClientTemplate {
            get { return (UserControl)GetValue(ClientTemplateProperty); }
            set { SetValue(ClientTemplateProperty, value); }
        }

        private void ChildWindow_OnLoaded(object sender, RoutedEventArgs e) {
            Visibility = Visibility.Visible;
        }
    }
}
