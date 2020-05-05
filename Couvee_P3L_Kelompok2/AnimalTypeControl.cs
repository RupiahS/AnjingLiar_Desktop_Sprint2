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
    public partial class AnimalTypeControl : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            string sql = "select * from animal_types where DELETED_AT is null ORDER BY CREATED_AT DESC";
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
            textTypeID.Text = String.Empty;
            textTypeName.Text = String.Empty;
        }

        public AnimalTypeControl()
        {
            InitializeComponent();
            tampil();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select * from animal_types where type_name = '"+textSearch.Text+"' and DELETED_AT is null";
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textRoleID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textTypeName.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Type ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `animal_types` (`employee_id`, `type_name`, `CREATED_AT`) VALUES('" + Form_Main.id + "','" + textTypeName.Text + "', current_timestamp())";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Animal Type Added!");

                string sql = "select * from animal_types where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
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
            if (textTypeID.Text == "")
            {
                MessageBox.Show("Please click the Type that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `animal_types` SET `type_name` = '" + textTypeName.Text + "', `UPDATED_AT` = current_timestamp() WHERE `type_id` = '" + textTypeID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Animal Type Updated!");
                tampil();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textTypeID.Text == "")
            {
                MessageBox.Show("Please click the animal type that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Animal Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `animal_types` SET `DELETED_AT` = current_timestamp() WHERE `type_id` = '" + textTypeID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Animal Type Deleted!");
                    clear();
                    tampil();
                }
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
            if(textSearch.Text == "")
            {
                textSearch.Text = "Search by Name";
                textSearch.ForeColor = Color.Silver;
            }
            tampil();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textTypeID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textTypeName.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AnimalTypeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
