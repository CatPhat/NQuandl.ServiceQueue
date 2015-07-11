//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Hangfire;
//using Hangfire.States;

//namespace NQuandl.QConsole.Jobs
//{
//    public static class ManageRequestJobs
//    {
//        private static readonly Queue<GetV2Parameters> _parameters;

//        static ManageRequestJobs()
//        {
//            _parameters = GetParameters();
//        }

        
//        public static bool RequestsRemaining
//        {
//            get { return _parameters.Any(); }
//        }

//        public static JobInfo EnqueueJob()
//        {
//            if (!RequestsRemaining) return null;
//            var jobParameters = _parameters.Dequeue();
//            var job = Enqueue(jobParameters);
//            return job;
//        }



//        private static Queue<GetV2Parameters> GetParameters()
//        {
//            const string fileDirectory = @"A:\DEVOPS\QUANDL-DATASETS";
//            var sourceCode = "UN";

//            var parameters = new Queue<GetV2Parameters>();

//            for (int i = 1; i <= 100; i++)
//            {
//                var fileName = string.Format("{0}_{1}", sourceCode, i);
//                var fullPath = string.Format(@"{0}\{1}", fileDirectory, fileName);

//                parameters.Enqueue(new GetV2Parameters
//                {
//                    FileName = fileName,
//                    FullPath = fullPath,
//                    SourceCode = sourceCode,
//                    Page = i
//                });
//            }

//            return parameters;
//        }


//        private static JobInfo Enqueue(GetV2Parameters parameters)
//        {

//            if (CheckFiles.CheckIfFileExists(parameters.FullPath)) return null;

//            var jobId = BackgroundJob.Enqueue(() => new GetV2().GetJsonResponseV2(parameters));

//            return new JobInfo
//            {
//                JobId = jobId,
//                JobStateDateTime = DateTime.UtcNow,
//                JobState = EnqueuedState.StateName
//            };
//        }


//        private static JobInfo Schedule(GetV2Parameters parameters, double delay)
//        {
            
//            if (CheckFiles.CheckIfFileExists(parameters.FullPath)) return null;

//            var jobId = BackgroundJob.Schedule(() => new GetV2().GetJsonResponseV2(parameters),
//                TimeSpan.FromMilliseconds(delay));

//            return new JobInfo
//            {
//                JobId = jobId,
//                JobStateDateTime = DateTime.Now,
//                JobState = EnqueuedState.StateName
//            };
//        }

       


//        //public static void ScheduleJobs()
//        //{
//        //    var requestCount = 1;
//        //    foreach (var parameter in _parameters)
//        //    {
//        //        var scheduledJob = Schedule(_parameters.Dequeue(), 300);
//        //        if (scheduledJob == null) continue;
//        //        requestCount = requestCount + 1;
//        //    }
//        //}

//        //public static JobInfo ScheduleJob()
//        //{
//        //    if (!_parameters.Any()) return null;

//        //    var scheduledParameter = Schedule(_parameters.Dequeue(), 300);
//        //    return scheduledParameter;
//        //}
//    }
//}