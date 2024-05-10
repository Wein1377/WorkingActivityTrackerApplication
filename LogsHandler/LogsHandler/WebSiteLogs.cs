using System;

namespace LogsHandler
{
    public class WebSiteLogs
    {
        public int userdId { get; set; }
        public string url { get; set; }
        public DateTime visitTime { get; set; } = DateTime.Now;
        public string type { get; set; }

        public WebSiteLogs(int UserId, string Url, string Type)
        {
            this.userdId = UserId;
            this.url = Url;
            this.type = Type;
        }
    }
}
