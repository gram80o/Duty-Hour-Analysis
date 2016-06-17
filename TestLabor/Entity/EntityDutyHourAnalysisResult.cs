using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TestLabor.Entity;

namespace TestLabor.Entity
{
    public class EntityDutyHourAnalysisResult : INotifyPropertyChanged
    {
        #region Variables

        private int _id;
        private EntityEmployee _employee;
        private EntityShift _shift;
        private bool _isFailure;
        private string _resultType;
        private string _resultMessage;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityDutyHourAnalysisResult(int id, EntityEmployee employee, EntityShift shift, bool isFailure, string resultType, string resultMessage)
        {
            _id = id;
            _employee = employee;
            _shift = shift;
            _isFailure = isFailure;
            _resultType = resultType;
            _resultMessage = resultMessage;
        }

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
        /// The unique Id assigned to this result
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// The employee record assigned to this result
        /// </summary>
        public EntityEmployee Employee { get { return _employee; } }

        /// <summary>
        /// The shift generating this result
        /// </summary>
        public EntityShift Shift { get { return _shift; } }

        /// <summary>
        /// The flag that indicates if this result is a failure or not
        /// </summary>
        public bool IsFailure { get { return _isFailure; } }

        /// <summary>
        /// The type for this result
        /// </summary>
        public string ResultType { get { return _resultType; } }

        /// <summary>
        /// The message for the result
        /// </summary>
        public string ResultMessage { get { return _resultMessage; } }

        #endregion

        #region Overrides

        /// <summary>
        /// The override for ToString()
        /// </summary>
        public override string ToString()
        {
            //  Refine this. Default in place
            return string.Format(@"<Duty Hour Analysis Result '{0}'>", _id);
        }

        #endregion
    }
}
