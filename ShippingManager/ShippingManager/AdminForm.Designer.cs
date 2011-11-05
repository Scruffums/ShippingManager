namespace ShippingManager
{
    partial class AdminForm
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
            this.button6 = new System.Windows.Forms.Button();
            this.objectsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.employeeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.employeeAddButton = new System.Windows.Forms.Button();
            this.employeeEditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.employeesListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.locationVolumeCapacityTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.locationZipcodesServedTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.locationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.locationAddButton = new System.Windows.Forms.Button();
            this.locationZipCodetextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.locationStreetAddressTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.locationIdTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.locationEditButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.locationsListBox = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.objectsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(532, 475);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Logout";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // objectsTabControl
            // 
            this.objectsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsTabControl.Controls.Add(this.tabPage1);
            this.objectsTabControl.Controls.Add(this.tabPage2);
            this.objectsTabControl.Controls.Add(this.tabPage5);
            this.objectsTabControl.Controls.Add(this.tabPage4);
            this.objectsTabControl.Location = new System.Drawing.Point(12, 12);
            this.objectsTabControl.Name = "objectsTabControl";
            this.objectsTabControl.SelectedIndex = 0;
            this.objectsTabControl.Size = new System.Drawing.Size(595, 457);
            this.objectsTabControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.confirmPasswordTextBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lastNameTextBox);
            this.tabPage1.Controls.Add(this.middleNameTextBox);
            this.tabPage1.Controls.Add(this.firstNameTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.newPasswordTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.idTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.employeeTypeComboBox);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.employeeAddButton);
            this.tabPage1.Controls.Add(this.employeeEditButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.employeesListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(587, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(310, 277);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.confirmPasswordTextBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Confirm Password:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(452, 314);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 6;
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(267, 314);
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.middleNameTextBox.TabIndex = 5;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(72, 314);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Last Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Middle Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "First Name:";
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(84, 277);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "New Password:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(84, 251);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type:";
            // 
            // employeeTypeComboBox
            // 
            this.employeeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeTypeComboBox.FormattingEnabled = true;
            this.employeeTypeComboBox.Items.AddRange(new object[] {
            "Admin",
            "Acceptance",
            "Warehouse",
            "Delivery"});
            this.employeeTypeComboBox.Location = new System.Drawing.Point(46, 213);
            this.employeeTypeComboBox.Name = "employeeTypeComboBox";
            this.employeeTypeComboBox.Size = new System.Drawing.Size(124, 21);
            this.employeeTypeComboBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(11, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 2);
            this.panel1.TabIndex = 4;
            // 
            // employeeAddButton
            // 
            this.employeeAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeAddButton.Location = new System.Drawing.Point(488, 402);
            this.employeeAddButton.Name = "employeeAddButton";
            this.employeeAddButton.Size = new System.Drawing.Size(93, 23);
            this.employeeAddButton.TabIndex = 8;
            this.employeeAddButton.Text = "&Add";
            this.employeeAddButton.UseVisualStyleBackColor = true;
            this.employeeAddButton.Click += new System.EventHandler(this.employeeAddButton_Click);
            // 
            // employeeEditButton
            // 
            this.employeeEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeEditButton.Enabled = false;
            this.employeeEditButton.Location = new System.Drawing.Point(506, 173);
            this.employeeEditButton.Name = "employeeEditButton";
            this.employeeEditButton.Size = new System.Drawing.Size(75, 23);
            this.employeeEditButton.TabIndex = 2;
            this.employeeEditButton.Text = "&Edit";
            this.employeeEditButton.UseVisualStyleBackColor = true;
            this.employeeEditButton.Click += new System.EventHandler(this.employeeEditButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Employees:";
            // 
            // employeesListBox
            // 
            this.employeesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeesListBox.FormattingEnabled = true;
            this.employeesListBox.Location = new System.Drawing.Point(6, 19);
            this.employeesListBox.Name = "employeesListBox";
            this.employeesListBox.Size = new System.Drawing.Size(575, 147);
            this.employeesListBox.TabIndex = 0;
            this.employeesListBox.SelectedIndexChanged += new System.EventHandler(this.employeesListBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.locationVolumeCapacityTextBox);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.locationZipcodesServedTextBox);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.locationTypeComboBox);
            this.tabPage2.Controls.Add(this.locationAddButton);
            this.tabPage2.Controls.Add(this.locationZipCodetextBox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.locationStreetAddressTextBox);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.locationIdTextBox);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.locationEditButton);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.locationsListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(587, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Locations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // locationVolumeCapacityTextBox
            // 
            this.locationVolumeCapacityTextBox.Enabled = false;
            this.locationVolumeCapacityTextBox.Location = new System.Drawing.Point(244, 286);
            this.locationVolumeCapacityTextBox.Name = "locationVolumeCapacityTextBox";
            this.locationVolumeCapacityTextBox.Size = new System.Drawing.Size(100, 20);
            this.locationVolumeCapacityTextBox.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(150, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Volume capacity:";
            // 
            // locationZipcodesServedTextBox
            // 
            this.locationZipcodesServedTextBox.Enabled = false;
            this.locationZipcodesServedTextBox.Location = new System.Drawing.Point(10, 318);
            this.locationZipcodesServedTextBox.Multiline = true;
            this.locationZipcodesServedTextBox.Name = "locationZipcodesServedTextBox";
            this.locationZipcodesServedTextBox.Size = new System.Drawing.Size(457, 88);
            this.locationZipcodesServedTextBox.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Zip codes served:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Type:";
            // 
            // locationTypeComboBox
            // 
            this.locationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationTypeComboBox.FormattingEnabled = true;
            this.locationTypeComboBox.Items.AddRange(new object[] {
            "Store Front",
            "Warehouse",
            "Abroad"});
            this.locationTypeComboBox.Location = new System.Drawing.Point(47, 207);
            this.locationTypeComboBox.Name = "locationTypeComboBox";
            this.locationTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.locationTypeComboBox.TabIndex = 20;
            this.locationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.locationTypeComboBox_SelectedIndexChanged);
            // 
            // locationAddButton
            // 
            this.locationAddButton.Location = new System.Drawing.Point(489, 402);
            this.locationAddButton.Name = "locationAddButton";
            this.locationAddButton.Size = new System.Drawing.Size(89, 23);
            this.locationAddButton.TabIndex = 19;
            this.locationAddButton.Text = "&Add";
            this.locationAddButton.UseVisualStyleBackColor = true;
            this.locationAddButton.Click += new System.EventHandler(this.locationAddButton_Click);
            // 
            // locationZipCodetextBox
            // 
            this.locationZipCodetextBox.Location = new System.Drawing.Point(244, 259);
            this.locationZipCodetextBox.Name = "locationZipCodetextBox";
            this.locationZipCodetextBox.Size = new System.Drawing.Size(100, 20);
            this.locationZipCodetextBox.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Zip code:";
            // 
            // locationStreetAddressTextBox
            // 
            this.locationStreetAddressTextBox.Location = new System.Drawing.Point(244, 233);
            this.locationStreetAddressTextBox.Name = "locationStreetAddressTextBox";
            this.locationStreetAddressTextBox.Size = new System.Drawing.Size(223, 20);
            this.locationStreetAddressTextBox.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(159, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Street Address:";
            // 
            // locationIdTextBox
            // 
            this.locationIdTextBox.Location = new System.Drawing.Point(47, 233);
            this.locationIdTextBox.Name = "locationIdTextBox";
            this.locationIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.locationIdTextBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(3, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 2);
            this.panel2.TabIndex = 6;
            // 
            // locationEditButton
            // 
            this.locationEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.locationEditButton.Enabled = false;
            this.locationEditButton.Location = new System.Drawing.Point(503, 173);
            this.locationEditButton.Name = "locationEditButton";
            this.locationEditButton.Size = new System.Drawing.Size(75, 23);
            this.locationEditButton.TabIndex = 5;
            this.locationEditButton.Text = "&Edit";
            this.locationEditButton.UseVisualStyleBackColor = true;
            this.locationEditButton.Click += new System.EventHandler(this.locationEditButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Current Locations";
            // 
            // locationsListBox
            // 
            this.locationsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationsListBox.FormattingEnabled = true;
            this.locationsListBox.Location = new System.Drawing.Point(3, 19);
            this.locationsListBox.Name = "locationsListBox";
            this.locationsListBox.Size = new System.Drawing.Size(575, 147);
            this.locationsListBox.TabIndex = 3;
            this.locationsListBox.SelectedIndexChanged += new System.EventHandler(this.locationsListBox_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(587, 431);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Transports & Delivery Vehicles";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(587, 431);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Routes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 510);
            this.Controls.Add(this.objectsTabControl);
            this.Controls.Add(this.button6);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.objectsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabControl objectsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox employeeTypeComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button employeeAddButton;
        private System.Windows.Forms.Button employeeEditButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox employeesListBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button locationEditButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox locationsListBox;
        private System.Windows.Forms.Button locationAddButton;
        private System.Windows.Forms.TextBox locationZipCodetextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox locationStreetAddressTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox locationIdTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox locationZipcodesServedTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox locationTypeComboBox;
        private System.Windows.Forms.TextBox locationVolumeCapacityTextBox;
        private System.Windows.Forms.Label label15;

    }
}