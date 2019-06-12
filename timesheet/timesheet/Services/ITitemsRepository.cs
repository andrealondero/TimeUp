using System.Collections.Generic;
using System.Threading.Tasks;

using timesheet.Models;

namespace timesheet.Services
{
    public interface ITitemsRepository
    {
        //Get All items
        Task<List<TsItems>> GetAllItems();
        //Get all suspended
        Task<List<TsItems>> GetItemsSuspended();
        //Get all confimrmed
        Task<List<TsItems>> GetItemsConfirmed();
        //Get all refused
        Task<List<TsItems>> GetItemsRefused();
        //Get specific item
        Task<TsItems> GetItem(int id);
        //Create item
        void SaveItem(TsItems item);
        //Delete item
        void DeleteItem(TsItems item);
    }
}
