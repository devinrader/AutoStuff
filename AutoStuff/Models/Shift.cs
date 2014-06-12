using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class Shift : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Employee AssignedEmployee { get; set; }
    }
}