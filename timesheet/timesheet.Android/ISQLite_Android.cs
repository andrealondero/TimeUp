using System;
using System.IO;
using timesheet.Droid;
using timesheet.Helpers;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(ISQLite_Android))]
namespace timesheet.Droid
{
    public class ISQLite_Android : ISQLite
    {
        public ISQLite_Android()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var dbName = "ManagerDB.db3";
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            // This is where we copy in our pre-created database
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }

            return new SQLiteAsyncConnection(path);
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}