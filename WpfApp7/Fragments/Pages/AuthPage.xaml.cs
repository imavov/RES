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
using System.Windows.Threading;
using WpfApp7.DataBase;

namespace WpfApp7.Fragments.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        private int seconds = 60;
        private int count = 3;
        public AuthPage()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds--;

            tr.Text = $"{seconds / 60}:{seconds % 60}";
            if(seconds % 60 == 0 && seconds /60 ==0)
            {
                count = 3;
                voyti.IsEnabled = true;
                tr.Text = "";
                timer.Stop();
            }else
            {
                voyti.IsEnabled=false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                timer.Start();
            }
            var users = DBHelper.DBHelper.GetContext().UserData.ToList();
            var isuser = users.Where(user => user.Email == textBoxEmail.Text && user.Password == textBoxPassword.Password).FirstOrDefault();
            if (isuser != null)
            {
                NavigationService.Navigate(new ListPage());
                return;
            }
            else
            {
                count--;

                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
