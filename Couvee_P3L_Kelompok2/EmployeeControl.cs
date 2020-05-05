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
    public partial class EmployeeControl : UserControl
    {
        public static int role_id = 0;
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            //string sql = "select * from employees where DELETED_AT is NULL";
            string sql = "select e.employee_id, r.role_name, e.employee_name, e.employee_address, e.employee_phoneno, e.employee_birth, e.username, e.password from employees e join roles r on e.role_id = r.role_id where DELETED_AT is NULL ORDER BY CREATED_AT DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(1));
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetString(4));
                lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                lv.SubItems.Add(Reader.GetString(6));
                lv.SubItems.Add(Reader.GetString(7));
                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void clear()
        {
            textEmployeeID.Text = String.Empty;
            textRoleID.Text = String.Empty;
            textEmployeeName.Text = String.Empty;
            textAddress.Text = String.Empty;
            textPhoneNumber.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            textUsername.Text = String.Empty;
            textPassword.Text = String.Empty;
        }

        public EmployeeControl()
        {
            InitializeComponent();
            tampil();
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeControl_Load(object sender, EventArgs e)
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
            int role_id=0;

            if (textRoleID.Text=="" || textEmployeeName.Text == "" || textAddress.Text == "" || textPhoneNumber.Text == "" || dateTimePicker1.Text == "" || textUsername.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Please fill all the box, beside Employee ID.");
            }
            else
            {
                if(textRoleID.Text=="Owner")
                {
                    role_id = 1;
                }
                else if(textRoleID.Text=="CS")
                {
                    role_id = 2;
                }
                else
                {
                    role_id = 3;
                }

                con.Open();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO `employees` (`role_id`, `employee_name`, `employee_address`, `employee_phoneno`, `employee_birth`, `username`, `password` , `CREATED_AT`, `UPDATED_AT`, `DELETED_AT`) VALUES('"+ role_id + "', '" + textEmployeeName.Text + "', '" + textAddress.Text + "', '" + Convert.ToInt32(textPhoneNumber.Text) + "', '" + dateTimePicker1.Text + "', '" + textUsername.Text + "', '" + textPassword.Text + "', current_timestamp(), NULL, NULL)";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Employee Added!");

                string sql = "select e.employee_id, r.role_name, e.employee_name, e.employee_address, e.employee_phoneno, e.employee_birth, e.username, e.password from employees e join roles r on e.role_id = r.role_id where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(1));
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetInt32(4).ToString());
                    lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                    lv.SubItems.Add(Reader.GetString(6));
                    lv.SubItems.Add(Reader.GetString(7));
                    listView1.Items.Add(lv);
                }
                Reader.Close();
                cmd.Dispose();
                con.Close();
            }  
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            if (textEmployeeID.Text=="")
            {
                MessageBox.Show("Please click the employee that you want to update on the list.");
            }
            else
            {
                if(textRoleID.Text=="Owner")
                {
                    role_id = 1;
                }
                else if(textRoleID.Text=="CS")
                {
                    role_id = 2;
                }
                else
                {
                    role_id = 3;
                }

                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE `employees` SET `role_id` = '" + role_id + "',  `employee_name` = '" + textEmployeeName.Text + "', `employee_address`= '" + textAddress.Text + "', `employee_phoneno`= '" + Convert.ToInt32(textPhoneNumber.Text) + "', `employee_birth`= '" + dateTimePicker1.Text + "', `username`= '" + textUsername.Text + "', `password`= '" + textPassword.Text + "',`UPDATED_AT`= current_timestamp() WHERE `employee_id`= '" + textEmployeeID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee Updated!");
                tampil();
            }  
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textEmployeeID.Text == "")
            {
                MessageBox.Show("Please click the employee that you want to delete on the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `employees` SET `DELETED_AT` = current_timestamp() WHERE `employee_id` = '" + textEmployeeID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Employee Deleted!");

                    clear();
                    tampil();
                }
            }
        }

        private void textEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textEmployeeID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textRoleID.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textEmployeeName.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textAddress.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textPhoneNumber.Text = listView1.SelectedItems[0].SubItems[4].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textUsername.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textPassword.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select e.employee_id, r.role_name, e.employee_name, e.employee_address, e.employee_phoneno, e.employee_birth, e.username, e.password from employees e join roles r on e.role_id = r.role_id where e.employee_name = '" + textSearch.Text + "' and DELETED_AT is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (Reader.Read())
                {
                    ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                    lv.SubItems.Add(Reader.GetString(1));
                    lv.SubItems.Add(Reader.GetString(2));
                    lv.SubItems.Add(Reader.GetString(3));
                    lv.SubItems.Add(Reader.GetString(4));
                    lv.SubItems.Add(Reader.GetDateTime(5).ToString(@"yyyy-MM-dd"));
                    lv.SubItems.Add(Reader.GetString(6));
                    lv.SubItems.Add(Reader.GetString(7));
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
            if(textSearch.Text == "Search by Name")
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

        private void textRoleID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
