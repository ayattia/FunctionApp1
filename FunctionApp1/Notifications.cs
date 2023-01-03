using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public class Notifications
    {
        public int NotificationID { get; set; }
        public int ClientID { get; set; }
        public int AttemptsCount { get; set; }
        public DateTime LastAttempt { get; set; }
        public DateTime NotificationSentAt { get; set; }
    }
}
