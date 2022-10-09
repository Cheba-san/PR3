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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string querry = "SELECT id_user FROM users WHERE login ='" + Login.Text + "'and password='" + Password.Text + "';";
            MySqlConnection conn = Class2.GetSqlConnection();
            MySqlCommand cmDB = new MySqlCommand(querry, conn);
            try
            {
                conn.Open();
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 1)
                {
                    Form2 Win = new Form2();
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    Login.Clear();
                    Password.Clear();
                }
                else
                    MessageBox.Show("Возникла ошибка при входе.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка." + Environment.NewLine + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
