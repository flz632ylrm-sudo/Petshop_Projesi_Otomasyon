using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;




namespace Petshop_Projesi_Otomasyon
{
    public partial class Form1 : Form
    {
        private string connectionString;
        public Form1()

        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Petshop_ProjesiConnectionString"].ConnectionString;
        }

        private void btnMusteriIslemleri_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("1 Saniye sonra yönlendireceksiniz","Bağlantı açık",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    }
               
                }
                FrmMusteri fm = new FrmMusteri();
                fm.FormClosed += (s, args) => this.Show();
                fm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex);

            }
        }

        private void btnHayvanislemleri_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("1 Saniye sonra yönlendireceksiniz", "Bağlantı açık",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                FrmHayvan fm = new FrmHayvan();
                fm.FormClosed += (s, args) => this.Show();
                fm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex);

            }
        }
    }

}
