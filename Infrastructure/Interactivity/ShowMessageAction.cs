using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace MvvmUtility.Infrastructure.Interactivity {

    public class ShowMessageAction : TriggerAction<FrameworkElement> {
        // element in view where message will be shown
        public static readonly DependencyProperty TitleBoxProperty =
           DependencyProperty.Register("TitleBox", typeof(TextBox),
              typeof(ShowMessageAction));

        public TextBox TitleBox {
            get { return (TextBox)GetValue(TitleBoxProperty); }
            set { SetValue(TitleBoxProperty, value); }
        }

        protected override void Invoke(object parameter) {
            var e =
               parameter as InteractionRequestedEventArgs;
            if (e == null) return;
            if (TitleBox == null) return;
            TitleBox.Opacity = 1.0;
            TitleBox.Text = e.Context.Title;
            // TODO: for example, hide after some time
        }
    }
}
