using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TestLabor.Classes;
using TestLabor.Entity;
using TestLabor.Windows;

namespace TestLabor.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeScheduleControl.xaml
    /// </summary>
    public partial class EmployeeScheduleControl : UserControl
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
        public EmployeeScheduleControl(DataClass dataAccessClass, EntityEmployee employee)
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
                //  Binds the employee data
                panelHeader.DataContext = _employee;

                //  Pulls the schedule data for the employee
                List<EntityShift> lstShifts = (from o in _dataAccessClass.ShiftsList where o.EmployeeId == _employee.Id select o).ToList();

                //  Binds the shifts to the grid
                datagridSchedules.ItemsSource = null;
                datagridSchedules.ItemsSource = lstShifts.OrderByDescending(s => s.StartDateTime);


            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance of the main window
        /// </summary>
        private MainWindow ReturnMainWindowInstance()
        {
            try
            {
                Window w = Application.Current.MainWindow;
                return (MainWindow)w;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Runs the duty hour analysis
        /// </summary>
        private void btnRunDutyHourAnalysis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Builds the list of selected employees
                List<EntityEmployee> lstEmployees = new List<EntityEmployee>();
                lstEmployees.Add(_employee);

                //  Creates the instance of the analysis class
                DutyHourAnalysis analysis = new DutyHourAnalysis(_dataAccessClass, lstEmployees);

                //  Processes the selected employees shift records
                List<EntityDutyHourAnalysisResult> lstDutyHourAnalysisResults = analysis.ProcessDutyHourAnalysisForSelectedEmployees();

                //  Creates the analysis results window instance
                DutyHourAnalysisResultsDisplay window = new DutyHourAnalysisResultsDisplay(_dataAccessClass, lstDutyHourAnalysisResults);

                //  Sets the window properties
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.WindowStyle = WindowStyle.ToolWindow;

                //  Fades
                //  Is it already faded
                bool bThisFunctionFaded = false;
                if (ReturnMainWindowInstance().IsMainViewFaded == false)
                {
                    //  Fade it
                    ReturnMainWindowInstance().FadeMainWindowForChildWindow(true);

                    //  Sets the flag
                    bThisFunctionFaded = true;
                }

                //  Shows the window
                window.ShowDialog();

                //  Fades
                //  Is it already faded
                if (bThisFunctionFaded == true)
                {
                    //  Unfade it
                    ReturnMainWindowInstance().FadeMainWindowForChildWindow(false);
                }

            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            #endregion


        }
    }
}
