namespace Couvee_P3L_Kelompok2
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.animalSizeControl1 = new Couvee_P3L_Kelompok2.AnimalSizeControl();
            this.animalTypeControl1 = new Couvee_P3L_Kelompok2.AnimalTypeControl();
            this.animalDataControl1 = new Couvee_P3L_Kelompok2.AnimalDataControl();
            this.supplierControl1 = new Couvee_P3L_Kelompok2.SupplierControl();
            this.customerControl1 = new Couvee_P3L_Kelompok2.CustomerControl();
            this.employeeControl1 = new Couvee_P3L_Kelompok2.EmployeeControl();
            this.serviceControl1 = new Couvee_P3L_Kelompok2.ServiceControl();
            this.productControl1 = new Couvee_P3L_Kelompok2.ProductControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonUkuranHewan = new System.Windows.Forms.Button();
            this.buttonTipeHewan = new System.Windows.Forms.Button();
            this.buttonDataHewan = new System.Windows.Forms.Button();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.buttonCustomer = new System.Windows.Forms.Button();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonService = new System.Windows.Forms.Button();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(203, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "MAIN MENU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(176, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 86);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Black;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(646, 25);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(107, 28);
            this.buttonLogout.TabIndex = 12;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.icon;
            this.pictureBox2.Location = new System.Drawing.Point(5, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.animalSizeControl1);
            this.panel4.Controls.Add(this.animalTypeControl1);
            this.panel4.Controls.Add(this.animalDataControl1);
            this.panel4.Controls.Add(this.supplierControl1);
            this.panel4.Controls.Add(this.customerControl1);
            this.panel4.Controls.Add(this.employeeControl1);
            this.panel4.Controls.Add(this.serviceControl1);
            this.panel4.Controls.Add(this.productControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(176, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 463);
            this.panel4.TabIndex = 13;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // animalSizeControl1
            // 
            this.animalSizeControl1.Location = new System.Drawing.Point(0, 0);
            this.animalSizeControl1.Margin = new System.Windows.Forms.Padding(2);
            this.animalSizeControl1.Name = "animalSizeControl1";
            this.animalSizeControl1.Size = new System.Drawing.Size(770, 464);
            this.animalSizeControl1.TabIndex = 7;
            this.animalSizeControl1.Load += new System.EventHandler(this.animalSizeControl1_Load);
            // 
            // animalTypeControl1
            // 
            this.animalTypeControl1.Location = new System.Drawing.Point(0, 0);
            this.animalTypeControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.animalTypeControl1.Name = "animalTypeControl1";
            this.animalTypeControl1.Size = new System.Drawing.Size(770, 464);
            this.animalTypeControl1.TabIndex = 6;
            // 
            // animalDataControl1
            // 
            this.animalDataControl1.Location = new System.Drawing.Point(0, 0);
            this.animalDataControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.animalDataControl1.Name = "animalDataControl1";
            this.animalDataControl1.Size = new System.Drawing.Size(770, 464);
            this.animalDataControl1.TabIndex = 5;
            // 
            // supplierControl1
            // 
            this.supplierControl1.Location = new System.Drawing.Point(0, 3);
            this.supplierControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.supplierControl1.Name = "supplierControl1";
            this.supplierControl1.Size = new System.Drawing.Size(770, 464);
            this.supplierControl1.TabIndex = 4;
            // 
            // customerControl1
            // 
            this.customerControl1.Location = new System.Drawing.Point(0, 0);
            this.customerControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerControl1.Name = "customerControl1";
            this.customerControl1.Size = new System.Drawing.Size(770, 464);
            this.customerControl1.TabIndex = 3;
            this.customerControl1.Load += new System.EventHandler(this.customerControl1_Load);
            // 
            // employeeControl1
            // 
            this.employeeControl1.Location = new System.Drawing.Point(0, 0);
            this.employeeControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.employeeControl1.Name = "employeeControl1";
            this.employeeControl1.Size = new System.Drawing.Size(770, 464);
            this.employeeControl1.TabIndex = 2;
            // 
            // serviceControl1
            // 
            this.serviceControl1.Location = new System.Drawing.Point(0, 0);
            this.serviceControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serviceControl1.Name = "serviceControl1";
            this.serviceControl1.Size = new System.Drawing.Size(770, 577);
            this.serviceControl1.TabIndex = 1;
            this.serviceControl1.Load += new System.EventHandler(this.serviceControl1_Load);
            // 
            // productControl1
            // 
            this.productControl1.Location = new System.Drawing.Point(0, 0);
            this.productControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productControl1.Name = "productControl1";
            this.productControl1.Size = new System.Drawing.Size(770, 464);
            this.productControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(59, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "KOUVEE PET";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(85, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "SHOP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.White;
            this.SidePanel.Location = new System.Drawing.Point(0, 136);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 45);
            this.SidePanel.TabIndex = 13;
            this.SidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(60, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 14;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.buttonUkuranHewan);
            this.panel1.Controls.Add(this.buttonTipeHewan);
            this.panel1.Controls.Add(this.buttonDataHewan);
            this.panel1.Controls.Add(this.buttonSupplier);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.buttonCustomer);
            this.panel1.Controls.Add(this.buttonEmployee);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.buttonService);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 547);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonUkuranHewan
            // 
            this.buttonUkuranHewan.FlatAppearance.BorderSize = 0;
            this.buttonUkuranHewan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUkuranHewan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUkuranHewan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUkuranHewan.Image = ((System.Drawing.Image)(resources.GetObject("buttonUkuranHewan.Image")));
            this.buttonUkuranHewan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUkuranHewan.Location = new System.Drawing.Point(12, 492);
            this.buttonUkuranHewan.Name = "buttonUkuranHewan";
            this.buttonUkuranHewan.Size = new System.Drawing.Size(164, 45);
            this.buttonUkuranHewan.TabIndex = 19;
            this.buttonUkuranHewan.Text = "ANIMAL SIZE";
            this.buttonUkuranHewan.UseVisualStyleBackColor = true;
            this.buttonUkuranHewan.Click += new System.EventHandler(this.buttonUkuranHewan_Click);
            // 
            // buttonTipeHewan
            // 
            this.buttonTipeHewan.FlatAppearance.BorderSize = 0;
            this.buttonTipeHewan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTipeHewan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTipeHewan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTipeHewan.Image = ((System.Drawing.Image)(resources.GetObject("buttonTipeHewan.Image")));
            this.buttonTipeHewan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTipeHewan.Location = new System.Drawing.Point(12, 442);
            this.buttonTipeHewan.Name = "buttonTipeHewan";
            this.buttonTipeHewan.Size = new System.Drawing.Size(164, 45);
            this.buttonTipeHewan.TabIndex = 18;
            this.buttonTipeHewan.Text = "ANIMAL TYPE";
            this.buttonTipeHewan.UseVisualStyleBackColor = true;
            this.buttonTipeHewan.Click += new System.EventHandler(this.buttonTipeHewan_Click);
            // 
            // buttonDataHewan
            // 
            this.buttonDataHewan.FlatAppearance.BorderSize = 0;
            this.buttonDataHewan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataHewan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataHewan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDataHewan.Image = ((System.Drawing.Image)(resources.GetObject("buttonDataHewan.Image")));
            this.buttonDataHewan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDataHewan.Location = new System.Drawing.Point(12, 391);
            this.buttonDataHewan.Name = "buttonDataHewan";
            this.buttonDataHewan.Size = new System.Drawing.Size(164, 45);
            this.buttonDataHewan.TabIndex = 17;
            this.buttonDataHewan.Text = "ANIMAL DATA";
            this.buttonDataHewan.UseVisualStyleBackColor = true;
            this.buttonDataHewan.Click += new System.EventHandler(this.buttonHewan_Click);
            // 
            // buttonSupplier
            // 
            this.buttonSupplier.FlatAppearance.BorderSize = 0;
            this.buttonSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupplier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSupplier.Image = ((System.Drawing.Image)(resources.GetObject("buttonSupplier.Image")));
            this.buttonSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSupplier.Location = new System.Drawing.Point(12, 340);
            this.buttonSupplier.Name = "buttonSupplier";
            this.buttonSupplier.Size = new System.Drawing.Size(164, 45);
            this.buttonSupplier.TabIndex = 16;
            this.buttonSupplier.Text = "SUPPLIER";
            this.buttonSupplier.UseVisualStyleBackColor = true;
            this.buttonSupplier.Click += new System.EventHandler(this.buttonSupplier_Click);
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.FlatAppearance.BorderSize = 0;
            this.buttonCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCustomer.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.customer2;
            this.buttonCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustomer.Location = new System.Drawing.Point(12, 289);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.Size = new System.Drawing.Size(164, 45);
            this.buttonCustomer.TabIndex = 14;
            this.buttonCustomer.Text = "CUSTOMER";
            this.buttonCustomer.UseVisualStyleBackColor = true;
            this.buttonCustomer.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.FlatAppearance.BorderSize = 0;
            this.buttonEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEmployee.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.employee2;
            this.buttonEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEmployee.Location = new System.Drawing.Point(12, 238);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(164, 45);
            this.buttonEmployee.TabIndex = 13;
            this.buttonEmployee.Text = "EMPLOYEE";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.dog_solid1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonService
            // 
            this.buttonService.FlatAppearance.BorderSize = 0;
            this.buttonService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonService.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonService.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.service2;
            this.buttonService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonService.Location = new System.Drawing.Point(12, 188);
            this.buttonService.Name = "buttonService";
            this.buttonService.Size = new System.Drawing.Size(164, 45);
            this.buttonService.TabIndex = 12;
            this.buttonService.Text = "SERVICE";
            this.buttonService.UseVisualStyleBackColor = true;
            this.buttonService.Click += new System.EventHandler(this.buttonService_Click);
            // 
            // buttonProduct
            // 
            this.buttonProduct.FlatAppearance.BorderSize = 0;
            this.buttonProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonProduct.Image = global::Couvee_P3L_Kelompok2.Properties.Resources.product6;
            this.buttonProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProduct.Location = new System.Drawing.Point(12, 136);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(164, 45);
            this.buttonProduct.TabIndex = 11;
            this.buttonProduct.Text = "PRODUCT";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private ServiceControl serviceControl1;
        private ProductControl productControl1;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonService;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonCustomer;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private EmployeeControl employeeControl1;
        private CustomerControl customerControl1;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonSupplier;
        private SupplierControl supplierControl1;
        private System.Windows.Forms.Button buttonDataHewan;
        private System.Windows.Forms.Button buttonUkuranHewan;
        private System.Windows.Forms.Button buttonTipeHewan;
        private AnimalSizeControl animalSizeControl1;
        private AnimalTypeControl animalTypeControl1;
        private AnimalDataControl animalDataControl1;
    }
}