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
using System.Windows.Shapes;
using System.Reflection;
using TestLabor.Entity;
using TestLabor.Classes;

namespace TestLabor.Windows
{
    /// <summary>
    /// Interaction logic for DutyHourAnalysisResultsDisplay.xaml
    /// </summary>
    public partial class DutyHourAnalysisResultsDisplay : Window
    {
        #region Variables

        /// <summary>
        /// The class that contains the data and messaging
        /// </summary>
        private DataClass _dataAccessClass;

        /// <summary>
        /// The list of the Duty Hour Analysis results
        /// </summary>
        private List<EntityDutyHourAnalysisResult> _lstResults;

        #endregion

        #region Window Events

        /// <summary>
        /// Constructor
        /// </summary>
        public DutyHourAnalysisResultsDisplay(DataClass dataAccessClass, List<EntityDutyHourAnalysisResult> results)
        {
            InitializeComponent();

            //  Sets the passed parameters
            _dataAccessClass = dataAccessClass;
            _lstResults = results; 
        }

        /// <summary>
        /// Window entry point
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //
                //  TODO: Add an option to allow the user to select if they want to see
                //        everything or only failures
                //

                //  Generates a list of only failures (for now)
                List<EntityDutyHourAnalysisResult> lstFailures = new List<EntityDutyHourAnalysisResult>();
                lstFailures = (from o in _lstResults where o.IsFailure == true select o).ToList();

                //  Binds the data to the grid
                datagridResults.ItemsSource = null;
                datagridResults.ItemsSource = lstFailures;

                //  Determines what UI to show
                if (lstFailures.Count >= 1)
                {
                    //  There were failures. Show the grid
                    datagridResults.Visibility = Visibility.Visible;
                    datagridResults.IsEnabled = true;
                    lblAlert.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //  No failures. Hide the grid
                    datagridResults.Visibility = Visibility.Collapsed;
                    datagridResults.IsEnabled = false;
                    lblAlert.Text = "No failures found";
                    lblAlert.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                //  Reports the error
                _dataAccessClass.PresentErrorMessage(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion
    }
}
