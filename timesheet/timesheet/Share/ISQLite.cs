using SQLite;

namespace timesheet.Helpers
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
