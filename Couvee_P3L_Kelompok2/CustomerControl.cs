using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Couvee_P3L_Kelompok2
{
    public partial class CustomerControl : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            string sql = "select * from customers where DELETED_AT is NULL ORDER BY CREATED_AT DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetString(4));
                lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                lv.SubItems.Add(Reader.GetString(6));
                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void clear()
        {
            textCustomerID.Text = String.Empty;
            textCustomerName.Text = String.Empty;
            textPhoneNumber.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            comboBox1.Text = String.Empty;
        }

        public CustomerControl()
        {
            InitializeComponent();
            tampil();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            if (textCustomerName.Text == "" || textAddress.Text == "" || textPhoneNumber.Text == "" || dateTimePicker1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Customer ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `customers` (`employee_id`, `customer_name`, `customer_address`, `customer_phoneno`, `customer_birth`, `customer_membership`, `CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('" + Form_Main.id + "', '" + textCustomerName.Text + "', '" + textAddress.Text + "', '" + Convert.ToInt32(textPhoneNumber.Text) + "', '" + dateTimePicker1.Text + "', '" + comboBox1.Text + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                string sql = "select * from customers where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                    lv.SubItems.Add(Reader.GetString(6));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textCustomerID.Text == "")
            {
                MessageBox.Show("Please click the customer that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `customers` SET `customer_id` = '" + textCustomerID.Text + "',  `customer_name` = '" + textCustomerName.Text + "', `customer_address`= '" + textAddress.Text + "', `customer_phoneno`= '" + Convert.ToInt32(textPhoneNumber.Text) + "', `customer_birth`= '" + dateTimePicker1.Text + "', `customer_membership`= '" + comboBox1.Text + "', `UPDATED_AT`= current_timestamp() WHERE `customer_id`= '" + textCustomerID.Text + "'";
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Customer updated!");
                tampil();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textCustomerID.Text == "")
            {
                MessageBox.Show("Please click the customer that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `customers` SET `DELETED_AT` = current_timestamp() WHERE `customer_id` = '" + textCustomerID.Text + "'";
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Customer Deleted!");
                    clear();
                    tampil();
                }
            }
            //////////////////KALAU MAU BIKIN LOG, SEBELUM QUERY DI SAVE 'DELETED_AT' KE LOG
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textCustomerID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textCustomerName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textAddress.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textPhoneNumber.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBirth_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMembership_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.Open();
                string sql = "select * from customers where customer_name = '" + textBox1.Text + "' and DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                    lv.SubItems.Add(Reader.GetString(6));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
            else
            {
                tampil();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search by Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search by Name";
                textBox1.ForeColor = Color.Silver;
            }
            tampil();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
