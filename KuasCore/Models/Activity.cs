using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Activity
    {
        public string Activity_ID { get; set; }

        public string Subject { get; set; }

        public string Host { get; set; }

        public string Assist { get; set; }

        public string Location { get; set; }

        public string Detail { get; set; }

        public DateTime Date_Start { get; set; }

        public DateTime Date_End { get; set; }

        public override string ToString()
        {
            return "Activity: Activity_ID = " + Activity_ID + ", Subject = " + Subject +  ".";
        }
    }
}
