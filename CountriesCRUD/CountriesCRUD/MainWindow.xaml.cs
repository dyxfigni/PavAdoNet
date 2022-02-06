using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CountriesCRUD
{
    public partial class MainWindow : Window
    {
        CountriesDbEntities db;
        public static DataGrid DataGrid;

        public MainWindow()
        {
            InitializeComponent();
            db = new CountriesDbEntities();
            dvgCountries.ItemsSource = db.Countries.OrderBy(c => c.id).ToList();
            DataGrid = dvgCountries;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dvgCountries.SelectedItems.Count != 1)
            {
                MessageBox.Show("Вы не выбрали данные!");
                return;
            }
            Countries country = dvgCountries.SelectedItems[0] as Countries;
            UpdatePage Upage = new UpdatePage(country.id);
            Upage.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dvgCountries.SelectedItems.Count != 1)
            {
                MessageBox.Show("Вы не выбрали данные!");
                return;
            }
            // DialogResult result = MessageBox.Show("Удалить запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            Countries country = dvgCountries.SelectedItems[0] as Countries;
            if (country != null)
            {
                db.Countries.Remove(country);
                db.SaveChanges();
                dvgCountries.ItemsSource = db.Countries.ToList();
            }
        }

        private void dvgCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                dvgCountries.ItemsSource = db.Countries.OrderBy(c => c.id).ToList();
            }
            else
            {
                dvgCountries.ItemsSource = db.Countries.Where(c => c.CountryName.Contains(tbxSearch.Text)).ToList();
            }
        }
    }
}
