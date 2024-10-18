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

namespace Туры
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Отели _currentHotel = new Отели();

        public AddEditPage(Отели selectedHotel)
        {
            InitializeComponent();
            ComboCountries.ItemsSource = ToursDBEntities.GetContext().Страны.ToList();

            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
                foreach (Страны item in ComboCountries.Items)
                    if (item.Код_страны == selectedHotel.Страна)
                        ComboCountries.SelectedItem = item;
            }
                
            this.DataContext = _currentHotel;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Название))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotel.Уровень_комфорта == null || _currentHotel.Уровень_комфорта < 1 || _currentHotel.Уровень_комфорта > 5)
                errors.AppendLine("Количество звёзд - число от 1 до 5");
            if (ComboCountries.SelectedItem == null)
                errors.AppendLine("Выберите страну");
            else
                _currentHotel.Страна = ToursDBEntities.GetContext().Страны.ToList()[ComboCountries.SelectedIndex].Код_страны.ToString();
               
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.ID == 0)
                ToursDBEntities.GetContext().Отели.Add(_currentHotel);

            try
            {
                ToursDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
                //ComboCountries.Text
            }

            Manager.MainFrame.Navigate(new HotelsPage());
        }
    }
}
