using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class OpenShiftsViewModel
    {
        ShiftRepository _shiftRepository;

        public OpenShiftsViewModel()
        {
            _shiftRepository = ShiftRepository.Instance;
        }

        public List<OpenShiftGroup> GroupedOpenShifts { 
            get 
            {
                var groupedOpenShifts = from s in _shiftRepository.SelectOpen
                                        group s by s.StartTime.Date into g
                                        select new OpenShiftGroup() { StartDate = g.Key, Shifts = g.ToList() };
                return groupedOpenShifts.ToList();
            } 
        }
    }

    public class OpenShiftGroup {
        public DateTime StartDate { get; set; }
        public IEnumerable<Shift> Shifts { get; set; }
    }
}