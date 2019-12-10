using System.Windows;
using System.Windows.Controls;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ShoppingListMainWindowViewModel();
            InitializeComponent();
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                (sender as TextBox)!.SelectAll();
            }
        }

       

       
    }
}



