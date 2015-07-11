using System;
using System.IO;
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
                        var requestCount = 1;
                        for (int i = 1; i <= 6752; i++)
                        {
                            var requestParameters = new RequestParametersV2
                            {
                                ApiKey = "71RqY1iB-mPYtst-k4vV",
                                Query = "*",
                                SourceCode = "UN",
                                PerPage = 300,
                                Page = i
                            };
                            var fileName = requestParameters.SourceCode + "_" + requestParameters.Page + ".json";
                            var fullPath = Path.Combine(@"A:\DEVOPS\QUANDL-DATASETS", fileName);

                            if(File.Exists(fullPath)) continue;
                            
                            BackgroundJob.Schedule(() => new GetV2().GetJsonResponseV2(requestParameters, fullPath), TimeSpan.FromMilliseconds(10 * requestCount));
                            requestCount = requestCount + 1;

                        }
                    }
                }
            }
        }
    }
}