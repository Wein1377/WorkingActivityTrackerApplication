using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProxyService
{
    public class WebSiteLogs
    {
        public int userId { get; set; }
        public string url { get; set; }
        public DateTime visitTime { get; set; } = DateTime.Now;
        public string type { get; set; }


        public WebSiteLogs(int UserId, string Url, string Type)
        {
            this.userId = UserId;
            this.url = Url;
            this.type = Type;
        }
    }
}
