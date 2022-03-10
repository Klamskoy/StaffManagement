using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    internal class Department
    {
        private int _id;
        private string _name;
        private List<Position> _positions;

        public int Id { get; set; }
        public string Name { get; set; }
        internal List<Position> Positions { get; set; }

        [NotMapped]
        public int PositionCount
        {
            get
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    return db.Positions.Count(u => u.DepartmentId == Id);
                    
                }
            } 
        }
    }
}
