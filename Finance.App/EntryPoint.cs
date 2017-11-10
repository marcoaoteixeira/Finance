using System;
using System.Reflection;
using System.Windows.Forms;
using Finance.App.Code;
using Finance.App.Views;
using Finance.Core;
using Nameless.WinFormsApplication.CQRS.IoC;
using Nameless.WinFormsApplication.Data.IoC;
using Nameless.WinFormsApplication.IoC;
using Nameless.WinFormsApplication.Logging.IoC;
using Nameless.WinFormsApplication.ObjectMapper.IoC;
using Nameless.WinFormsApplication.PubSub.IoC;
using Nameless.WinFormsApplication.Search.IoC;

namespace Finance.App {

    internal static class EntryPoint {

        #region Internal Static Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main() {
            Bootstrap.Instance.Run();

            var supportAssemblies = new[] {
                Assembly.Load("Finance.App"),
                Assembly.Load("Finance.Core"),
                Assembly.Load("Nameless.WinFormsApplication.Core")
            };

            using (var compositionRoot = new CompositionRoot()) {
                compositionRoot.Compose(new IServiceRegistration[] {
                    new CQRSServiceRegistration(supportAssemblies),
                    new DataServiceRegistration(),
                    new LoggingServiceRegistration(supportAssemblies),
                    new ObjectMapperServiceRegistration(supportAssemblies),
                    new PubSubServiceRegistration(supportAssemblies),
                    new SearchServiceRegistration(),
                    new ClientServiceRegistration(supportAssemblies)
                });

                compositionRoot.StartUp();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(compositionRoot.Resolver.Resolve<MainForm>());
            }
        }

        #endregion Internal Static Methods
    }
}