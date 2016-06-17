using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestLabor.Classes;
using System.Reflection;
using TestLabor.Entity;
using TestLabor.Windows;

namespace TestLabor.Controls
{
    /// <summary>
    /// Interaction logic for AdministrativeViewControl.xaml
    /// </summary>
    public partial class AdministrativeViewControl : UserControl
    {
        #region Variables

        /// <summary>
        /// The class to access all of the data
        /// </summary>
        private DataClass _dataAccessClass;

        #endregion

        #region Control Events

        /// <summary>
        /// Constructor
        /// </summary>
        public AdministrativeViewControl(DataClass dataAccessClass)
        {
            InitializeComponent();

            //  Sets the passed parameters
            _dataAccessClass = dataAccessClass;
        }

        /// <summary>
        /// The control entry point
        /// </summary>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Loops through the employees to add them to the list
                foreach (EntityEmployee emp in _dataAccessClass.EmployeesList)
                {
                    //  Builds the instance of the employee card
                    EmployeeCardControl card = new EmployeeCardControl(_dataAccessClass, emp);

                    //  Connects the events 
                    card.EmployeeSelectionMade += CatchEventEmployeeSelectionMade;

                    //  Adds the employee to the control for display
                    lboEmployees.Items.Add(card);
                }

                //  Defaults the run analysis button
                AdjustRunDutyHourAnalysisButton();

            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Selects all employees
        /// </summary>
        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Loops through the employees
                foreach (EntityEmployee emp in _dataAccessClass.EmployeesList)
                {
                    //  Sets the flag
                    emp.IsSelected = true;
                }

                //  Sets the run button
                AdjustRunDutyHourAnalysisButton();


            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Removes the selection from all employees
        /// </summary>
        private void btnSelectNone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Loops through the employees
                foreach (EntityEmployee emp in _dataAccessClass.EmployeesList)
                {
                    //  Sets the flag
                    emp.IsSelected = false;
                }

                //  Sets the run button
                AdjustRunDutyHourAnalysisButton();


            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Runs the Duty Hour Analysis on the selected employees
        /// </summary>
        private void btnRunDutyHourAnalysis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  
                //  TODO: Consider throwing this to a different thread and showing an animation
                //        to prevent the app from seeming to stall
                //  

                //  Builds the list of selected employees
                List<EntityEmployee> lstSelectedEmployees = new List<EntityEmployee>();
                lstSelectedEmployees = (from o in _dataAccessClass.EmployeesList where o.IsSelected == true select o).ToList();

                //  Creates the instance of the analysis class
                DutyHourAnalysis analysis = new DutyHourAnalysis(_dataAccessClass, lstSelectedEmployees);

                //  Processes the selected employees shift records
                List<EntityDutyHourAnalysisResult> lstDutyHourAnalysisResults = analysis.ProcessDutyHourAnalysisForSelectedEmployees();

                //  Creates the analysis results window instance
                DutyHourAnalysisResultsDisplay window = new DutyHourAnalysisResultsDisplay(_dataAccessClass, lstDutyHourAnalysisResults);

                //  Sets the window properties
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.WindowStyle = WindowStyle.ToolWindow;

                //  Fades
                ReturnMainWindowInstance().FadeMainWindowForChildWindow(true);

                //  Shows the window
                window.ShowDialog();

                //  Fades
                ReturnMainWindowInstance().FadeMainWindowForChildWindow(false);

            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Catches the event that an employee selection was made and calls the necessary method
        /// </summary>
        private void CatchEventEmployeeSelectionMade(object sender, EventArgs e)
        {
            try
            {
                //  Calls the method to set the button
                AdjustRunDutyHourAnalysisButton();

            }
            catch (Exception ex)
            {
                //  Nothing for now
            }
        }

        /// <summary>
        /// Turns the run button off and on based on selection criteria
        /// </summary>
        private void AdjustRunDutyHourAnalysisButton()
        {
            try
            {
                //  Grabs the count of selected employees
                int iCount = (from o in _dataAccessClass.EmployeesList where o.IsSelected == true select o).Count();

                //  Is any employee selected
                if (iCount > 0)
                {
                    //  Enables the button
                    btnRunDutyHourAnalysis.IsEnabled = true;
                }
                else
                {
                    //  Deactivates the button
                    btnRunDutyHourAnalysis.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                //  Calls the error alert method
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

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
    }
}
