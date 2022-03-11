using StaffManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void AddNewDepartment(string name)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Department department = new Department() { Name = name };
                db.Departments.Add(department);
                
                db.SaveChanges();
                
            }
        }

    }
}
