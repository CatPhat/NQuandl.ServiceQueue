using System;
using Rebus;
using Rebus.Configuration;
using Rebus.Logging;
using Rebus.Persistence.SqlServer;
using Rebus.SimpleInjector;
using Rebus.Timeout;
using Rebus.Transports.Sql;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
{
    public static class CompositionRoot
    {
        public static void ConfigureBus(Container container)
        {
            container.Register<IStoreTimeouts>(
                () =>
                    new SqlServerTimeoutStorage(
                        @"server=SHIVA9.;initial catalog=RebusInputQueue;integrated security=sspi", "timeouts")
                        .EnsureTableIsCreated());

            container.RegisterManyForOpenGeneric(typeof (IHandleMessages<>), AccessibilityOption.PublicTypesOnly,
                container.RegisterAll, AppDomain.CurrentDomain.GetAssemblies());

            Configure.With(new SimpleInjectorAdapter(container))
                .Logging(l => l.None())
                .Transport(
                    t =>
                        t.UseSqlServer(@"server=SHIVA9.;initial catalog=RebusInputQueue;integrated security=sspi",
                            "thequeue", "my-app.input", "my-app.error").EnsureTableIsCreated())
                .MessageOwnership(x => x.Use(new DetermineQueueOwnership())).CreateBus().Start();
        }
    }
}