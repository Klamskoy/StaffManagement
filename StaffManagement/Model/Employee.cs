using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.Model
{
    internal class Employee
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private int _positionId;
        private Position _position;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int PositionId { get; set; }
        internal Position Position { get; set; }
    }
}
