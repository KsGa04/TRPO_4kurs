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
using WpfAnimatedGif;
using System.Timers;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string gifPath = @"C:\Users\pc\Desktop\TRPO\TRPO\Image\money.gif";
        public int total_amount = 0;
        public int drink_total_amount = 0;
        public int cash_change = 0;
        private static Dispatcher dispatcher;
        public MainWindow()
        {
            InitializeComponent();
            SumText.Visibility = Visibility.Hidden;
            Sum.Visibility = Visibility.Hidden;
            change.IsEnabled = false;
            refuld_money.IsEnabled = false;
            cacao.IsEnabled = false;
            americano.IsEnabled = false;
            latte.IsEnabled = false;
            tea.IsEnabled = false;
            capuchino.IsEnabled = false;
            raf.IsEnabled = false;
            drink.IsEnabled = false;
        }
        /// <summary>
        /// Ожидание оплаты
        /// </summary>
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
            SumText.Visibility = Visibility.Visible;
            Sum.Visibility = Visibility.Visible;
            refuld_money.IsEnabled = true;
            cacao.IsEnabled = true;
            americano.IsEnabled = true;
            latte.IsEnabled=true;
            tea.IsEnabled = true; 
            capuchino.IsEnabled = true; 
            raf.IsEnabled = true;
            ListBoxItem selectedItem = bill.SelectedItem as ListBoxItem;
            drink_text.Content = "Выберите напиток";
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
            SumText.Visibility = Visibility.Visible;
            Sum.Visibility = Visibility.Visible;
            refuld_money.IsEnabled = true;
            cacao.IsEnabled = true;
            americano.IsEnabled = true;
            latte.IsEnabled = true;
            tea.IsEnabled = true;
            capuchino.IsEnabled = true;
            raf.IsEnabled = true;
            ListBoxItem selectedItem = coin.SelectedItem as ListBoxItem;
            drink_text.Content = "Выберите напиток";
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
        /// <summary>
        /// Сдача, вернуть деньги
        /// </summary>
        private void change_Click(object sender, RoutedEventArgs e)
        {
            SumText.Visibility = Visibility.Hidden;
            Sum.Visibility = Visibility.Hidden;
            change.IsEnabled = false;
            refuld_money.IsEnabled = false;
            total_amount = 0;
            drink_total_amount = 0;

            gifImage.Source = null;

            // Загрузка и отображение GIF
            Uri gifUri = new Uri(gifPath, UriKind.Absolute);
            gifImage.Source = gifUri;

            // Установка таймера для отображения на определенное время
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Замените 5 на количество секунд, которое вы хотите отобразить гифку
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Остановка таймера
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();

            // Очистка источника изображения
            gifImage.Source = null;
            drink_text.Content = "";
        }
        /// <summary>
        /// Достаточная ли сумма
        /// </summary>
        public void IsSuffientAmount(int drink_total_amount, string name_drink)
        {
            if (drink_total_amount <= total_amount)
            {
                drink.IsEnabled = true;
                refuld_money.IsEnabled = false;
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("/Image/Americano.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(drink, image);
                drink_text.Content = "Выбран напиток " + name_drink;
            }
            else
            {
                refuld_money.IsEnabled= true;
                drink.IsEnabled = false;
                drink_text.Content = "Сумма недостаточна";
            }
        }
        /// <summary>
        /// Выбор напитка
        /// </summary>
        private void cacao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int cacao_count = 20;
            drink_total_amount = cacao_count;
            IsSuffientAmount(drink_total_amount, "какао");
        }

        private void americano_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int americano_count = 25;
            drink_total_amount = americano_count;
            IsSuffientAmount(drink_total_amount, "американо");
        }

        private void latte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int latte_count = 20;
            drink_total_amount = latte_count;
            IsSuffientAmount(drink_total_amount, "латте");
        }

        private void tea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int tea_count = 15;
            drink_total_amount = tea_count;
            IsSuffientAmount(drink_total_amount, "чай");
        }

        private void raf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int raf_count = 20;
            drink_total_amount = raf_count;
            IsSuffientAmount(drink_total_amount, "раф");
        }

        private void capuchino_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int capuchino_count = 25;
            drink_total_amount = capuchino_count;
            IsSuffientAmount(drink_total_amount, "капучино");
        }
        /// <summary>
        /// Забрать напиток
        /// </summary>
        private void drink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (total_amount - drink_total_amount == 0)
            {
                total_amount = 0;
                drink_total_amount = 0;
                SumText.Visibility = Visibility.Hidden;
                Sum.Visibility = Visibility.Hidden;
                change.IsEnabled = false;
                drink_text.Content = "Сдачи нет";
                ImageBehavior.SetAnimatedSource(drink, null);
            }
            else
            {
                cash_change = total_amount - drink_total_amount;
                SumText.Visibility = Visibility.Hidden;
                Sum.Visibility = Visibility.Hidden;
                drink_text.Content = "Получите сдачу " + cash_change + " руб";
                change.IsEnabled = true;
                ImageBehavior.SetAnimatedSource(drink, null);
            }
        }

        private void change_gif_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
