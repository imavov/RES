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
using System.Windows.Shapes;
using WpfApp7.DataBase;

namespace WpfApp7.Fragments.Windows
{
    /// <summary>
    /// Логика взаимодействия для addVSedit.xaml
    /// </summary>
    
    public partial class addVSedit : Window
    {
        public UserData user = new UserData();
        public int Id { get; }

        public addVSedit(int id=-1)
        {
            InitializeComponent();
            if(id == -1)
            {
                DataContext = user;
                Title = "Добавить";
            }
            else
            {
                user = DBHelper.DBHelper.GetContext().UserData.FirstOrDefault(u => u.ID == id);
                DataContext =user;
                Title = "Редактировать";
                
            }
            comboBoxRole.ItemsSource = DBHelper.DBHelper.GetContext().Role.ToList();
            comboBoxStatus.ItemsSource = DBHelper.DBHelper.GetContext().Status.ToList();

            Id = id;

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Id==-1)
            {
                DBHelper.DBHelper.GetContext().UserData.Add(user);
            }
            DBHelper.DBHelper.GetContext().SaveChanges();
            MessageBox.Show("Пользователь добавлен!");
            Close();
        }
    }
}
