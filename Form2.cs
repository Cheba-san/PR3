using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YADAUN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string addcar = "insert into cars(color, price, model) values('" + Color.Text + "'," + Price.Text + ",'" + Model.Text + "');";
            MySqlConnection conn = Class2.GetSqlConnection();
            MySqlCommand cmDB = new MySqlCommand(addcar, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd =cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Авто добавленно.");
            }
            catch(Exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка.");
            }
           
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
