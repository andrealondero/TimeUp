using System;
using timesheet.Models;
using timesheet.Services;
using timesheet.Validator;

using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        public INavigation _navigation { get; private set; }
        public AddItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _itemValidator = new ItemValidator();
            _items = new TsItems();
            _itemRepository = new TitemsRepository();           
        }


    }
}
