using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region ADD/EDIT WINDOWS OPENING COMMANDS
        private RelayCommand _showAddNewEmployee;
        public RelayCommand ShowAddNewEmployee
        {
            get
            {
                return _showAddNewEmployee ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowAddNewEmployeeWindow();
                }
                );
            }
        }

        private RelayCommand _showAddNewPosition;
        public RelayCommand ShowAddNewPosition
        {
            get
            {
                return _showAddNewPosition ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowAddNewPositionWindow();
                }
                );
            }
        }

        private RelayCommand _showAddNewDepartment;
        public RelayCommand ShowAddNewDepartment
        {
            get
            {
                return _showAddNewDepartment ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowAddNewDepartmentWindow();
                }
                );
            }
        }

        private RelayCommand _showEditEmployee;
        public RelayCommand ShowEditEmployee
        {
            get
            {
                return _showEditEmployee ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowEditEmployeeWindow();
                }
                );
            }
        }

        private RelayCommand _showEditPosition;
        public RelayCommand ShowEditPosition
        {
            get
            {
                return _showEditPosition ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowEditPositionWindow();
                }
                );
            }
        }

        private RelayCommand _showEditDepartment;
        public RelayCommand ShowEditDepartment
        {
            get
            {
                return _showEditDepartment ?? new RelayCommand(obj =>
                {
                    DataWorker.ShowEditDepartmentWindow();
                }
                );
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion




    }
}
