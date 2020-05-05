﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;


namespace Couvee_P3L_Kelompok2
{

    public partial class ProductControl : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='p3l_i_2';username=root;password=");

        public void tampil()
        {
            con.Open();
            string sql = "select * from products where DELETED_AT is NULL ORDER BY CREATED_AT DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetString(4));
                //lv.SubItems.Add(Reader.GetBytes(5));

                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void clear()
        {
            textProductID.Text = String.Empty;
            textProductName.Text = String.Empty;
            textPrice.Text = String.Empty;
            textQuantity.Text = String.Empty;
            pictureBox1.Image = null;
        }

        public ProductControl()
        {
            InitializeComponent();
            tampil();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textProductID.Text == "")
            {
                MessageBox.Show("Please click the product that you want to update on the list.");
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                MySqlCommand command = new MySqlCommand("UPDATE products SET employee_id=@employee_id, product_name=@product_name, product_price=@product_price, product_quantity=@product_quantity, image=@img, UPDATED_AT=@updated_at WHERE product_id=@product_id", con);
                con.Open();

                command.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = Form_Main.id;
                command.Parameters.Add("@product_name", MySqlDbType.VarChar).Value = textProductName.Text;
                command.Parameters.Add("@product_price", MySqlDbType.Float).Value = textPrice.Text;
                command.Parameters.Add("@product_quantity", MySqlDbType.Int32).Value = textQuantity.Text;
                command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
                command.Parameters.Add("@updated_at", MySqlDbType.Timestamp).Value = DateTime.Now;
                command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = textProductID.Text;

                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Product Updated!");
                tampil();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textProductName.Text == "" || textPrice.Text == "" || textQuantity.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill all the box, beside Product ID.");
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                MySqlCommand command = new MySqlCommand("INSERT INTO products(employee_id, product_name, product_price, product_quantity, image, CREATED_AT, UPDATED_AT, DELETED_AT) VALUES (@employee_id,@product_name,@product_price,@product_quantity,@img,@created_at,@updated_at,@deleted_at)", con);
                con.Open();

                command.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = Form_Main.id;
                command.Parameters.Add("@product_name", MySqlDbType.VarChar).Value = textProductName.Text;
                command.Parameters.Add("@product_price", MySqlDbType.Float).Value = textPrice.Text;
                command.Parameters.Add("@product_quantity", MySqlDbType.Int32).Value = textQuantity.Text;
                command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
                command.Parameters.Add("@created_at", MySqlDbType.Timestamp).Value = DateTime.Now;
                command.Parameters.Add("@updated_at", MySqlDbType.Timestamp).Value = null;
                command.Parameters.Add("@deleted_at", MySqlDbType.Timestamp).Value = null;

                command.ExecuteNonQuery();

                string sql = "select * from products where DELETED_AT is NULL ORDER BY `CREATED_AT` DESC";
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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textProductID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textProductName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textPrice.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textQuantity.Text = listView1.SelectedItems[0].SubItems[3].Text;

            con.Open();
            string sql = "SELECT `image` from `products` WHERE `product_id`= '" + textProductID.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(ds.Tables[0].Rows[0]["image"]);
                MemoryStream ms = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(ms);    
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textProductID.Text == "")
            {
                MessageBox.Show("Please click the product that you want to delete from the list.");
            }
            else
            {
                if (MessageBox.Show("Are you Sure?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE `products` SET `DELETED_AT` = current_timestamp() WHERE `product_id` = '" + textProductID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Product Deleted!");
                    clear();
                    tampil();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                string picPath = opf.FileName.ToString();
                pictureBox1.ImageLocation = picPath;
                pictureBox1.Image = Image.FromFile(opf.FileName);

                //pictureBox1.Image = new Bitmap (opf.FileName);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void buttonSortPrice_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "select * from products where DELETED_AT is NULL ORDER BY `product_price` ASC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetString(3));
                lv.SubItems.Add(Reader.GetString(4));
                //lv.SubItems.Add(Reader.GetBytes(5));

                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

        private void buttonSortQuantity_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT * FROM `products` where DELETED_AT is NULL ORDER BY `product_quantity` ASC";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader Reader = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetInt32(3).ToString());
                lv.SubItems.Add(Reader.GetInt32(4).ToString());
                listView1.Items.Add(lv);
            }
            Reader.Close();
            cmd.Dispose();
            con.Close();
        }

       
        private void textSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (textSearch.Text != "")
            {
                con.Open();
                string sql = "select * from products where product_name = '" + textSearch.Text + "' and DELETED_AT is null";
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

        private void ProductControl_Load(object sender, EventArgs e)
        {

        }
    }
    
}
