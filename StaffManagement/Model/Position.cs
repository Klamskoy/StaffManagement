﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    internal class Position
    {
        private int _id;
        private string _name;
        private int _departmentId;
        private Department _department;
        private int _salary;
        private int _maxCountOfStaff;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int MaxCountOfStaff { get; set; }
        public int DepartmentId { get; set; }
        internal Department Department { get; set; }

       [NotMapped]
       public int CurrentCount
        {
            get
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    return db.Employees.Where(u => u.PositionId == Id).Count();
                }
            }
        }

        [NotMapped]
        public Department GetDepartmentByIdProp
        {
            get
            {
                return DataWorker.GetDepartmentById(DepartmentId);
            }
        }
    }
}
