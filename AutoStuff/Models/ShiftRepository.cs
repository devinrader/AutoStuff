using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class ShiftRepository : Repository<Shift>
    {
        private static ShiftRepository _instance;
        private ShiftRepository() {}

        public static ShiftRepository Instance
        {
            get {
                if (_instance == null) {
                    _instance = new ShiftRepository();
                    _instance.Insert(new Shift() { ID = 52853, StartTime = new DateTime(2014, 6, 6, 8, 0, 0), EndTime = new DateTime(2014, 6, 6, 17, 0, 0), AssignedEmployee = null });
                    _instance.Insert(new Shift() { ID = 95328, StartTime = new DateTime(2014, 6, 6, 12, 0, 0), EndTime = new DateTime(2014, 6, 6, 17, 0, 0), AssignedEmployee = null });
                    _instance.Insert(new Shift() { ID = 75392, StartTime = new DateTime(2014, 6, 7, 8, 0, 0), EndTime = new DateTime(2014, 6, 7, 17, 0, 0), AssignedEmployee = null });
                    _instance.Insert(new Shift() { ID = 13283, StartTime = new DateTime(2014, 6, 8, 8, 0, 0), EndTime = new DateTime(2014, 6, 8, 17, 0, 0), AssignedEmployee = null });
                    _instance.Insert(new Shift() { ID = 85384, StartTime = new DateTime(2014, 6, 9, 8, 0, 0), EndTime = new DateTime(2014, 6, 9, 17, 0, 0), AssignedEmployee = null });
                }

                return _instance;
            }
        }

        public IEnumerable<Shift> SelectOpen
        {
            get
            {
                return this.Select().Where(s => s.AssignedEmployee == null);
            }
        }

        public override void Delete(int ID)
        {
            base.Delete(ID);


        }

        public override void Update(Shift entity)
        {
            var old = this.Select().Where(e => e.ID == entity.ID).FirstOrDefault();

            if (old != null)
            {
                old = entity;
            }
        }
    }
}