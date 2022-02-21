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
using WpfApp7.DataBase;
using WpfApp7.Fragments.Windows;

namespace WpfApp7.Fragments.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            refreshItems();
        }
        
        private void refreshItems()
        {
            var user = DBHelper.DBHelper.GetContext().UserData;
            DataGridUser.ItemsSource = user.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = DataGridUser.SelectedItem as UserData;
            if (user == null)
                return;

            Windows.addVSedit okno= new Windows.addVSedit(user.ID);
            okno.ShowDialog();
            DBHelper.DBHelper.GetContext().SaveChanges();
            refreshItems();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = DataGridUser.SelectedItem as UserData;
            if (user == null)
                return;

            DBHelper.DBHelper.GetContext().UserData.Remove(user);
            DBHelper.DBHelper.GetContext().SaveChanges();
            refreshItems();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Windows.addVSedit okno =new Windows.addVSedit(-1);
            okno.ShowDialog();
            refreshItems();

        }
    }
}
