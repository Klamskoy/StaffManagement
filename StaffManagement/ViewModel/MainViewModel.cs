using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffManagement.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public string NewDepartmentName { get; set; }
        public string NewPositionName { get; set; }
        public int NewPositionSalary { get; set; }
        public int NewPositionMaxStaff { get; set; }
        public Department NewPositionDepartment { get; set; }
        public string NewEmployeeName { get; set; }
        public string NewEmployeeSurname { get; set; }
        public string NewEmployeePatronymic { get; set; }
        public Position NewEmployeePosition { get; set; }

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
                    NewDepartmentName = "";
                    DataWorker.ShowEditDepartmentWindow();
                }
                );
            }
        }

        #endregion

        private List<Employee> _allEmployees = DataWorker.GetAllEmployees();

        public List<Employee> AllEmployees
        {
            get { return _allEmployees; }
            set
            {
                _allEmployees = value;
                NotifyPropertyChanged("AllEmployees");
            }
        }

        private List<Position> _allPositions = DataWorker.GetAllPositions();
        public List<Position> AllPositions
        {
            get { return _allPositions; }
            set
            {
                _allPositions = value;
                NotifyPropertyChanged("AddPositions");
            }
        }

        private List<Department> _allDepartments = DataWorker.GetAllDepartments();
        public List<Department> AllDepartments
        {
            get { return _allDepartments; }
            set
            {
                _allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                NotifyPropertyChanged("SelectedDepartment");
            }
        }

        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                _selectedPosition = value;
                NotifyPropertyChanged("SelectedPosition");
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged("SelectedEmployee");
            }
        }

        #region COMMANDS TO DELETE 
        private RelayCommand _deleteDepartment;
        public RelayCommand DeleteDepartment
        {
            get
            {
                return _deleteDepartment ?? new RelayCommand(obj =>
                {
                    if(SelectedDepartment == null)
                    {
                        DeleteDepartment.CanExecute(false);
                    }
                    else
                    {
                        DataWorker.DeleteDepartment(SelectedDepartment);
                        UpdateAllListViews();
                    }
                    
                }
                );
            }
        }

        private RelayCommand _deletePosition;
        public RelayCommand DeletePosition
        {
            get
            {
                return _deletePosition ?? new RelayCommand(obj =>
                {
                    DataWorker.DeletePosition(SelectedPosition);
                    UpdateAllListViews();
                }
                );
            }
        }

        private RelayCommand _deleteEmployee;
        public RelayCommand DeleteEmployee
        {
            get
            {
                return _deleteEmployee ?? new RelayCommand(obj =>
                {

                    DataWorker.DeleteEmployee(SelectedEmployee);
                    UpdateAllListViews();
                }
                );
            }
        }

        #endregion

        #region COMMANDS TO ADD
        private RelayCommand _addNewDepartmentCommand;
        public RelayCommand AddNewDepartmentCommand
        {
            get
            {
                return _addNewDepartmentCommand ?? new RelayCommand(obj =>
                 {
                     DataWorker.AddNewDepartment(NewDepartmentName);
                     UpdateAllListViews();
                 }
                );
            }
        }

        private RelayCommand _addNewPositionCommand;
        public RelayCommand AddNewPositionCommand
        {
            get
            {
                return _addNewPositionCommand ?? new RelayCommand(obj =>
                {
                    DataWorker.AddNewPosition(NewPositionName, NewPositionSalary, NewPositionMaxStaff, NewPositionDepartment);
                    UpdateAllListViews();
                }
                );
            }
        }

        private RelayCommand _addNewEmployeeCommand;
        public RelayCommand AddNewEmployeeCommand
        {
            get
            {
                return _addNewEmployeeCommand ?? new RelayCommand(obj =>
                {
                    DataWorker.AddNewEmployee(NewEmployeeName, NewEmployeeSurname, NewEmployeePatronymic, NewEmployeePosition);
                    UpdateAllListViews();
                }
                );
            }
        }

        #endregion

        #region COMMANDS TO EDIT
        private RelayCommand _editDepartmentCommand;
        public RelayCommand EditDepartmentCommand
        {
            get
            {
                return _editDepartmentCommand ?? new RelayCommand(obj =>
                {
                    if(SelectedDepartment == null)
                    {
                        EditDepartmentCommand.CanExecute(false);
                        MessageBox.Show("Выберите отдел!", "Ошибка");
                    }

                    else
                    {

                        DataWorker.EditDepartment(SelectedDepartment, NewDepartmentName);
                        UpdateAllListViews();
                        NewDepartmentName = "";
                    }
                }
                );
            }
        }

        private RelayCommand _editPositionCommand;
        public RelayCommand EditPositionCommand
        {
            get
            {
                return _editPositionCommand ?? new RelayCommand(obj =>
                {
                    if(SelectedPosition == null)
                    {
                        EditPositionCommand.CanExecute(false);
                        MessageBox.Show("Выберите позицию!", "Ошибка");
                    }
                    else
                    {
                        DataWorker.EditPosition(SelectedPosition, NewPositionName, NewPositionSalary, NewPositionMaxStaff, NewPositionDepartment);
                        UpdateAllListViews();
                        NewPositionName = "";
                        NewPositionSalary = 0;
                        NewPositionMaxStaff = 0;
                    }
                }
                );
            }
        }

        private RelayCommand _editEmployeeCommand;
        public RelayCommand EditEmployeeCommand
        {
            get
            {
                return _editEmployeeCommand ?? new RelayCommand(obj =>
                {

                }
                );
            }
        }

        #endregion
        public void UpdateAllListViews()
        {
            AllDepartments = DataWorker.GetAllDepartments();
            MainWindow.AllDepartmentsView.ItemsSource = null;
            MainWindow.AllDepartmentsView.Items.Clear();
            MainWindow.AllDepartmentsView.ItemsSource = AllDepartments;
            MainWindow.AllDepartmentsView.Items.Refresh();

            AllPositions = DataWorker.GetAllPositions();
            MainWindow.AllPositionsView.ItemsSource = null;
            MainWindow.AllPositionsView.Items.Clear();
            MainWindow.AllPositionsView.ItemsSource = AllPositions;
            MainWindow.AllPositionsView.Items.Refresh();

            AllEmployees = DataWorker.GetAllEmployees();
            MainWindow.AllEmployeesView.ItemsSource = null;
            MainWindow.AllEmployeesView.Items.Clear();
            MainWindow.AllEmployeesView.ItemsSource = AllEmployees;
            MainWindow.AllEmployeesView.Items.Refresh();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       


    }
}
