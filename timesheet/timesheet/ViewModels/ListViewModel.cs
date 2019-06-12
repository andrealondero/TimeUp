using System;
using System.Collections.Generic;
using System.Text;
using timesheet.Models;
using timesheet.Services;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        TsItems item;

        public int ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Date
        {
            get { return item.Date; }
            set
            {
                if (item.Date == value)
                    return;
                item.Date = value;
            }
        }
        public int Hours
        {
            get { return item.Hours; }
            set
            {
                if (item.Hours == value)
                    return;
                item.Hours = value;
            }
        }
        public string Description
        {
            get { return item.Description; }
            set
            {
                if (item.Description == value)
                    return;
                item.Description = value;
                NotifyPropertyChanged();
            }
        }
        public bool Confirmed
        {
            get { return item.ConfirmedStatus; }
            set
            {
                if (item.ConfirmedStatus == value)
                    return;
                item.ConfirmedStatus = value;
                NotifyPropertyChanged();
            }
        }
        public bool Refused
        {
            get { return item.RefusedStatus; }
            set
            {
                if (item.RefusedStatus == value)
                    return;
                item.RefusedStatus = value;
                NotifyPropertyChanged();
            }
        }
    }
}
