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
    public partial class ServiceControl : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            string sql = "select * from services where DELETED_AT is NULL ORDER BY CREATED_AT DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
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
            textServiceID.Text = String.Empty;
            textServiceName.Text = String.Empty;
            textPrice.Text = String.Empty;
        }

        public ServiceControl()
        {
            InitializeComponent();
            tampil();
        }

        private void ServiceControl_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textServiceName.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Service ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `services` (`employee_id`, `service_name`, `service_price`, `CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('" + Form_Main.id + "', '" + textServiceName.Text + "', '" + float.Parse(textPrice.Text) + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Service Added!");

                string sql = "select * from services where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();

                con.Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textServiceID.Text == "")
            {
                MessageBox.Show("Please click the service that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `services` SET `employee_id` = '" + Form_Main.id + "' , `service_name` = '" + textServiceName.Text + "', `service_price`= '" + float.Parse(textPrice.Text) + "', `UPDATED_AT`= current_timestamp() WHERE `service_id`= '" + textServiceID.Text + "'";
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Service Updated!");
                tampil();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textServiceID.Text == "")
            {
                MessageBox.Show("Please click the service that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Service", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `services` SET `DELETED_AT` = current_timestamp() WHERE `service_id` = '" + textServiceID.Text + "'";
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Service Deleted!");
                    clear();
                    tampil();
                }
            }
        }

        private void textProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textServiceID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textServiceName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textPrice.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void textSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select * from services where service_name = '"+textSearch.Text+"' and DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
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
