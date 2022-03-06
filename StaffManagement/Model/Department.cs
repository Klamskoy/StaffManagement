using System;
using System.Collections.Generic;
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
    }
}
