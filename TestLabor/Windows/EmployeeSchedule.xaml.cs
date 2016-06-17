using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using TestLabor.Classes;
using TestLabor.Entity;
using TestLabor.Controls;

namespace TestLabor.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeSchedule.xaml
    /// </summary>
    public partial class EmployeeSchedule : Window
    {
        #region Variables

        /// <summary>
        /// The class to access all of the data
        /// </summary>
        private DataClass _dataAccessClass;

        /// <summary>
        /// The employee to display
        /// </summary>
        private EntityEmployee _employee;

        #endregion

        #region Window Events

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeSchedule(DataClass dataAccessClass, EntityEmployee employee)
        {
            InitializeComponent();

            //  Sets the passed parameters
            _dataAccessClass = dataAccessClass;
            _employee = employee;
        }

        /// <summary>
        /// Window entry point
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Sets the employees name
                Title = string.Format(@"{0} - Scheduled Shifts", _employee.FullName);

                //  Creates the instance of the control
                EmployeeScheduleControl control = new EmployeeScheduleControl(_dataAccessClass, _employee);

                //  Sets the control
                panelMain.Children.Clear();
                panelMain.Children.Add(control);
            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


    }
}
