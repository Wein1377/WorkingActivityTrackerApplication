using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    class WorkingMonitor
    {
        [DisplayName("Имя")]
        public string firstName { get; set; }
        [DisplayName("Фамилия")]
        public string lastName { get; set; }
        [DisplayName("Дата смены")]
        public string date { get; set; }
        [DisplayName("Начало смены")]
        public string startDate { get; set; }
        [DisplayName("Конец смены")]
        public string endDate { get; set; }
        [DisplayName("Пролжительность смены")]
        public string duration { get; set; }
        [DisplayName("Потери времени(мин.)")]
        public int timeLoss { get; set; }

        public WorkingMonitor(string FirstName, string LastName, DateTime StartDate, DateTime EndDate, int TimeLoss)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.date = StartDate.ToString("d");
            this.startDate = StartDate.ToString("h:mm:s");
            this.endDate = EndDate.ToString("h:mm:s");
            this.duration = (EndDate - StartDate).Duration().ToString();
            this.timeLoss = TimeLoss;
        }
    }
}
