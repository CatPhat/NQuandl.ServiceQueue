using System;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Redis.StackExchange;
using Microsoft.Owin;
using NQuandl.ServiceQueue;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace NQuandl.ServiceQueue
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
            
            GlobalConfiguration.Configuration.UseRedisStorage("192.168.1.28:6379")
                .UseDashboardMetric(DashboardMetrics.ProcessingCount);
            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMilliseconds(1),
                WorkerCount = 1000
            };
            app.UseErrorPage();
            app.UseWelcomePage("/");
            app.UseHangfireDashboard();
            app.UseHangfireServer(options);
           
            
        }
    }

    
}