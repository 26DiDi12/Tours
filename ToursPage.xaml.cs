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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();

            var allTypes = ToursDBEntities3.GetContext().Типы_туров.ToList();
            allTypes.Insert(0, new Типы_туров
            {
                Тип = "Все типы"
            });
            ComboType.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;

            var currentTours = ToursDBEntities3.GetContext().Tours.ToList();
            LViewTours.ItemsSource = currentTours;

            UpdateTour();
        }

        private void UpdateTour()
        {
            var currentTour = ToursDBEntities3.GetContext().Tours.ToList();
            if(ComboType.SelectedIndex > 0) 
                currentTour = currentTour.Where(p => p.Типы_туров1.Contains(ComboType.SelectedItem as Типы_туров)).ToList();

            currentTour = currentTour.Where(p => p.Название.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if(CheckActual.IsChecked.Value) 
                currentTour = currentTour.Where(p => p.Статус.Value).ToList();
            LViewTours.ItemsSource = currentTour.OrderBy(p => p.Количество_билетов).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTour();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTour();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTour();
        }
    }
}
