using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using timesheet.Helpers;
using timesheet.Models;

namespace timesheet.Services
{
    public class TitemsRepository : ITitemsRepository
    {
        DBHelper _dbHelper;
        public TitemsRepository()
        {
            _dbHelper = new DBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ManagerDB.db3"));
        }

        public Task<List<TsItems>> GetAllItems()
        {
            return _dbHelper.GetAllItemsAsync();
        }
        public Task<List<TsItems>> GetItemsSuspended()
        {
            return _dbHelper.GetItemsSuspendedAsync();
        }
        public Task<List<TsItems>> GetItemsConfirmed()
        {
            return _dbHelper.GetItemsConfirmedAsync();
        }
        public Task<List<TsItems>> GetItemsRefused()
        {
            return _dbHelper.GetItemsRefusedAsync();
        }
        public Task<TsItems> GetItem(int id)
        {
            return _dbHelper.GetItemAsync(id);
        }
        public void SaveItem(TsItems item)
        {
            _dbHelper.SaveItemAsync(item);
        }
        public void DeleteItem(TsItems item)
        {
            _dbHelper.DeleteItemAsync(item);
        }
    }
}
