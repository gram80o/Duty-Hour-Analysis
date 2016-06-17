using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLabor.Entity;
using TestLabor.Classes;
using System.Reflection;

namespace TestLabor.Classes
{
    public class DutyHourAnalysis
    {
        #region Variables

        /// <summary>
        /// The class to access the data and messaging
        /// </summary>
        private DataClass _dataAccessClass;

        /// <summary>
        /// The list of employees that the class needs to process
        /// </summary>
        private List<EntityEmployee> _lstEmployeeToProcess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataAccessClass">The class that allows access to the data and messaging</param>
        /// <param name="employeesToProcess">The list of employees that this instance of the class needs to process</param>
        public DutyHourAnalysis(DataClass dataAccessClass, List<EntityEmployee> employeesToProcess)
        {
            //  Sets the passed parameters
            _dataAccessClass = dataAccessClass;
            _lstEmployeeToProcess = employeesToProcess;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Processes the selected employees duty hours
        /// </summary>
        public List<EntityDutyHourAnalysisResult> ProcessDutyHourAnalysisForSelectedEmployees()
        {
            try
            {
                //  Variables
                List<EntityDutyHourAnalysisResult> lstResults = new List<EntityDutyHourAnalysisResult>();

                //  Calculated cut off start date
                DateTime dtCutOffStartDate = DateTime.Now.AddDays((7 * Properties.Settings.Default.DutyHourAnalysis_WeeksBack));

                //  Loops through the employees
                int iNewResultId = 1;
                foreach (EntityEmployee employee in _lstEmployeeToProcess)
                {
                    //  Pulls the shifts for the employee within the desired time frame (app setting)
                    List<EntityShift> lstShifts = new List<EntityShift>();
                    lstShifts = (from o in _dataAccessClass.ShiftsList where o.EmployeeId == employee.Id && o.StartDateTime >= dtCutOffStartDate select o).ToList();

                    //  Loops through the shifts to test each
                    EntityShift previousShift = null;
                    foreach (EntityShift shift in lstShifts.OrderBy(s => s.StartDateTime))
                    {
                        //-------------------------------------------------------------------------------------------
                        //  Over 24 Hour Shift Test
                        if (Rule_IsShiftOver24Hours(shift) == true)
                        {
                            //  Fail. Over 24 hours
                            EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, true, "Fail", string.Format(@"The shift is over 24 hours. The shift is {0} hours long.", shift.CalculatedHours.ToString()));
                            lstResults.Add(result);
                            iNewResultId += 1;
                        }
                        else
                        {
                            //  Pass. Not over 24 hours
                            EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, false, "Pass", "The shift isn't over 24 hours long.");
                            lstResults.Add(result);
                            iNewResultId += 1;
                        }

                        //-------------------------------------------------------------------------------------------
                        //  8 Hours Between Shifts Test
                        //  Was there a previous shift?
                        if (previousShift != null)
                        {
                            //  There is a previous shift. Is this shift and the next shift (current shift) within 8 hours of each other?
                            if(Rule_IsTheCurrentShiftWith8HoursOfThePreviousShift(previousShift, shift) == true)
                            {
                                //  Fail. New shift is within 8 hours of the previous shift ending
                                EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, true, "Fail", string.Format(@"This shift starts within 8 hours of the previous shift ending. The previous shift ends at {0} and this shift starts at {1}", previousShift.EndDateTime.ToString(), shift.StartDateTime.ToString()));
                                lstResults.Add(result);
                                iNewResultId += 1;
                            }
                            else
                            {
                                //  Pass. New shift starts 8 or more hours after the previous shift ends
                                EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, false, "Pass", "This shift starts on or over 8 hours after the previous shift ends.");
                                lstResults.Add(result);
                                iNewResultId += 1;
                            }
                        }

                        //  Sets the current shift to the previous shift
                        previousShift = shift;                       
                    }

                    //-------------------------------------------------------------------------------------------
                    //  80 hours / week avg
                    //  Is the average above the threshold
                    double dAverageWeeklyDutyHours = Rule_DutyHoursAveragePerWeek(lstShifts);
                    if (dAverageWeeklyDutyHours > 80.00)
                    {
                        //  The average is above the approved amount
                        //  Creates the shift
                        EntityShift shift = new EntityShift(-1, employee.Id, DateTime.MinValue, DateTime.MinValue, EntityShift.ShiftCalcType.Avg80PerWeek);

                        //  Creates the result
                        EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, true, "Fail", string.Format(@"{0} has an average of {1} duty hours per week. The limit is 80.", employee.FullName, dAverageWeeklyDutyHours.ToString()));
                        lstResults.Add(result);
                        iNewResultId += 1;
                    }
                    else
                    {
                        //  The average is within bounds
                        //  Creates the shift
                        EntityShift shift = new EntityShift(-1, employee.Id, DateTime.MinValue, DateTime.MinValue, EntityShift.ShiftCalcType.Avg80PerWeek);

                        //  Creates the result
                        EntityDutyHourAnalysisResult result = new EntityDutyHourAnalysisResult(iNewResultId, employee, shift, false, "Pass", "The average duty hours are within the acceptable range.");
                        lstResults.Add(result);
                        iNewResultId += 1;
                    }
                }



                //  Returns the list
                return lstResults;

            }
            catch (Exception ex)
            {
                //  Throws the error back to the called
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines if the provided shift is over 24 hours
        /// </summary>
        /// <param name="shift">The shift to test</param>
        /// <returns>Bool that indicates if the shift is over 24 hours or not. True = over 24 hours and fails</returns>
        private bool Rule_IsShiftOver24Hours(EntityShift shift)
        {
            try
            {
                //  Tests the hours
                if (shift.CalculatedHours > 24.00)
                {
                    //  Fail. Over 24 hour shift
                    return true;
                }
                else
                {
                    //  Pass. Not a 24 hour shift
                    return false;
                }
            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw new Exception(string.Format(@"Rule_IsShiftOver24Hours Error: {0}", ex.Message));
            }
        }
        
        /// <summary>
        /// Determines if the start date of the current shift is within 8 hours of the previous shifts ending
        /// </summary>
        /// <param name="previousShift">The shift right before the current</param>
        /// <param name="currentShift">The currently processing shift</param>
        /// <returns>Bool that indicates if the current shift is to close to the previous shift ending. True = within 8 hours and fails</returns>
        private bool Rule_IsTheCurrentShiftWith8HoursOfThePreviousShift(EntityShift previousShift, EntityShift currentShift)
        {
            try
            {
                //  Calculates the hours between shifts
                if ((currentShift.StartDateTime - previousShift.EndDateTime).TotalHours < 8.00)
                {
                    //  Fail. Within 8 hours of the previous shift ending
                    return true;
                }
                else
                {
                    //  Pass. Not within 8 hours
                    return false;
                }
            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw new Exception(string.Format(@"Rule_IsTheCurrentShiftWith8HoursOfThePreviousShift Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Calculates the average duty hours per week
        /// </summary>
        /// <param name="lstShifts">The shifts used to calculate the number</param>
        /// <returns>Double that is the average duty hours</returns>
        private double Rule_DutyHoursAveragePerWeek(List<EntityShift> lstShifts)
        {
            try
            {
                //  Calculates the total hours for the employee over the time frame
                double dTotalHours = (from o in lstShifts select o.CalculatedHours).Sum();

                //  Calculates the average
                double dAverageHoursPerWeek;
                if (Properties.Settings.Default.DutyHourAnalysis_WeeksBack == 0)
                {
                    dAverageHoursPerWeek = 0;
                }
                else
                {
                    dAverageHoursPerWeek = dTotalHours / System.Math.Abs(Properties.Settings.Default.DutyHourAnalysis_WeeksBack);
                }

                //  Returns the average
                return dAverageHoursPerWeek;
            }
            catch (Exception ex)
            {
                //  Throws the error to the caller
                throw new Exception(string.Format(@"Rule_DutyHoursAveragePerWeek Error: {0}", ex.Message));
            }
        }

        #endregion
    }
}
