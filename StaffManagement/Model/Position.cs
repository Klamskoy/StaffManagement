using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    internal class Position
    {
        private int _id;
        private string _name;
        private Department _department;
        private int _salary;
        private int _maxCountOfStaff;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int MaxCountOfStaff { get; set; }
        internal Department Department { get; set; }
    }
}
