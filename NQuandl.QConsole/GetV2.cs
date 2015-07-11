//using System;
//using System.Diagnostics;
//using NQuandl.Client.CompositionRoot;
//using NQuandl.Client.Domain.Queries;
//using NQuandl.Client.Domain.RequestParameters;

//namespace NQuandl.QConsole
//{
//    public class GetV2
//    {
//        public string GetJsonResponseV2(GetV2Parameters parameters)
//        {
//            if (CheckFiles.CheckIfFileExists(parameters.FullPath))
//            {
//                return null;
//            }

//            var queries = Bootstapper.GetQueryProcessor();
//            var requestParameters = new RequestParametersV2
//            {
//                ApiKey = "71RqY1iB-mPYtst-k4vV",
//                Query = "*",
//                SourceCode = parameters.SourceCode,
//                PerPage = 300,
//                Page = parameters.Page
//            };

//            var stopwatch = new Stopwatch();
//            stopwatch.Start();
//            var result = queries.Execute(new RequestString(requestParameters)).Result;
//            stopwatch.Stop();
//            Console.WriteLine("[ + ] Request {0} took {1} to complete.", parameters.FileName, stopwatch.Elapsed);


//            //File.WriteAllText(parameters.FullPath, result);
//            //Console.WriteLine("File saved: " + parameters.FullPath);
//            return result;
//        }
//    }
//}