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
                Thread.Sleep(1000); 
                 FrmMusteri Musterifrm = new FrmMusteri();
                this.Hide();
                Musterifrm.ShowDialog();  
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex);

            }
        }
    }

}
