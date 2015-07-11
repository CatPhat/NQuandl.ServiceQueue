using System;
using Hangfire;
using Microsoft.Owin.Hosting;
using NQuandl.Client.Api;
using NQuandl.Client.Domain.Queries;
using NQuandl.Client.Domain.RequestParameters;
using NQuandl.ServiceQueue.CompositionRoot;
using SimpleInjector;

namespace NQuandl.ServiceQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string endpoint = "http://localhost:12345";
          
            using (WebApp.Start<Startup>(endpoint))
            {
                Console.WriteLine();
                Console.WriteLine("{0} Hangfire Server started.", DateTime.Now);
                Console.WriteLine("{0} Dashboard is available at {1}/hangfire", DateTime.Now, endpoint);
                Console.WriteLine();
                Console.WriteLine("{0} Type JOB to add a background job.", DateTime.Now);
                Console.WriteLine("{0} Press ENTER to exit...", DateTime.Now);

                DateTime requestStartTime = DateTime.Now;
                string command;
                while ((command = Console.ReadLine()) != String.Empty)
                {
                    if ("job".Equals(command, StringComparison.OrdinalIgnoreCase))
                    {
                        for (int i = 1; i <= 100; i++)
                        {
                            var requestParameters = new RequestParametersV2
                            {
                                ApiKey = "XXXX",
                                Query = "*",
                                SourceCode = "UN",
                                PerPage = 300,
                                Page = i
                            };

                            //var lastRequestTime = requestStartTime;
                            //requestStartTime = DateTime.Now;
                            //var millisecondsLapsed = (requestStartTime - lastRequestTime).TotalMilliseconds;
                            //Console.WriteLine("Request Started: {0}", i);
                            //Console.WriteLine("Milliseconds from last request: {0}", millisecondsLapsed);
                            BackgroundJob.Schedule( () => new GetV2().GetJsonResponseV2(requestParameters), TimeSpan.FromMilliseconds(300 * i));

                        }
                    }
                }
            }
        }
    }
}