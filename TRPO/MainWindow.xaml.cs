using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int total_amount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (popup != null)
            {
                popup.IsOpen = true;
                popup.PlacementTarget = button;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (popup1 != null)
            {
                popup1.IsOpen = true;
                popup1.PlacementTarget = button1;
            }

        }

        private void Bill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = bill.SelectedItem as ListBoxItem;
            if (selectedItem != null)
            {
                string selectedText = selectedItem.Content.ToString();
                total_amount += Convert.ToInt32(selectedText);
                Sum.Content = total_amount;
                // Ваша переменная selectedText содержит выбранный текст из списка
            }

            if (popup != null)
            {
                popup.IsOpen = false;
            }
        }
        private void Coin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = coin.SelectedItem as ListBoxItem;
            if (selectedItem != null)
            {
                string selectedText = selectedItem.Content.ToString();
                total_amount += Convert.ToInt32(selectedText);
                Sum.Content = total_amount;
                // Ваша переменная selectedText содержит выбранный текст из списка
            }

            if (popup != null)
            {
                popup.IsOpen = false;
            }
        }
    }
}
