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
    public partial class AnimalDataControl : UserControl
    {

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public static int type = 0, cust = 0;
        public static string typeName = "";

        public void tampil()
        {
            con.Open();
            string sql = "select a.animal_id, a.animal_name, c.customer_name, att.type_name, a.animal_birth from animals a join customers c on a.customer_id = c.customer_id join animal_types att on a.type_id = att.type_id where a.DELETED_AT is NULL";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(1));
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetDateTime(4).ToString(@"yyyy-MM-dd"));
                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void clear()
        {
            textAnimalName.Text = String.Empty;
            textAnimalID.Text = String.Empty;
            textCust.Text = String.Empty;
            textType.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
        }

        public AnimalDataControl()
        {
            InitializeComponent();
            tampil();
            fillComboType();
            fillComboCust();
        }


        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select a.animal_id, a.animal_name, c.customer_name, att.type_name, a.animal_birth from animals a join customers c on a.customer_id = c.customer_id join animal_types att on a.type_id = att.type_id where a.animal_name = '" + textSearch.Text + "' and a.DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(1));
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetDateTime(4).ToString(@"yyyy-MM-dd"));
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
            if (textSearch.Text == "Search by Animal Name")
            {
                textSearch.Text = "";
                textSearch.ForeColor = Color.Black;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql5 = "select * from `customers` where customer_name= '" + textCust.Text + "' and DELETED_AT is NULL";
            MySqlCommand cmd5 = new MySqlCommand(sql5, con);
            MySqlDataReader Reader5 = cmd5.ExecuteReader();
            
            if (Reader5.HasRows)
            {
                Reader5.Read(); // read first row
                cust = Reader5.GetInt32(0);
            }

            con.Close();

            con.Open();

            string sql6 = "select * from `animal_types` where type_name= '" + textType.Text + "' and DELETED_AT is NULL";
            MySqlCommand cmd6 = new MySqlCommand(sql6, con);
            MySqlDataReader Reader6 = cmd6.ExecuteReader();

            if (Reader6.HasRows)
            {
                Reader6.Read(); // read first row
                type = Reader6.GetInt32(0);
                typeName = Reader6.GetString(2);
            }

            con.Close();

            if (textAnimalName.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Animal ID.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `animals` (`employee_id`,`type_id`,`customer_id`,`animal_name`,`animal_birth`,`CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('" + Form_Main.id + "','" + type + "','" + cust + "','" + textAnimalName.Text + "','" + dateTimePicker1.Text + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Animal Added!");

                string sql = "select a.animal_id, a.animal_name, c.customer_name, att.type_name, a.animal_birth from animals a join customers c on a.customer_id = c.customer_id join animal_types att on a.type_id = att.type_id where a.DELETED_AT is NULL ORDER BY a.CREATED_AT DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(1));
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetDateTime(4).ToString(@"yyyy-MM-dd"));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }
        }

        public void fillComboType()
        {
            string sql7 = "select * from animal_types where DELETED_AT is NULL";
            MySqlCommand cmd7 = new MySqlCommand(sql7, con);
            MySqlDataReader Reader7;
            try
            {
                con.Open();
                Reader7 = cmd7.ExecuteReader();
                while(Reader7.Read())
                {
                    string sname = Reader7.GetString(2);
                    textType.Items.Add(sname);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                con.Close();
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                textSearch.Text = "Search by Animal Name";
                textSearch.ForeColor = Color.Silver;
            }
            tampil();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql5 = "select * from `customers` where customer_name= '" + textCust.Text + "' and DELETED_AT is NULL";
            MySqlCommand cmd5 = new MySqlCommand(sql5, con);
            MySqlDataReader Reader5 = cmd5.ExecuteReader();

            if (Reader5.HasRows)
            {
                Reader5.Read(); // read first row
                cust = Reader5.GetInt32(0);
            }

            con.Close();

            con.Open();

            string sql6 = "select * from `animal_types` where type_name= '" + textType.Text + "' and DELETED_AT is NULL";
            MySqlCommand cmd6 = new MySqlCommand(sql6, con);
            MySqlDataReader Reader6 = cmd6.ExecuteReader();

            if (Reader6.HasRows)
            {
                Reader6.Read(); // read first row
                type = Reader6.GetInt32(0);
                typeName = Reader6.GetString(2);
            }

            con.Close();

            if (textAnimalID.Text == "")
            {
                MessageBox.Show("Please click the Size that you want to update on the list.");
            }
            else
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `animals` SET `type_id`='"+type+"', `customer_id`='" + cust + "', `animal_name` = '" + textAnimalName.Text + "',`animal_birth` = '" + dateTimePicker1.Text + "', `UPDATED_AT` = current_timestamp() WHERE `animal_id` = '" + textAnimalID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Animal Data Updated!");
                tampil();
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textAnimalID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textAnimalName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textCust.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textType.Text = listView1.SelectedItems[0].SubItems[3].Text;    
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textAnimalID.Text == "")
            {
                MessageBox.Show("Please click the animal data that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Animal Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `animals` SET `DELETED_AT` = current_timestamp() WHERE `animal_id` = '" + textAnimalID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Animal Data Deleted!");
                    clear();
                    tampil();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textCust_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void fillComboCust()
        {
            string sql8 = "select * from customers where DELETED_AT is NULL";
            MySqlCommand cmd8 = new MySqlCommand(sql8, con);
            MySqlDataReader Reader8;
            try
            {
                con.Open();
                Reader8 = cmd8.ExecuteReader();
                while (Reader8.Read())
                {
                    string sname = Reader8.GetString(2);
                    textCust.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                con.Close();
        }
    }
}
