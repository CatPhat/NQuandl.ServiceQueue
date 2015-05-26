using System;
using System.Linq;
using Rebus;
using Rebus.Configuration;
using Rebus.Logging;
using Rebus.Persistence.SqlServer;
using Rebus.Timeout;
using Rebus.Transports.Sql;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
{
    public static class CompositionRoot
    {
        public static void RegisterRebus(this Container container)
        {
            ConfigureAndStartRebus(container);
            //container.RegisterManyForOpenGeneric(typeof(IHandleMessages<>), typeof(IHandleMessages<>).Assembly);

            // var repositoryAssembly = typeof (IHandleMessages<>).Assembly;
            
            container.RegisterManyForOpenGeneric(typeof (IHandleMessages<>), container.RegisterAll, typeof (IHandleMessages<>).Assembly);
            

            var repositoryAssembly = typeof(IBus).Assembly;

           container.RegisterAll(typeof(IBus));

        


        }

        private static void ConfigureAndStartRebus(this Container container)
        {
            Configure.With(new SimpleInjectorAdapter(container))
                .Logging(l => l.None())
                .Transport(
                    t =>
                        t.UseSqlServer(@"server=SHIVA9.;initial catalog=RebusInputQueue;integrated security=sspi",
                            "thequeue", "my-app.input", "my-app.error").EnsureTableIsCreated())
                .Timeouts(
                    x =>
                        x.Use(
                            new SqlServerTimeoutStorage(
                                @"server=SHIVA9.;initial catalog=RebusInputQueue;integrated security=sspi",
                                "timeouts").EnsureTableIsCreated()))
                .MessageOwnership(x => x.Use(new DetermineQueueOwnership()))
                .CreateBus()
                .Start();
        }
    }
}