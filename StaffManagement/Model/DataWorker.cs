using StaffManagement.View;
using System;
using System.Collections.Generic;
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

    }
}
