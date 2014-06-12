using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class Employee : Entity
    {
        public string PhoneNumber { get; set; }

        public bool AvailableShiftsNotificationSmsOptIn { get; set; }
    }
}