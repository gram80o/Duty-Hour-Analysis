using System;
using System.ComponentModel;

namespace TestLabor.Entity
{
    public class EntityShift : INotifyPropertyChanged
    {
        #region Variables

        private int _shiftId;
        private int _employeeId;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private ShiftCalcType _shiftType;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shiftId">The id assigned to the specific shift</param>
        /// <param name="employeeId">The id of which employee this belongs to</param>
        /// <param name="startDateTime">The timestamp of when the shift starts</param>
        /// <param name="endDateTime">The timestamp of when the shift ends</param>
        /// <param name="shiftType">What type of shift Duty Hour Calc is this for</param>
        public EntityShift(int shiftId, int employeeId, DateTime startDateTime, DateTime endDateTime, ShiftCalcType shiftType = ShiftCalcType.Standard)
        {
            _shiftId = shiftId;
            _employeeId = employeeId;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
            _shiftType = shiftType;
        }

        #endregion

        #region Enums

        /// <summary>
        /// The shift type is used during the Duty Hours Analysis
        /// </summary>
        public enum ShiftCalcType
        {
            Standard,
            Avg80PerWeek,
            DayOffAvgPerWeek         
        };

        #endregion

        #region Property Changed

        /// <summary>
        /// Created delegate for the implemented interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Calls the property changed event
        /// </summary>
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion

        #region Properties

        /// <summary>
        /// The id assigned to the shift
        /// </summary>
        public int ShiftId { get { return _shiftId; } }

        /// <summary>
        /// The id of the employee the shift belongs to
        /// </summary>
        public int EmployeeId { get { return _employeeId; } }

        /// <summary>
        /// The day of the week that the shift starts on
        /// </summary>
        public DayOfWeek TheStartDayOfTheWeek { get { return _startDateTime.DayOfWeek; } }

        /// <summary>
        /// The day of the week that the shift ends on
        /// </summary>
        public DayOfWeek TheEndDayOfTheWeek { get { return _endDateTime.DayOfWeek; } }

        /// <summary>
        /// The timestamp for the start of the shift
        /// </summary>
        public DateTime StartDateTime { get { return _startDateTime; } }

        /// <summary>
        /// The timestamp for the end of the shift
        /// </summary>
        public DateTime EndDateTime { get { return _endDateTime; } }

        /// <summary>
        /// The type of Duty Hour analysis calculation this shift needs
        /// </summary>
        public ShiftCalcType ShiftType { get { return _shiftType; } }

        /// <summary>
        /// The number of days for the shift calculated from the timestamps
        /// </summary>
        public double CalculatedDays { get { return (EndDateTime - StartDateTime).TotalDays; } }

        /// <summary>
        /// The number of hours for the shift calculated from the timestamps
        /// </summary>
        public double CalculatedHours { get { return (EndDateTime - StartDateTime).TotalHours; } }

        /// <summary>
        /// The number of miunutes for the shift calculated from the timestamps
        /// </summary>
        public double CalculatedMinutes { get { return (EndDateTime - StartDateTime).TotalMinutes;} }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a friendly string of the shift
        /// </summary>
        public override string ToString()
        {
            //  Whats the type
            if(_shiftType == ShiftCalcType.Avg80PerWeek)
            {
                return "80 hours avg per week";
            }
            else if (_shiftType == ShiftCalcType.DayOffAvgPerWeek)
            {
                return "24 hour day off avg per week";
            }
            else
            {
                //  Standard shift
                return string.Format(@"{0} to {1}", _startDateTime.ToString(), _endDateTime.ToString());
            }          
        }

        #endregion
    }
}
