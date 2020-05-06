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
    public partial class AnimalSizeControl : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");
        public void tampil()
        {
            con.Open();
            string sql = "select * from sizes where DELETED_AT is NULL";
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

        public void clear()
        {
            textSizeID.Text = String.Empty;
            textSizeName.Text = String.Empty;
        }

        public AnimalSizeControl()
        {
            InitializeComponent();
            tampil();
        }

        private void AnimalSizeControl_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textSizeID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textSizeName.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select * from sizes where size_name = '" + textSearch.Text + "' and DELETED_AT is NULL" ;
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textSizeName.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Size ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `sizes` (`employee_id`, `size_name`, `CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('" + Form_Main.id + "','" + textSizeName.Text + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Animal Size Added!");

                string sql = "select * from sizes where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
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
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textSizeID.Text == "")
            {
                MessageBox.Show("Please click the Size that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `Sizes` SET `size_name` = '" + textSizeName.Text + "', `UPDATED_AT` = current_timestamp() WHERE `size_id` = '" + textSizeID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Animal Size Updated!");
                tampil();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textSizeID.Text == "")
            {
                MessageBox.Show("Please click the animal size that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Animal Size", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `sizes` SET `DELETED_AT` = current_timestamp() WHERE `size_id` = '" + textSizeID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Animal Size Deleted!");
                    clear();
                    tampil();
                }
            }
        }
    }
}
