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
using TestLabor.Controls;
using System.Windows.Media.Animation;

namespace TestLabor
{
    /// <summary>
    /// MainWindow Class
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        /// <summary>
        /// The data access class object
        /// </summary>
        private DataClass dataAccessClass;

        /// <summary>
        /// Flag that indicates that the main view is faded or not
        /// </summary>
        public bool IsMainViewFaded = false;

        #endregion

        #region WindowEvents

        /// <summary>
        /// Window Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window entry point
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Creates the instance of the data class
                try
                {
                    //  Builds the instance of the data access class
                    dataAccessClass = new DataClass();

                }
                catch (Exception exDC)
                {
                    //  Reports the error
                    MessageBox.Show(string.Format(@"The Data Class encountered an error - {0}", exDC.Message), "Data Class Error", MessageBoxButton.OK);

                    //  Exits the application
                    Application.Current.Shutdown();
                }

                //  Sets the business day
                lblBusinessDay.Text = string.Format(@"Business Date: {0}", DateTime.Now.ToShortDateString());

                //  Determines the role that needs to run
                if(dataAccessClass.CurrentSystemRole == DataClass.ApplicationRole.Admin)
                {
                    //  Sets the label
                    lblRoleName.Text = "Administrative View";

                    //  Loads the admin control
                    AdministrativeViewControl control = new AdministrativeViewControl(dataAccessClass);
                    panelMainBoard.Children.Clear();
                    panelMainBoard.Children.Add(control);
                }
                else
                {
                    //  Sets the label
                    lblRoleName.Text = "Resident View";

                    //  Pulls mickey for the demos sake
                    Entity.EntityEmployee employee = (from o in dataAccessClass.EmployeesList where o.Id == 1 select o).FirstOrDefault();

                    //  Loads the resident control (Defaults to a specific resident for the demo)
                    EmployeeScheduleControl control = new EmployeeScheduleControl(dataAccessClass, employee);
                    panelMainBoard.Children.Clear();
                    panelMainBoard.Children.Add(control);
                }                
            }
            catch (Exception ex)
            {
                //  Reports the error
                dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion

        #region Menu Clicks

        /// <summary>
        /// Closes the application
        /// </summary>
        private void miExitApplication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Closes the application
                Application.Current.Shutdown();

            }
            catch (Exception ex)
            {
                //  Reports the error
                dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }





        #endregion

        #region Methods 

        /// <summary>
        /// Fades the main window when a child window is open
        /// </summary>
        public void FadeMainWindowForChildWindow(bool openWindow)
        {
            try
            {
                //  Is this to open or close a window
                if(openWindow == true)
                {
                    //  Open window
                    //  Is the window already faded
                    if (IsMainViewFaded == false)
                    {
                        //  Fade
                        ((Storyboard)this.Resources["Storyboard_OpenChildWindow"]).Begin();

                        //  Sets the flag
                        IsMainViewFaded = true;
                    }
                }
                else
                {
                    //  Close window
                    //  Reverse Fade
                    ((Storyboard)this.Resources["Storyboard_CloseChildWindow"]).Begin();

                    //  Sets the flag
                    IsMainViewFaded = false;
                }
            }
            catch (Exception ex)
            {
                //  Reports the error
                dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }



        #endregion


    }
}
