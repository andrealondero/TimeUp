using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using FluentValidation;

using timesheet.Helpers;
using timesheet.Models;
using timesheet.Services;

namespace timesheet.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public TsItems _items;
        public Users _users;
        public IValidator _itemValidator;
        public IValidator _userValidator;
        public ITitemsRepository _itemRepository;
        public event EventHandler IsBusyChanged;
        public event EventHandler IsValidChanged;

        readonly List<string> errors = new List<string>();
        bool isBusy = false;

        public BaseViewModel()
        {
            Validate();
        }       
        protected virtual void Validate()
        {
            NotifyPropertyChanged("IsValid");
            NotifyPropertyChanged("Errors");

            var method = IsValidChanged;
            if (method != null)
                method(this, EventArgs.Empty);
        }
        protected List<string> Errors
        {
            get { return errors; }
        }
        protected virtual void OnIsBusyChanged()
        {
            var ev = IsBusyChanged;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }
        #region USER
        public string Mail
        {
            get => UserSettings.Mail;
            set
            {
                UserSettings.Mail = value;
                NotifyPropertyChanged("Mail");
            }
        }
        public string Password
        {
            get => UserSettings.Password;
            set
            {
                UserSettings.Password = value;
                NotifyPropertyChanged("Password");
            }
        }
        #endregion

        /*#region TIMESHEET
        public DateTime Date
        {
            get => _items.Date;
            set
            {
                _items.Date = value;
                NotifyPropertyChanged("Date");
            }
        }
        public int Hours
        {
            get => _items.Hours;
            set
            {
                _items.Hours = value;
                NotifyPropertyChanged("Hours");
            }
        }
        public string Description
        {
            get => _items.Description;
            set
            {
                _items.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public bool ConfirmedStatus
        {
            get => _items.ConfirmedStatus;
            set
            {
                _items.ConfirmedStatus = value;
                NotifyPropertyChanged("ConfirmedStatus");
            }
        }
        public bool RefusedSatus
        {
            get => _items.RefusedStatus;
            set
            {
                _items.RefusedStatus = value;
                NotifyPropertyChanged("RefusedStatus");
            }
        }
        List<TsItems> _itemsList;
        public List<TsItems> ItemsList
        {
            get => _itemsList;
            set
            {
                _itemsList = value;
                NotifyPropertyChanged("ItemsList");
            }
        }
        #endregion*/

        #region INotifyPropertyChanged  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
