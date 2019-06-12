using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using timesheet.Share;
using Xamarin.Forms;

namespace timesheet.Droid
{
    public class CloseAppAndroid : ICloseApp
    {
        public void CloseApp()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}