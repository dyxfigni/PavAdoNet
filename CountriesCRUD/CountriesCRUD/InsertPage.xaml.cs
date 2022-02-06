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

namespace CountriesCRUD
{
    /// <summary>
    /// Логика взаимодействия для InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        CountriesDbEntities db = new CountriesDbEntities();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text)
                || (string.IsNullOrWhiteSpace(tbxCapital.Text))
                || (string.IsNullOrWhiteSpace(tbxPopulation.Text))
                || (string.IsNullOrWhiteSpace(tbxArea.Text)))
            {
                MessageBox.Show("Вы ввели некорректные данные!!!");
                return;
            }

            Countries newCountry = new Countries()
            {
                CountryName = tbxName.Text,
                Capital = tbxCapital.Text,
                Population = tbxPopulation.Text,
                Area = tbxArea.Text,
                Continent = cbxContinent.Text
            };

            db.Countries.Add(newCountry);
            db.SaveChanges();
            MainWindow.DataGrid.ItemsSource = db.Countries.ToList();
            Hide();
        }
    }
}