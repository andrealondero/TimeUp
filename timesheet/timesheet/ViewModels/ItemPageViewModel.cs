using timesheet.Models;
using timesheet.Services;
using timesheet.Validator;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class ItemPageViewModel : BaseViewModel
    {
        public INavigation _navigation { get; private set; }
        public TsItems Item { get; set; }
        public ItemPageViewModel(TsItems item = null)
        {
            Item = item;
        }
        public ItemPageViewModel(INavigation navigation, int selectedID)
        {
            _navigation = navigation;
            _itemValidator = new ItemValidator();
            _items = new TsItems
            {
                ID = selectedID
            };
            _itemRepository = new TitemsRepository();
        }
    }
}
