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
    public partial class SupplierControl : UserControl
    {

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            string sql = "select * from suppliers where DELETED_AT is NULL ORDER BY CREATED_AT DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetString(4));
                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void clear()
        {
            textSupplierID.Text = String.Empty;
            textSupplierName.Text = String.Empty;
            textSupplierAdd.Text = String.Empty;
            textSupplierPhone.Text = String.Empty;
        }

        public SupplierControl()
        {
            InitializeComponent();
            tampil();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textSupplierName.Text == "" || textSupplierAdd.Text == "" || textSupplierPhone.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Supplier ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `suppliers` (`employee_id`,`supplier_name`, `supplier_address`, `supplier_phoneno`, `CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('" + Form_Main.id + "','" + textSupplierName.Text + "', '" + textSupplierAdd.Text + "', '" + Convert.ToInt32(textSupplierPhone.Text) + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                string sql = "select * from suppliers where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textSupplierID.Text=="")
            {
                MessageBox.Show("Please click the Supplier that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `suppliers` SET `supplier_name` = '" + textSupplierName.Text + "', `supplier_address`= '" + textSupplierAdd.Text + "', `supplier_phoneno`= '" + Convert.ToInt32(textSupplierPhone.Text) + "',`UPDATED_AT`= current_timestamp() WHERE `supplier_id`= '" + textSupplierID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Service Updated!");
                tampil();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textSupplierID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textSupplierName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textSupplierAdd.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textSupplierPhone.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textSupplierID.Text == "")
            {
                MessageBox.Show("Please click the supplier that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `suppliers` SET `DELETED_AT` = current_timestamp() WHERE `supplier_id`= '" + textSupplierID.Text + "'";
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Supplier Deleted!");
                    clear();
                    tampil();
                   
                }
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {  

            if (textSearch.Text == "")
            {
                con.Open();
                string sql = "select * from suppliers where DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
            else
            {
                con.Open();
                string sql = "select * from suppliers where supplier_name = '"+textSearch.Text+ "' and DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select * from suppliers where supplier_name = '" + textSearch.Text + "' and DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(2));
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

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Search by Name")
            {
                textSearch.Text = "";
                textSearch.ForeColor = Color.Black;
            }
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                textSearch.Text = "Search by Name";
                textSearch.ForeColor = Color.Silver;
            }
            tampil();
        }
    }
}
