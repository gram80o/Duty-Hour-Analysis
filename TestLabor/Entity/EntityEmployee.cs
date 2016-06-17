using System.ComponentModel;
using System.Windows.Media;

namespace TestLabor.Entity
{
    public class EntityEmployee : INotifyPropertyChanged
    {
        #region Variables

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _gender;
        private string _dateOfBirth;
        private string _position;
        private string _imagePath;
        private bool _isSelected = false;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public EntityEmployee(int id, string firstName, string lastName, string gender, string dateOfBirth, string position, string imagePath)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _position = position;
            _imagePath = imagePath;
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
        /// The employees id
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// The employees first name
        /// </summary>
        public string FirstName { get { return _firstName; } }

        /// <summary>
        /// The employees last name
        /// </summary>
        public string LastName { get { return _lastName; } }

        /// <summary>
        /// The employees full name
        /// </summary>
        public string FullName { get { return string.Format(@"{0} {1}", _firstName, _lastName); } }

        /// <summary>
        /// The employees gender
        /// </summary>
        public string Gender { get { return _gender; } }

        /// <summary>
        /// The employees date of birth
        /// </summary>
        public string DateOfBirth { get { return _dateOfBirth; } }

        /// <summary>
        /// The position that the employee is working
        /// </summary>
        public string Position{ get { return _position; } }

        /// <summary>
        /// The path to the image for the employee
        /// </summary>
        public string ImagePath { get { return _imagePath; } }

        /// <summary>
        /// Flag to indicate if this employee is selected or not
        /// </summary>
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; RaisePropertyChanged("IsSelected"); RaisePropertyChanged("BackgroundColor"); } }

        /// <summary>
        /// The background color based on selection
        /// </summary>
        public SolidColorBrush BackgroundColor
        {
            get
            {
                if(_isSelected == true)
                {
                    return new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
                }
            }
            set { }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns the employees full name
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }
}
