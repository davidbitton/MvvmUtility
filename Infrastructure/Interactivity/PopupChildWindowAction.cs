using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace MvvmUtility.Infrastructure.Interactivity {
    public class PopupChildWindowAction : TriggerAction<FrameworkElement> {

        private ChildWindow _childWindow;

        /// <summary>
        /// The child window to display as part of the popup.
        /// </summary>
        public static readonly DependencyProperty ChildWindowProperty =
            DependencyProperty.Register(
                "RootElement",
                typeof(FrameworkElement),
                typeof(PopupChildWindowAction),
                new PropertyMetadata(null));

        /// <summary>
        /// The <see cref="DataTemplate"/> to apply to the popup content.
        /// </summary>
        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register(
                "ContentTemplate",
                typeof(DataTemplate),
                typeof(PopupChildWindowAction),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the child window to pop up.
        /// </summary>
        /// <remarks>
        /// If not specified, a default child window is used instead.
        /// </remarks>
        public FrameworkElement RootElement {
            get { return (FrameworkElement)GetValue(ChildWindowProperty); }
            set { SetValue(ChildWindowProperty, value); }
        }

        /// <summary>
        /// Gets or sets the content template for a default child window.
        /// </summary>
        public DataTemplate ContentTemplate {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        protected override void Invoke(object parameter) {
            var args = parameter as InteractionRequestedEventArgs;
            if (args == null) return;

            if (RootElement == null || !(RootElement is Panel)) return;

            var childWindow = GetChildWindow(args.Context);

            var callback = args.Callback;
            DependencyPropertyChangedEventHandler handler = null;
            handler = (o, e) => {
                if (childWindow.IsVisible) return; // unless were "closed", don't fire callback
                childWindow.IsVisibleChanged -= handler;
                callback();
            };
            childWindow.IsVisibleChanged += handler;

            var panelChildren = ((Panel)RootElement).Children;
            if (!panelChildren.Contains(childWindow))
                panelChildren.Add(childWindow);
            childWindow.Visibility = Visibility.Visible;
        }

        private ChildWindow GetChildWindow(Notification notification) {
            var childWindow = _childWindow ?? (_childWindow = new ChildWindow {
                ClientArea = {
                    Content = GetClientTemplate(notification)
                },
                DataContext = notification
            });
            childWindow.DataContext = notification;
            return childWindow;
        }

        private UserControl GetClientTemplate(Notification notification) {
            return notification is Confirmation
                ? (UserControl)new ConfirmationChildWindow { ConfirmationTemplate = ContentTemplate }
                : new NotificationChildWindow { NotificationTemplate = ContentTemplate };
        }
    }
}
