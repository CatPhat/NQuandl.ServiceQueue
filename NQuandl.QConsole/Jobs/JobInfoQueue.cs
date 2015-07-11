//using System;
//using System.Collections.Concurrent;
//using System.Linq;
//using Hangfire.States;

//namespace NQuandl.QConsole.Jobs
//{
//    public static class JobInfoQueue
//    {
//        public static ConcurrentQueue<JobInfo> JobInfoConcurrentQueue;

//        public static string OldLastJobId { get; private set; }
//        public static string LastJobId { get; private set; }
//        public static DateTime? OldLastJobProccessStartTime { get; private set; }
//        public static DateTime? LastJobProccessStartTime { get; private set; }

//        static JobInfoQueue()
//        {
//            JobInfoConcurrentQueue = new ConcurrentQueue<JobInfo>();
//        }

//        public static void SetLastJobProcessStartTime(string jobId, DateTime jobTime)
//        {
//            if (!OldLastJobProccessStartTime.HasValue)
//            {
//                OldLastJobProccessStartTime = LastJobProccessStartTime;
//            }
//            if (LastJobId == jobId) return;

//            OldLastJobProccessStartTime = LastJobProccessStartTime;
//            OldLastJobId = LastJobId;
//            LastJobId = jobId;
//            LastJobProccessStartTime = jobTime;


//        }

//        public static bool ProcessTimeChanged
//        {
//            get
//            {
//                if (OldLastJobProccessStartTime.HasValue && LastJobProccessStartTime.HasValue)
//                {
//                    return OldLastJobProccessStartTime.Value == LastJobProccessStartTime.Value;
//                }

//                return false;
//            }
//        }



//        public static JobInfo GetLatestProcessedJobInfo()
//        {
//            var lastJob = JobInfoConcurrentQueue
//                .Where(x => x.JobState == ProcessingState.StateName)
//                .OrderByDescending(y => y.JobStateDateTime)
//                .FirstOrDefault();

//            return lastJob;
//        }
//    }
//}