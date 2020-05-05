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

namespace Couvee_P3L_Kelompok2
{
    public partial class Form_Main : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public static int id = 0, role_id = 0;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "select * from `employees` where username= '" + Form1.name + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();
              
            if (Reader.HasRows)
            {
                Reader.Read(); // read first row
                id = Reader.GetInt32(0);
                role_id = Reader.GetInt32(1);
            }
            con.Close();
        
            label5.Text = "Welcome, " + Form1.name;
            if(role_id == 1)
            {
                label6.Text = "(Owner)";

                SidePanel.Height = buttonProduct.Height;
                SidePanel.Top = buttonProduct.Top;
                productControl1.BringToFront();
            }
            else if (role_id == 2)
            {
                label6.Text = "(CS)";

                SidePanel.Height = buttonDataHewan.Height;
                SidePanel.Top = buttonDataHewan.Top;
                animalDataControl1.BringToFront();

                buttonProduct.Visible = false;
                buttonService.Visible = false;
                buttonEmployee.Visible = false;
                buttonCustomer.Visible = false;
                buttonSupplier.Visible = false;
                buttonTipeHewan.Visible = false;
                buttonUkuranHewan.Visible = false;
            }   
            else
            {
                label6.Text = "(Cashier)";

                SidePanel.Height = buttonCustomer.Height;
                SidePanel.Top = buttonCustomer.Top;
                productControl1.BringToFront();

                buttonProduct.Visible = false;
                buttonService.Visible = false;
                buttonEmployee.Visible = false;
                buttonSupplier.Visible = false;
                buttonDataHewan.Visible = false;
                buttonTipeHewan.Visible = false;
                buttonUkuranHewan.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonCustomer.Height;
            SidePanel.Top = buttonCustomer.Top;
            customerControl1.BringToFront();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonProduct.Height;
            SidePanel.Top = buttonProduct.Top;
            productControl1.BringToFront();
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonService.Height;
            SidePanel.Top = buttonService.Top;
            serviceControl1.BringToFront();

        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonEmployee.Height;
            SidePanel.Top = buttonEmployee.Top;
            employeeControl1.BringToFront();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productControl1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void serviceControl1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customerControl1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 login = new Form1();
            login.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonSupplier.Height;
            SidePanel.Top = buttonSupplier.Top;
            supplierControl1.BringToFront();
        }

        private void buttonHewan_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonDataHewan.Height;
            SidePanel.Top = buttonDataHewan.Top;
            animalDataControl1.BringToFront();
        }

        private void buttonTipeHewan_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonTipeHewan.Height;
            SidePanel.Top = buttonTipeHewan.Top;
            animalTypeControl1.BringToFront();
        }

        private void buttonUkuranHewan_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonUkuranHewan.Height;
            SidePanel.Top = buttonUkuranHewan.Top;
            animalSizeControl1.BringToFront();
        }

        private void animalSizeControl1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
