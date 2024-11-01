using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
            ComboCountries.ItemsSource = ToursDBEntities3.GetContext().Страны.ToList();

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
                _currentHotel.Страна = ToursDBEntities3.GetContext().Страны.ToList()[ComboCountries.SelectedIndex].Код_страны.ToString();
               
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.ID == 0)
                ToursDBEntities3.GetContext().Отели.Add(_currentHotel);

            try
            {
                ToursDBEntities3.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }

            Manager.MainFrame.Navigate(new HotelsPage());
        }
    }
}
