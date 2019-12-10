using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShoppingList
{
    class ShoppingListMainWindowViewModel : ViewModelBase
    {

        public string Title { get;} = "Shopping List";

        public string NewEntryText { get; set; } = "Enter new item...";

       

        private ShoppingItem _SelectedShoppingItem;
        public ShoppingItem SelectedShoppingItem
        {
            get => _SelectedShoppingItem;
            set { Set(ref _SelectedShoppingItem, value);
                RaisePropertyChanged();
            }
        } 

        public ObservableCollection<ShoppingItem> ShoppingListItems { get; } = new ObservableCollection<ShoppingItem>();

        

       
        

        private bool CanExecute { get; set; }

        public RelayCommand AddItemCommand { get; }
        public RelayCommand EditEntryCommand { get; }
        public RelayCommand DeleteEntryCommand { get; }

        public ShoppingListMainWindowViewModel()
        {
            
            //ChangeNameCommand = new RelayCommand(OnChangeName, () => CanExecute);
            AddItemCommand = new RelayCommand(OnAddItem);
            EditEntryCommand = new RelayCommand(OnEditItem);

            DeleteEntryCommand = new RelayCommand(OnDeleteItem);

            



           /* var dob = getNow().Subtract(TimeSpan.FromDays(30 * 365));*/

           /* People.Add(new Person("Kevin", "Bost", dob));
            People.Add(new Person("Mark", "Mc", dob));

            SelectedPerson = People.First();
            GetNow = getNow ?? throw new ArgumentNullException(nameof(getNow));*/
        }

        private void OnDeleteItem()
        {
            ShoppingListItems.Remove(SelectedShoppingItem);
            CanExecute = true;
            AddItemCommand.RaiseCanExecuteChanged();
        }

        private void OnAddItem()
        {
            var timeAdded = DateTime.Now;
            ShoppingListItems.Add(new ShoppingItem { Name= NewEntryText, TimeWhenAdded=timeAdded});
            
            
            CanExecute = true;
            AddItemCommand.RaiseCanExecuteChanged();
            
            NewEntryText = "Enter new item..."; 
        }

        private void OnEditItem()
        {
            var timeAdded = DateTime.Now;
            SelectedShoppingItem.TimeWhenAdded = timeAdded;
            SelectedShoppingItem = null;


            CanExecute = true;
            EditEntryCommand.RaiseCanExecuteChanged();

        }





    }
}
