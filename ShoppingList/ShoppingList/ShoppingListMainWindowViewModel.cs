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
    public class ShoppingListMainWindowViewModel : ViewModelBase
    {

        public string Title { get;} = "Shopping List";

        private string _NewEntryText = "Enter item...";
        public string NewEntryText { get => _NewEntryText; set{Set(ref _NewEntryText, value);
                RaisePropertyChanged();
    }
}

       

        private ShoppingItem? _SelectedShoppingItem;
        public ShoppingItem? SelectedShoppingItem
        {
            get => _SelectedShoppingItem;
            set { Set(ref _SelectedShoppingItem, value);
                RaisePropertyChanged();
            }
        } 

        public ObservableCollection<ShoppingItem> ShoppingListItems { get; } = new ObservableCollection<ShoppingItem>();

  

        private bool CanExecute { get; set; }

        public RelayCommand AddItemCommand { get; }
        public RelayCommand EditItemCommand { get; }
        public RelayCommand DeleteItemCommand { get; }

        public ShoppingListMainWindowViewModel()
        {
          
            AddItemCommand = new RelayCommand(OnAddItem);
            EditItemCommand = new RelayCommand(OnEditItem);

            DeleteItemCommand = new RelayCommand(OnDeleteItem);


        }

        private void OnDeleteItem()
        {
            ShoppingListItems.Remove(SelectedShoppingItem!);
            SelectedShoppingItem = null;
            CanExecute = true;
            AddItemCommand.RaiseCanExecuteChanged();
            
        }

        private void OnAddItem()
        {
            var timeAdded = DateTime.Now;
            ShoppingListItems.Add(new ShoppingItem { Name= NewEntryText, TimeWhenAdded=timeAdded});

            NewEntryText = "Enter new item...";

            CanExecute = true;
            AddItemCommand.RaiseCanExecuteChanged();
            
           
        }

        private void OnEditItem()
        {
            var timeAdded = DateTime.Now;
            SelectedShoppingItem!.TimeWhenAdded = timeAdded;
            SelectedShoppingItem = null;


            CanExecute = true;
            EditItemCommand.RaiseCanExecuteChanged();

        }





    }
}
