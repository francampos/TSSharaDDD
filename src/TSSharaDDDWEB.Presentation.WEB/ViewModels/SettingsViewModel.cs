using System.Linq;
using System.Windows.Input;
using System;

namespace TSSharaDDDWEB.Presentation.WEB.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; set; }

        public int _NetworkFailureTime;
        public int _LowBatteryTime;
        public int _ShutdownNobreakTime;
        public bool _ShutdownNobreakWithSOFlag;
        public bool _StartAppWithSOFlag;
        public string _CurrentLanguage;
        public string _ActionShutdownOrHibernate;
        public bool _ShutdownFlag;
        public bool _HibernateFlag;
        private string _userPassword;
        private string _userEmail;

        public int NetworkFailureTime
        {
            get { return _NetworkFailureTime; }
            set
            {
                _NetworkFailureTime = value;
                RaisePropertyChanged("NetworkFailureTime");
            }
        }
        public int LowBatteryTime
        {
            get { return _LowBatteryTime; }
            set
            {
                _LowBatteryTime = value;
                RaisePropertyChanged("LowBatteryTime");
            }
        }
        public int ShutdownNobreakTime
        {
            get { return _ShutdownNobreakTime; }
            set
            {
                _ShutdownNobreakTime = value;
                RaisePropertyChanged("ShutdownNobreakTime");
            }
        }
        public bool ShutdownNobreakWithSOFlag
        {
            get { return _ShutdownNobreakWithSOFlag; }
            set
            {
                _ShutdownNobreakWithSOFlag = value;
                RaisePropertyChanged("ShutdownNobreakWithSOFlag");
            }
        }
        public bool StartAppWithSOFlag
        {
            get { return _StartAppWithSOFlag; }
            set
            {
                _StartAppWithSOFlag = value;
                RaisePropertyChanged("StartAppWithSOFlag");
            }
        }
        public string CurrentLanguage
        {
            get { return _CurrentLanguage; }
            set
            {
                _CurrentLanguage = value;
                RaisePropertyChanged("CurrentLanguage");
            }
        }
        public string ActionShutdownOrHibernate
        {
            get { return _ActionShutdownOrHibernate; }
            set
            {
                _ActionShutdownOrHibernate = value;
                RaisePropertyChanged("ActionShutdownOrHibernate");
            }
        }
        public bool ShutdownFlag
        {
            get { return _ShutdownFlag; }
            set
            {
                _ShutdownFlag = value;
                RaisePropertyChanged("ShutdownFlag");
            }
        }
        public bool HibernateFlag
        {
            get { return _HibernateFlag; }
            set
            {
                _HibernateFlag = value;
                RaisePropertyChanged("HibernateFlag");
            }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        private bool ResolveFieldIntToBoolean(int autonomyEndTime)
        {
            return (autonomyEndTime == 0 ? true : false);
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        private bool CheckIfHaveLetter(string v)
        {
            return v.Where(c => char.IsLetter(c)).Count() > 0;
        }
    }


}
