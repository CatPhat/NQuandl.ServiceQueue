using System;
using System.Data;
using System.Timers;

namespace NQuandl.QConsole.Jobs
{
    public class JobInfo
    {
        public string JobId { get; set; }
        public string JobState { get; set; }
        public DateTime JobStateDateTime { get; set; }
        
    }
}