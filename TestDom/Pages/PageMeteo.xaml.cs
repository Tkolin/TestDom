using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
using TestDom.Data;
using TestDom.Sqript;

namespace TestDom
{
    /// <summary>
    /// Логика взаимодействия для PageMeteo.xaml
    /// </summary>
    public partial class PageMeteo : Page
    {
        public PageMeteo()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(TBoxSearch.Text.Length <= 1) {
                MessageBox.Show("Поле не заполнено","Ошибка",MessageBoxButton.OK);
                return;
            }
            UpdateWeather();


        }

        private void UpdateWeather() {

            Meteo weatherData = MeteoSqript.GetData(TBoxSearch.Text);

            if (weatherData == null)
            {      
                MessageBox.Show("Город не найден!", "Ошибка", MessageBoxButton.OK);
                TBoxSearch.Text = string.Empty;
                return;
            }

            TBoxTemp.Text = weatherData.Temperature.ToString();
            TBoxDescript.Text = weatherData.Description.ToString();
            TBoxWind.Text = weatherData.WindSpeed.ToString();

        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            TBoxSearch.Text = string.Empty;
        }

        private void BtnOpenSQL_Click(object sender, RoutedEventArgs e)
        {

            string filePath = @"ТестированиеSQL.docx";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
