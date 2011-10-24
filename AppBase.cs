using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Windows.Threading;
using MvvmUtility.Infrastructure;
using MvvmUtility.Infrastructure.StateManagement;

namespace MvvmUtility {
    public abstract class AppBase : Application {

        protected CompositionContainer Container;
        protected AggregateCatalog Catalog;

        protected AppBase() {
            Startup += ApplicationStartup;
            Exit += ApplicationExit;
            DispatcherUnhandledException += ApplicationUnhandledException;
        }

        protected virtual void ApplicationUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached) {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
            }
        }

        protected virtual void ApplicationExit(object sender, ExitEventArgs e) {
            Container.Dispose();
            Catalog.Dispose();
        }

        protected virtual void ApplicationStartup(object sender, StartupEventArgs e) {
            Catalog = new AggregateCatalog(
                new AssemblyCatalog(typeof(AppBase).Assembly)
                );
            Container = new CompositionContainer(Catalog);

            Container.ComposeExportedValue(new ViewFactory(Container));
            Container.ComposeExportedValue(new StateHandler(Container));
        }
    }
}
