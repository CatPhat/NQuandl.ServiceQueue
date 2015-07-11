using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQuandl.ServiceQueue.Models
{
    public class HttpUrlRequest
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}
