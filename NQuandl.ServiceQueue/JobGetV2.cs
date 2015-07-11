using System;
using NQuandl.Client.Domain.Queries;
using NQuandl.Client.Domain.RequestParameters;
using NQuandl.ServiceQueue.CompositionRoot;

namespace NQuandl.ServiceQueue
{
    public class GetV2
    {
        public string GetJsonResponseV2(RequestParametersV2 parameters)
        {
            var queries = Bootstrapper.GetQueries();

            
            var result = queries.Execute(new RequestString(parameters)).Result;
            
            //File.WriteAllText(parameters.FullPath, result);
            //Console.WriteLine("File saved: " + parameters.FullPath);
            return result;
        }
    }
}