using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    class StopWordsLogs
    {
        [DisplayName("Имя")]
        public string firstName { get; set; }
        [DisplayName("Фамилия")]
        public string lastName { get; set; }
        [DisplayName("Дата смены")]
        public string date { get; set; }
        [DisplayName("Текст")]
        public string message { get; set; }
        public StopWordsLogs(string FirstName, string LastName, DateTime StartDate, string Message)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.date = StartDate.ToString("d");
            this.message = Message;
        }
    }
}
