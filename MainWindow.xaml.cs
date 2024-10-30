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
using System.IO;

namespace Туры
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ToursPage());
            Manager.MainFrame = MainFrame;
            string array = "";
            foreach (var tour in ToursDBEntities3.GetContext().Tours.ToList())
            {
                array += tour.Название + " - ";
                foreach (var item in tour.Типы_туров1)
                {
                    array += item.Тип + ",";
                }
                array += "\n";
            }
            //MessageBox.Show(array);
        }

        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Демоэкзамен\Desktop\ИСИП-22-1\Шумилов\Туры.txt");
            var images = Directory.GetFiles(@"C:\Users\Демоэкзамен\Desktop\ИСИП-22-1\Шумилов\Туры фото");
            foreach (var line in fileData)
            {
                var data = line.Split('\t');
                var tempTour = new Tours
                {
                    Название = data[0].Replace("\"", ""),
                    Страна = data[1].ToString(),
                    Количество_билетов = int.Parse(data[2]),
                    Стоимость = int.Parse(data[3]),
                    Статус = (data[4] == "0") ? false : true
                };
                foreach (var tourType in data[5].Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                    foreach (var type in ToursDBEntities3.GetContext().Типы_туров.ToList())
                        if (tourType.Trim() == type.Тип.Trim())
                            tempTour.Типы_туров1.Add(type);
                try
                {
                    tempTour.Превью = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Название)));
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ToursDBEntities3.GetContext().Tours.Add(tempTour);
                ToursDBEntities3.GetContext().SaveChanges();
            }
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            /* if(MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            } else
            {
                BtnBack.Visibility = Visibility.Hidden;
            } */
        }

        private void BtnHotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelsPage());
        }

        private void BtnTours_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ToursPage());
        }
    }
}
