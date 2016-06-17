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
using TestLabor.Entity;
using TestLabor.Classes;
using TestLabor.Windows;
using System.Reflection;

namespace TestLabor.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeCardControl.xaml
    /// </summary>
    public partial class EmployeeCardControl : UserControl
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

        #region Custom Events

        /// <summary>
        /// The event that signifies that an employee was clicked
        /// </summary>
        public event EventHandler EmployeeSelectionMade;

        #endregion

        #region Control Events

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCardControl(DataClass dataAccessClass, EntityEmployee employee)
        {
            InitializeComponent();

            //  Sets the passed parameters
            _dataAccessClass = dataAccessClass;
            _employee = employee;
        }

        /// <summary>
        /// Control entry point
        /// </summary>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Binds the employee to the grid
                panelData.DataContext = _employee;


            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


        #region Mouse Events

        /// <summary>
        /// The user click on the employee
        /// </summary>
        private void borderMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //  Sets the flag for selection on the employee
                _employee.IsSelected = !_employee.IsSelected;

                //  Fires the event that a selection was made
                OnEmployeeSelectionMade(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Show the mouse over color
        /// </summary>
        private void borderMain_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                //  Sets the mouse hover color
                borderMain.Background = new SolidColorBrush(Colors.AliceBlue);
                borderMain.BorderBrush = new SolidColorBrush(Colors.Gray);
                borderMain.BorderThickness = new Thickness(1, 1, 1, 1);

                //  Shows the employee schedule option
                btnSchedule.IsEnabled = true;
                btnSchedule.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Remove the mouse over color
        /// </summary>
        private void borderMain_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                //  Sets the mouse hover color
                borderMain.Background = new SolidColorBrush(Colors.Transparent);
                borderMain.BorderBrush = new SolidColorBrush(Colors.Transparent);
                borderMain.BorderThickness = new Thickness(0, 0, 0, 0);

                //  Hides the employee schedule option
                btnSchedule.IsEnabled = false;
                btnSchedule.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                //  Shows the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion

        #region Custom Event Methods

        /// <summary>
        /// Fires the event to Test the board status
        /// </summary>
        protected virtual void OnEmployeeSelectionMade(EventArgs e)
        {
            try
            {
                //  Creates the handler
                EventHandler handler = EmployeeSelectionMade;
                if(handler != null)
                {
                    //  Fires the event
                    handler(this, e);
                }
            }
            catch (Exception ex)
            {
                //  Don't do anything for now
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Shows the selected employees schedule
        /// </summary>
        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Creates the window instance
                EmployeeSchedule window = new EmployeeSchedule(_dataAccessClass, _employee);

                //  Sets the properties
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.WindowStyle = WindowStyle.ToolWindow;

                //  Fades the main window
                ReturnMainWindowInstance().FadeMainWindowForChildWindow(true);

                //  Shows the window
                window.ShowDialog();

                //  Reverse Fades the main window
                ReturnMainWindowInstance().FadeMainWindowForChildWindow(false);

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
    }
}
