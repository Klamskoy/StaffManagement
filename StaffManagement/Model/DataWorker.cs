using StaffManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffManagement.Model
{
    internal static class DataWorker
    {

        #region ADD/EDIT WINDOWS OPENING

        public static void ShowAddNewEmployeeWindow()
        {
            AddNewEmployeeWindow wnd = new AddNewEmployeeWindow();
            wnd.ShowDialog();
        }
        public static void ShowAddNewPositionWindow()
        {
            AddNewPositionWindow wnd = new AddNewPositionWindow();
            wnd.ShowDialog();
        }
        public static void ShowAddNewDepartmentWindow()
        {
            AddNewDepartmentWindow wnd = new AddNewDepartmentWindow();
            wnd.ShowDialog();
        }
        public static void ShowEditEmployeeWindow()
        {
            EditEmployeeWindow wnd = new EditEmployeeWindow();
            wnd.ShowDialog();
        }
        public static void ShowEditPositionWindow()
        {
            EditPositionWindow wnd = new EditPositionWindow();
            wnd.ShowDialog();
        }
        public static void ShowEditDepartmentWindow()
        {
            EditDepartmentWindow wnd = new EditDepartmentWindow();
            wnd.ShowDialog();
        }

        #endregion

        #region METHODS TO ADD
        public static void AddNewDepartment(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department newDepartment = new Department() { Name = name };
                db.Departments.Add(newDepartment);
                db.SaveChanges();

            }
        }

        public static void AddNewPosition(string name, int salary, int maxStaff, Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position newPosition = new Position() { Name = name, Salary = salary, MaxCountOfStaff = maxStaff, Department = department, DepartmentId = department.Id };
                db.Positions.Add(newPosition);
                db.SaveChanges();
            }
        }

        public static void AddNewEmployee(string name, string surname, string patronymic, Position position)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.Employees.Where(u => u.PositionId == position.Id).Count() < db.Positions.Where(u => u.Id == position.Id).First().MaxCountOfStaff )
                {
                    Employee newEmployee = new Employee() { Name = name, Surname = surname, Patronymic = patronymic, Position = position, PositionId = position.Id };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Штат сотрудников на данную должность полон", "Ошибка");
                }

            }
        }
        #endregion

        #region METHODS TO DELETE
        public static void DeleteDepartment(Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }
        }

        public static void DeletePosition(Position position)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
            }
        }

        public static void DeleteEmployee(Employee employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        #endregion

        #region METHODS TO EDIT
        public static void EditDepartment(Department selectedDepartment, string newName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.Where(u => u.Name == selectedDepartment.Name).FirstOrDefault();
                department.Name = newName;
                db.SaveChanges();
            }
        }

        public static void EditPosition(Position selectedPosition, string newName, int newSalary, int newMaxStaff, int newDepartmentId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.Where(u => u.Name == selectedPosition.Name).FirstOrDefault();
                position.Name = newName;
                position.Salary = newSalary;
                position.MaxCountOfStaff = newMaxStaff;
                position.DepartmentId = newDepartmentId;
                db.SaveChanges();
            }
        }

        public static void EditEmployee(Employee selectedEmployee, string newName, string newSurname, string newPatronymic, int newPositionId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = db.Employees.Where(u => u.Name == selectedEmployee.Name).FirstOrDefault();
                employee.Name = newName;
                employee.Surname = newSurname;
                employee.Patronymic = newPatronymic;
                employee.PositionId = newPositionId;
                db.SaveChanges();
            }
        }
        #endregion

        public static List<Employee> GetAllEmployees()
        {
            var result = new List<Employee>();

            using(ApplicationContext db = new ApplicationContext())
            { 
                result = db.Employees.ToList();
            }

            return result;
        }

        public static List<Position> GetAllPositions()
        {
            var result = new List<Position>();
            using(ApplicationContext db = new ApplicationContext())
            {
                result = db.Positions.ToList();
            }

            return result;
        }

        public static List<Department> GetAllDepartments()
        {
            var result = new List<Department>();
            using (ApplicationContext db = new ApplicationContext())
            {
                result = db.Departments.ToList();
            }

            return result;
        }

        public static Position GetPositionById(int id)
        {
            Position res;
            using(ApplicationContext db = new ApplicationContext())
            {
                res = db.Positions.FirstOrDefault(x => x.Id == id);
                
            }
            return res;
        }

        public static Department GetDepartmentById(int id)
        {
            Department res;
            using(ApplicationContext db=  new ApplicationContext())
            {
                res = db.Departments.FirstOrDefault(x => x.Id == id);
            }
            return res;
        }



    }
}
