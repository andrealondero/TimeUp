using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace timesheet.Helpers
{
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string Mail
        {
            get => AppSettings.GetValueOrDefault(nameof(Mail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Mail), value);
        }
        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
        public static void GetUserData()
        {
            App.Database.GetuserAsync();
        }
        public static void GetSuperuserData()
        {
            App.Database.GetsuperuserAsync();
        }
        public static void ClearAllData()
        {
            AppSettings.Clear();
        }
    }
}
