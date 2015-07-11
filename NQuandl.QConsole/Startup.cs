//using System;
//using Hangfire;
//using Hangfire.SqlServer;
//using Hangfire.SqlServer.RabbitMQ;
//using Microsoft.Owin;
//using NQuandl.QConsole;
//using Owin;

//[assembly: OwinStartup(typeof(Startup))]

//namespace NQuandl.QConsole
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            app.UseErrorPage();
//            app.UseWelcomePage("/");

//            var sqlServerStorage =
//                new SqlServerStorage(@"server=SHIVA9.;initial catalog=nquandl.hangfire;integrated security=sspi")
//                    .UseRabbitMq(
//                        conf =>
//                        {
//                            conf.HostName = "192.168.1.28";
//                            conf.Port = 5672;
//                        }, "myqueue");

//            GlobalConfiguration.Configuration.UseStorage(sqlServerStorage)
//            .UseDashboardMetric(SqlServerStorage.ActiveConnections)
//            .UseDashboardMetric(SqlServerStorage.TotalConnections);

//            // GlobalConfiguration.Configuration.UseMemoryStorage();


//            var options = new BackgroundJobServerOptions
//            {
//                SchedulePollingInterval = TimeSpan.FromMilliseconds(10),
//                WorkerCount = Environment.ProcessorCount * 5
//            };
//            GlobalJobFilters.Filters.Add(new JobMonitor());
//            app.UseHangfireDashboard();
//            app.UseHangfireServer(options);

//        }
//    }
//}