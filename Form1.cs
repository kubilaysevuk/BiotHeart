using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp2.Classes;

namespace WindowsFormsApp2
{
    public partial class BioTHeart : Form
    {
        public BioTHeart()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrRefreshPage();

        }
        public void LoadOrRefreshPage()
        {
            SqlCommand commandList = new SqlCommand("Select * from Table_2 ", SqlOperations.connection);
            SqlDataAdapter da = new SqlDataAdapter(commandList);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;         
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            SqlCommand commandAdd = new SqlCommand("Insert into Table_2 (HastaAdi,HastaSoyadi,HastaTc,HastalikTuru) " +
                "values (@pname,@psurname,@ptc,@phastalikturu)", SqlOperations.connection );
            SqlOperations.CheckConnection(SqlOperations.connection);

            commandAdd.Parameters.AddWithValue("@pname", tboxName.Text);
            commandAdd.Parameters.AddWithValue("@psurname", tboxSurname.Text);
            commandAdd.Parameters.AddWithValue("@ptc", tboxTc.Text);
            commandAdd.Parameters.AddWithValue("@phastalikturu", comboBox1.SelectedItem.ToString());
            commandAdd.ExecuteNonQuery();
            
            LoadOrRefreshPage();
            MessageBox.Show("TEST BAŞLADI!");
        }
        private void FormGetir(Form frm)
        {
            panel7.Controls.Clear();
            
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel7.Controls.Add(frm);
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadOrRefreshPage();
            Form2 sonuc = new Form2();
            FormGetir(sonuc);

          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            BioTHeart ana = new BioTHeart();
            ana.MdiParent = this.MdiParent;
            ana.Show();


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}


