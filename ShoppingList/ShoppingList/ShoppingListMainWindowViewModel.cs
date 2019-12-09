using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ShoppingList
{
    class ShoppingListMainWindowViewModel : ViewModelBase
    {


        private string _Text;
        public string Text
        {
            get => _Text;
            set => Set(ref _Text, value);
        }

        private ShoppingItem _SelectedShoppingItem;
        public ShoppingItem SelectedShoppingItem
        {
            get => _SelectedShoppingItem;
            set => Set(ref _SelectedShoppingItem, value);
        }

        public ObservableCollection<ShoppingItem> ShoppingListItems { get; } = new ObservableCollection<ShoppingItem>();

        public RelayCommand ChangeNameCommand { get; }

        public ICommand AddPersonCommand { get; }
        private Func<DateTime> GetNow { get; }

        private bool CanExecute { get; set; }

        public ShoppingListMainWindowViewModel()
        {
            Text = "Shopping List";
            ChangeNameCommand = new RelayCommand(OnChangeName, () => CanExecute);
            AddPersonCommand = new RelayCommand(OnAddPerson);

           /* var dob = getNow().Subtract(TimeSpan.FromDays(30 * 365));*/

           /* People.Add(new Person("Kevin", "Bost", dob));
            People.Add(new Person("Mark", "Mc", dob));

            SelectedPerson = People.First();
            GetNow = getNow ?? throw new ArgumentNullException(nameof(getNow));*/
        }

        private void OnAddPerson()
        {
            var timeAdded = DateTime.Now;
            ShoppingListItems.Add(new ShoppingItem { Name="blah", TimeWhenAdded=timeAdded});
            CanExecute = true;
            ChangeNameCommand.RaiseCanExecuteChanged();
        }

        private void OnChangeName()
        {
            Text = "Kevin";
        }

    }
}
