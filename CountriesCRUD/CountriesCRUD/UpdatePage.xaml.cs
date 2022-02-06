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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        CountriesDbEntities db = new CountriesDbEntities();
        private int Id;

        public UpdatePage(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Countries upCountry = (from c in db.Countries
                                   where c.id == Id
                                   select c).Single();

            //tbxName.Text = upCountry.CountryName;
            //tbxCapital.Text = upCountry.Capital;
            //tbxPopulation.Text = upCountry.Population;
            //tbxArea.Text = upCountry.Area;
            //cbxContinent.Text = upCountry.Continent;

            if (string.IsNullOrWhiteSpace(tbxName.Text)
                || (string.IsNullOrWhiteSpace(tbxCapital.Text))
                || (string.IsNullOrWhiteSpace(tbxPopulation.Text))
                || (string.IsNullOrWhiteSpace(tbxArea.Text)))
            {
                MessageBox.Show("Вы ввели некорректные данные!!!");
                return;
            }

            if (upCountry != null)
            {
                upCountry.CountryName = tbxName.Text;
                upCountry.Capital = tbxCapital.Text;
                upCountry.Population = tbxPopulation.Text;
                upCountry.Area = tbxArea.Text;
                upCountry.Continent = cbxContinent.Text;
            }

            db.SaveChanges();
            MainWindow.DataGrid.ItemsSource = db.Countries.ToList();
            Hide();
        }
    }
}
