using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;

namespace Практическая_17._02_Кастумерс
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void dvgDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edSql.Text.Trim()))
                return;
            using (IDbConnection conn =
                   new SqlConnection(
                       "Data Source=DESKTOP-8GO917E;Initial Catalog=CelledProducts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                dvgView.DataSource = null;
                dvgView.Columns.Clear();
                conn.Open();

                string sql = "Select * from Costumer";
                //var result = conn.Query<Costumer>(sql).Where(c => c.CostumerId);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (IDbConnection conn = new SqlConnection("Data Source=DESKTOP-8GO917E;Initial Catalog=CelledProducts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                dvgView.DataSource = null;
                dvgView.Columns.Clear();
                try
                {
                    conn.Open();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Не успешно!");
                    throw;
                }
                MessageBox.Show("Успех");

                string sql = "select * from Costumer";

                //var result = conn.Query<Costumer>(sql).ToString();

                // отображение всех покупателей
                //var result = conn.Query<Costumer>(sql).Select(
                //    c => new
                //    {
                //        c.FullName
                //    }
                //    ).ToList();

                // отображение емаил всех покупателей
                //var result = conn.Query<Costumer>(sql).Select(
                //    c => new
                //    {
                //        c.FullName, c.Email
                //    }
                //    ).ToList();


                // отбразить все разделы
                sql = "select * from Category";
                //var result = conn.Query<Category>(sql).Select(
                //    c => new
                //    {
                //        c.CategoryName
                //    }
                //    ).ToList();

                sql = "select * from Products";
                //var result = conn.Query<Products>(sql).Select(
                //        p => new
                //        {
                //            p.ProductName
                //        }
                //        ).ToList();

                sql = "select * from Cities";
                //var result = conn.Query<Cities>(sql).Select(
                //        c => new
                //        {
                //            c.CityName
                //        }
                //        ).ToList();

                sql = "select * from Countries";
                //var result = conn.Query<Countries>(sql).Select(
                //            c => new
                //            {
                //                c.CountryName
                //            }
                //            ).ToList();

                //sql = "select * from Costumer";
                //var result =   

                //dvgView.DataSource = result;
                conn.Close();
            }
        }
    }
}
