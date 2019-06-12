using System;
using System.IO;
using Foundation;
using SQLite;
using timesheet.Helpers;
using timesheet.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISQLite_IOS))]
namespace timesheet.iOS
{
    public class ISQLite_IOS : ISQLite
    {
        public ISQLite_IOS()
        {
        }

        public SQLite.Net.SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "ManagerDB.db3";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string path = Path.Combine(libFolder, sqliteFilename);

            // This is where we copy in the pre-created database
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("ManagerDB", "db3");
                File.Copy(existingDb, path);
            }

            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteAsyncConnection(iOSPlatform, path);

            // Return the database connection 
            return connection;
        }
    }
}