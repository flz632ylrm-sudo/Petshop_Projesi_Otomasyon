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
    public partial class FrmMusteri : Form
    {
        private String ConnectionString;
        public FrmMusteri()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["Petshop_ProjesiConnectionString"].ConnectionString;
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using(SqlCommand cmd=new SqlCommand("sp_Table_Musteriler_Select",connection))
                    {
                     cmd.CommandType=CommandType.StoredProcedure;  
                     DataTable dt = new DataTable();
                     SqlDataAdapter da = new SqlDataAdapter(cmd);   
                     connection .Open();    
                        da.Fill(dt);
                        dataGridView1.DataSource= dt;   
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata = "+ ex.Message);
            }
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            string m_namesurname = txtAdsoyad.Text.ToString();
            string m_tel=maskedTel.Text.ToString();
            string m_adres=txtAdres.Text.ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Table_Musteriler_Insert_Into", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Musteri_adisoyadi", m_namesurname);
                        cmd.Parameters.AddWithValue("@Musteri_tel", m_tel);
                        cmd.Parameters.AddWithValue("@Musteri_adres", m_adres);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarıyla eklendi");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata =" + ex);
            }
        }

        private void btn_starting_update_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

               int m_id = int.Parse(selectedRow.Cells[0].Value.ToString()); 
               string m_namesurname = selectedRow.Cells[1].Value.ToString();
               string m_tel = selectedRow.Cells[2].Value.ToString();
               string m_adres = selectedRow.Cells[3].Value.ToString();

             if(m_tel.StartsWith("0"))
                {
                    m_tel = m_tel.Remove(0, 1);
                    m_tel = m_tel.Replace("(", "").Replace(")", "").Replace("_", "").Replace(" ", "");

                }
                try
                {
                    txtAdsoyad.Text = m_namesurname; 
                    maskedTel.Text = m_tel;    
                    txtAdres.Text = m_adres;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Aktarma işlemi sırasında hata oluştu:" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Lütfen Güncellemek İçin Bir Kayıt Seçiniz");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int selected_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            string m_namesurname = txtAdsoyad.Text.ToString();
            string m_tel = maskedTel.Text.ToString();
            string m_adres = txtAdres.Text.ToString();

            m_tel = m_tel.Replace("(", "").Replace(")", "").Replace("_", "").Replace(" ", "");
            if(!m_tel.StartsWith("0"))
            {
                m_tel = "0" + m_tel;    
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand("sp_Table_Musteriler_Update", connection))
                    {
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Musteri_id", selected_ID);
                        cmd.Parameters.AddWithValue("@Musteri_adisoyadi", m_namesurname);
                        cmd.Parameters.AddWithValue("@Musteri_tel", m_tel);
                        cmd.Parameters.AddWithValue("@Musteri_adres", m_adres);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarıyla Güncellendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtAdsoyad.Clear();
                        maskedTel.Clear();
                        txtAdres.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu" + ex.Message);
                
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?");
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_Table_Musteriler_Delete", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Musteri_id", selectedRowID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Kayıt silme işlemi başarıyla gerçekleşti!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işleminde bir sorun oluştu:" + ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
