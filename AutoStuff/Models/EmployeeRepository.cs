using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class EmployeeRepository : Repository<Employee>
    {
        private static EmployeeRepository _instance;
        private EmployeeRepository() { }

        public static EmployeeRepository Instance
        {
            get {
                if (_instance == null) {
                    _instance = new EmployeeRepository();
                    _instance.Insert(
                        new Employee() { 
                            ID=23473, AvailableShiftsNotificationSmsOptIn = true, 
                            PhoneNumber = "[REPLACE_WITH_A_VALID_PHONE_NUMBER]" 
                        });
                }

                return _instance;
            }
        }
    }
}