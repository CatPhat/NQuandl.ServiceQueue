using System;
using System.IO;
using NQuandl.Client.Domain.Queries;
using NQuandl.Client.Domain.RequestParameters;
using NQuandl.ServiceQueue.CompositionRoot;

namespace NQuandl.ServiceQueue
{
    public class GetV2
    {
        public string GetJsonResponseV2(RequestParametersV2 parameters, string fullPath)
        {
            var queries = Bootstrapper.GetQueries();
            
            var result = queries.Execute(new RequestString(parameters)).Result;

            File.WriteAllText(fullPath, result);
            Console.WriteLine("File saved: " + fullPath);
            return result;
        }
    }
}