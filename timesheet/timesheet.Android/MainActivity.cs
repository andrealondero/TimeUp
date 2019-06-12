using Android.App;
using Android.Content.PM;
using Android.OS;
using timesheet.Views;

namespace timesheet.Droid
{
    [Activity(Label = "timesheet", Icon = "@drawable/timesheet_logo", Theme = "@style/MainTheme", MainLauncher = true,

        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            DashBoardPage.EmulateBackPressed = OnBackPressed;
            DashBoardSuperPage.EmulateBackPressed = OnBackPressed;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}