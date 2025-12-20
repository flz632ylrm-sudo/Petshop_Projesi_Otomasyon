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
    public partial class FrmHayvan : Form
    {
        private String ConnectionString;
        public FrmHayvan()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["Petshop_ProjesiConnectionString"].ConnectionString;
        }

        private void ComboLoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string qCins = "SELECT Cinsiyet_id, Cinsiyet_adi FROM Table_Hayvan_Cinsiyet";
                    SqlDataAdapter daCins = new SqlDataAdapter(qCins, connection);
                    DataTable dtCins = new DataTable();
                    daCins.Fill(dtCins);

                    combo_gender.DataSource = dtCins;
                    combo_gender.DisplayMember = "Cinsiyet_adi";
                    combo_gender.ValueMember = "Cinsiyet_id";

                }
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query2 = "SELECT Musteri_id, Musteri_adisoyadi FROM Table_Musteriler";

                    SqlDataAdapter da2 = new SqlDataAdapter(query2, connection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    // BOŞ SEÇENEK
                    DataRow bosSatir = dt2.NewRow();
                    bosSatir["Musteri_id"] = DBNull.Value;
                    bosSatir["Musteri_adisoyadi"] = "";
                    dt2.Rows.InsertAt(bosSatir, 0);

                    combo_Musteri.DataSource = dt2;
                    combo_Musteri.DisplayMember = "Musteri_adisoyadi"; // ekranda görünen
                    combo_Musteri.ValueMember = "Musteri_id";        
                    combo_Musteri.SelectedIndex = 0;
                }
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string qTur = "SELECT Tur_id, Tur_adi FROM Turler";
                    SqlDataAdapter daTur = new SqlDataAdapter(qTur, connection);
                    DataTable dtTur = new DataTable();
                    daTur.Fill(dtTur);

                    combo_tur.DataSource = dtTur;
                    combo_tur.DisplayMember = "Tur_adi";
                    combo_tur.ValueMember = "Tur_id";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata = " + ex);
            }
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            string h_name = txt_name.Text.ToString();
            string h_tur = combo_tur.SelectedValue.ToString();
            int h_tur_id = Convert.ToInt32(combo_tur.SelectedValue);
            string h_gender = combo_gender.SelectedValue.ToString();
            int h_gender_id = Convert.ToInt32(combo_gender.SelectedValue);
            DateTime h_tarihi = dateTimePicker1.Value;
            string fiyatText = txt_Fiyat.Text.Trim().Replace(",", ".");
            decimal h_fiyat;

            if (!decimal.TryParse(
                    fiyatText,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out h_fiyat))
            {
                MessageBox.Show("Fiyat sayısal olmalıdır. Örn: 250 veya 250.50");
                return;
            }
            object h_musteri_adsoyad;
            if (combo_Musteri.SelectedValue == null || combo_Musteri.SelectedValue.ToString() == "")
                h_musteri_adsoyad = DBNull.Value;
            else
                h_musteri_adsoyad = combo_Musteri.SelectedValue.ToString();


            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Table_Hayvanlar_Insert_Into", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Hayvan_adi", h_name);
                        cmd.Parameters.AddWithValue("@Tur_id", h_tur_id);
                        cmd.Parameters.AddWithValue("@Cinsiyet_id", h_gender_id);
                        cmd.Parameters.AddWithValue("@Gelis_tarihi", SqlDbType.Date).Value = h_tarihi;
                        cmd.Parameters.Add("@Fiyat", System.Data.SqlDbType.Decimal).Value = h_fiyat;
                        object musteriId =
    (combo_Musteri.SelectedValue == null || combo_Musteri.SelectedValue == DBNull.Value)
    ? (object)DBNull.Value
    : Convert.ToInt32(combo_Musteri.SelectedValue);

                        cmd.Parameters.Add("@Musteri_id", SqlDbType.Int).Value = musteriId;


                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarıyla Eklendi");

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata = " + ex);
            }

        }

        private void FrmHayvan_Load(object sender, EventArgs e)
        {
            ComboLoadData();
            combo_gender.SelectedIndex = -1;
            combo_tur.SelectedIndex = -1;
            combo_Musteri.SelectedIndex = -1;

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Table_Hayvanlar_Select_Detay", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        connection.Open();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["Musteri_id"].Visible = false;    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex);

            }
        }


        private void btn_starting_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir satır seçiniz");
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

            txt_name.Text = row.Cells["Hayvan_adi"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Gelis_tarihi"].Value);
            txt_Fiyat.Text = row.Cells["Fiyat"].Value.ToString();

            combo_tur.SelectedValue = Convert.ToInt32(row.Cells["Tur_id"].Value);
            combo_gender.SelectedValue = Convert.ToInt32(row.Cells["Cinsiyet_id"].Value);
            var musteri = row.Cells["Musteri_adisoyadi"].Value;
            var musteriIdObj = row.Cells["Musteri_id"].Value;

            if (musteriIdObj == DBNull.Value || musteriIdObj == null)
                combo_Musteri.SelectedIndex = 0;   // boş (null) müşteri
            else
                combo_Musteri.SelectedValue = Convert.ToInt32(musteriIdObj);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int Selected_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            string h_name = txt_name.Text.ToString();
            string h_tur = combo_tur.SelectedValue.ToString();
            int h_tur_id = Convert.ToInt32(combo_tur.SelectedValue);
            string h_gender = combo_gender.SelectedValue.ToString();
            int h_gender_id = Convert.ToInt32(combo_gender.SelectedValue);
            DateTime h_tarihi = dateTimePicker1.Value;
            string fiyatText = txt_Fiyat.Text.Trim().Replace(",", ".");
            decimal h_fiyat;

            if (!decimal.TryParse(
                    fiyatText,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out h_fiyat))
            {
                MessageBox.Show("Fiyat sayısal olmalıdır. Örn: 250 veya 250.50");
                return;
            }

            object h_musteri_adsoyad;
            if (combo_Musteri.SelectedValue == null || combo_Musteri.SelectedValue.ToString() == "")
                h_musteri_adsoyad = DBNull.Value;
            else
                h_musteri_adsoyad = combo_Musteri.SelectedValue.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Table_Hayvanlar_Update", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Hayvan_id", Selected_ID);
                        cmd.Parameters.AddWithValue("@Hayvan_adi", h_name);
                        
                        cmd.Parameters.AddWithValue("@Tur_id", h_tur_id);
        
                        cmd.Parameters.AddWithValue("@Cinsiyet_id", h_gender_id);
                        cmd.Parameters.AddWithValue("@Gelis_tarihi", h_tarihi);
                        cmd.Parameters.AddWithValue("@Fiyat", h_fiyat);
                        var adSoyad = combo_Musteri.SelectedValue?.ToString();

                        object musteriId =
    (combo_Musteri.SelectedValue == null || combo_Musteri.SelectedIndex <= 0)
    ? (object)DBNull.Value
    : Convert.ToInt32(combo_Musteri.SelectedValue);

                        cmd.Parameters.Add("@Musteri_id", SqlDbType.Int).Value = musteriId;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarıyla Güncellendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu:" + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)

            {
                int SelectedRowID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?");
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_Table_Hayvanlar_Delete", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Hayvan_id", SelectedRowID);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Silme işlemi başarıyla gercekleşti!");



                        }
                    }
                }
                catch (Exception ex)
                {


                    MessageBox.Show("Silme işlemi sırasında hata oluştu:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçiniz");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    



                