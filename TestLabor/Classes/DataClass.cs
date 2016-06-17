using System;
using System.Collections.Generic;
using System.Windows;
using TestLabor.Entity;

namespace TestLabor.Classes
{
    /// <summary>
    /// DataClass Class
    /// </summary>
    public class DataClass
    {
        #region Variables

        /// <summary>
        /// The list of employees for the system
        /// </summary>
        private List<EntityEmployee> _lstEmployees = new List<EntityEmployee>();

        /// <summary>
        /// The list of employee shifts for the system
        /// </summary>
        private List<EntityShift> _lstShifts = new List<EntityShift>();

        /// <summary>
        /// The role that is running for the system
        /// </summary>
        private ApplicationRole _currentSystemRole;

        #endregion

        #region Enums

        /// <summary>
        /// The available running roles in the system
        /// </summary>
        public enum ApplicationRole
        {
            Admin,
            Resident
        };

        #endregion

        #region Properties

        /// <summary>
        /// Returns the list of employees as read only
        /// </summary>
        public List<EntityEmployee> EmployeesList { get { return _lstEmployees; } }

        /// <summary>
        /// Returns the list of employee shifts as ready only
        /// </summary>
        public List<EntityShift> ShiftsList { get { return _lstShifts; } }

        /// <summary>
        /// Returns the role that is currently running in the system
        /// </summary>
        public ApplicationRole CurrentSystemRole { get { return _currentSystemRole; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public DataClass()
        {
            try
            {
                //  Determines the system role
                if (Properties.Settings.Default.Role_IsAdmin == true)
                {
                    _currentSystemRole = ApplicationRole.Admin;
                }
                else
                {
                    _currentSystemRole = ApplicationRole.Resident;
                }

                //  Calls the method to load the demo data
                LoadAllData();


            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw ex;
            }
        }

        #endregion

        #region Init Methods

        /// <summary>
        /// Loads the classes data to show for the demo
        /// </summary>
        /// <remarks>All of this is to mock data for the demo</remarks>
        private void LoadAllData()
        {
            try
            {
                //  Loads the employee data
                LoadEmployeeData();

                //  Loads the shifts
                LoadEmployeeShifts();

            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw ex;
            }
        }

        /// <summary>
        /// Loads on the employee data
        /// </summary>
        private void LoadEmployeeData()
        {
            try
            {
                //  Loads the employees one by one 
                //  ** Note this is only for the demo. Typically this would be database driven data
                _lstEmployees.Add(new EntityEmployee(1, "Mickey", "Mouse", "Male", "11/18/1928", "Friendly Mouse", @"/TestLabor;component/Images/mickey.gif"));
                _lstEmployees.Add(new EntityEmployee(2, "Donald", "Duck", "Male", "09/06/1934", "Angry Duck", "/TestLabor;component/Images/donald.gif"));
                _lstEmployees.Add(new EntityEmployee(3, "Dumbo", "", "Male", "10/23/1941", "Flying Elephant", "/TestLabor;component/Images/dumbo.png"));
                _lstEmployees.Add(new EntityEmployee(4, "Eeoyre", "", "Male", "06/24/1926", "Mopey Donkey", "/TestLabor;component/Images/eeyore.gif"));
                _lstEmployees.Add(new EntityEmployee(5, "Genie", "", "Male", "03/17/1992", "Genie Of The Lamp", "/TestLabor;component/Images/genie.png"));
                _lstEmployees.Add(new EntityEmployee(6, "Goofy", "", "Male", "05/10/1932", "Self Evident", "/TestLabor;component/Images/goofy.gif"));
                _lstEmployees.Add(new EntityEmployee(7, "Olaf", "", "Male", "01/01/2013", "Confused Snowman", "/TestLabor;component/Images/olaf.gif"));
                _lstEmployees.Add(new EntityEmployee(8, "Pluto", "", "Male", "08/06/1931", "Dawg", "/TestLabor;component/Images/pluto.gif"));
                _lstEmployees.Add(new EntityEmployee(9, "Winnie", "The Pooh", "Male", "04/25/1924", "Hungry Bear", "/TestLabor;component/Images/pooh.gif"));
                _lstEmployees.Add(new EntityEmployee(10, "Snow", "White", "Female", "09/16/1937", "Damsel In Distress", "/TestLabor;component/Images/snowwhite.gif"));

            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw ex;
            }
        }

        /// <summary>
        /// Loads the shift data
        /// </summary>
        private void LoadEmployeeShifts()
        {
            try
            {
                //  Loads the employees shifts one by one
                //  ** Note this is only for the demo. Typically this would be database driven data
                //     Sadly to speed up development and keep on features I needed to give everyone the same schedule
                int iCountIds = 0;
                for (int iEmps = 1; iEmps <= 10; iEmps++)
                {
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-28, 5, 0, 0, iEmps) , CalculateDate(-28, 22, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-27, 8, 0, 0, iEmps) , CalculateDate(-27, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-27, 18, 0, 0, iEmps), CalculateDate(-27, 23, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-26, 6, 0, 0, iEmps), CalculateDate(-26, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-25, 8, 0, 0, iEmps), CalculateDate(-24, 5, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-24, 8, 0, 0, iEmps), CalculateDate(-24, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-23, 8, 0, 0, iEmps), CalculateDate(-23, 14, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-22, 8, 0, 0, iEmps), CalculateDate(-22, 15, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-20, 3, 0, 0, iEmps), CalculateDate(-20, 12, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-19, 8, 0, 0, iEmps), CalculateDate(-19, 22, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-18, 8, 0, 0, iEmps), CalculateDate(-18, 23, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-17, 6, 0, 0, iEmps), CalculateDate(-17, 15, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-16, 12, 0, 0, iEmps), CalculateDate(-16, 23, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-15, 8, 0, 0, iEmps), CalculateDate(-15, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-14, 1, 0, 0, iEmps), CalculateDate(-13, 5, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-12, 8, 0, 0, iEmps), CalculateDate(-12, 20, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-11, 1, 0, 0, iEmps), CalculateDate(-10, 1, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-9, 3, 0, 0, iEmps), CalculateDate(-9, 23, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-8, 15, 0, 0, iEmps), CalculateDate(-8, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-7, 8, 0, 0, iEmps), CalculateDate(-7, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-6, 18, 0, 0, iEmps), CalculateDate(-5, 4, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-5, 8, 0, 0, iEmps), CalculateDate(-5, 17, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-4, 11, 0, 0, iEmps), CalculateDate(-3, 12, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-2, 1, 0, 0, iEmps), CalculateDate(-2, 20, 0, 0, iEmps)));
                    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, CalculateDate(-1, 1, 0, 0, iEmps), CalculateDate(-1, 23, 0, 0, iEmps)));
                }






                //int iCountIds = 0;
                //for (int iEmps = 1; iEmps <= 10; iEmps++)
                //{
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 19, 5, 0, 0), new DateTime(2016, 05, 19, 22, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 20, 8, 0, 0), new DateTime(2016, 05, 20, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 20, 18, 0, 0), new DateTime(2016, 05, 20, 23, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 21, 8, 0, 0), new DateTime(2016, 05, 21, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 22, 8, 0, 0), new DateTime(2016, 05, 23, 5, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 23, 8, 0, 0), new DateTime(2016, 05, 23, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 24, 8, 0, 0), new DateTime(2016, 05, 24, 14, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 25, 12, 0, 0), new DateTime(2016, 05, 26, 15, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 27, 3, 0, 0), new DateTime(2016, 05, 27, 12, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 28, 8, 0, 0), new DateTime(2016, 05, 28, 22, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 29, 1, 0, 0), new DateTime(2016, 05, 29, 23, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 30, 6, 0, 0), new DateTime(2016, 05, 30, 15, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 05, 31, 12, 0, 0), new DateTime(2016, 05, 31, 23, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 01, 8, 0, 0), new DateTime(2016, 06, 01, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 02, 1, 0, 0), new DateTime(2016, 06, 03, 5, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 04, 8, 0, 0), new DateTime(2016, 06, 04, 20, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 05, 1, 0, 0), new DateTime(2016, 06, 06, 1, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 07, 3, 0, 0), new DateTime(2016, 06, 07, 23, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 08, 15, 0, 0), new DateTime(2016, 06, 09, 5, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 10, 8, 0, 0), new DateTime(2016, 06, 10, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 11, 18, 0, 0), new DateTime(2016, 06, 12, 4, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 13, 8, 0, 0), new DateTime(2016, 06, 13, 17, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 14, 11, 0, 0), new DateTime(2016, 06, 15, 12, 0, 0)));
                //    _lstShifts.Add(new EntityShift((iCountIds += 1), iEmps, new DateTime(2016, 06, 16, 1, 0, 0), new DateTime(2016, 06, 16, 20, 0, 0)));
                //}



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns the dateTime requested with the provided parameters
        /// </summary>
        /// <param name="daysBack">How many days to go back</param>
        /// <param name="hours">The number of hours to use</param>
        /// <param name="minutes">The number of minutes to use</param>
        /// <param name="seconds">The number of seconds to use</param>
        /// <param name="employeeId">The id of the employee being processed. Helps to randomize it</param>
        /// <returns></returns>
        private DateTime CalculateDate(double daysBack, int hours, int minutes, int seconds, int employeeId)
        {
            try
            {
                //  Calculates the new date
                DateTime dtNewDate = DateTime.Now.AddDays(daysBack);

                //  Creates and returns the date. Attempts to randomize the times as well
                return new DateTime(dtNewDate.Year, dtNewDate.Month, dtNewDate.Day, (hours / employeeId), (minutes / employeeId), (seconds / employeeId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Messaging

        /// <summary>
        /// Displays an error message for the system
        /// </summary>
        public void PresentErrorMessage(string _Method, string _ErrorMessage)
        {
            try
            {
                //  Present the message
                MessageBox.Show(string.Format(@"An error occured. Method: {0} - Error: {1}", _Method, _ErrorMessage), "Error", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                //  Handle the errors through another mean
            }
        }

        #endregion
    }
}
