namespace ShippingManager
{
    partial class DeliveryForm
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
            this.familyMemberRadioButton = new System.Windows.Forms.RadioButton();
            this.customerNotHomeRadioButton = new System.Windows.Forms.RadioButton();
            this.customerReceivedRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.familyMemberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.recepientNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.responsibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.streetAddressTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // familyMemberRadioButton
            // 
            this.familyMemberRadioButton.AutoSize = true;
            this.familyMemberRadioButton.Location = new System.Drawing.Point(240, 76);
            this.familyMemberRadioButton.Name = "familyMemberRadioButton";
            this.familyMemberRadioButton.Size = new System.Drawing.Size(227, 17);
            this.familyMemberRadioButton.TabIndex = 34;
            this.familyMemberRadioButton.TabStop = true;
            this.familyMemberRadioButton.Text = "Customer family member received package";
            this.familyMemberRadioButton.UseVisualStyleBackColor = true;
            this.familyMemberRadioButton.CheckedChanged += new System.EventHandler(this.familyMemberRadioButton_CheckedChanged);
            // 
            // customerNotHomeRadioButton
            // 
            this.customerNotHomeRadioButton.AutoSize = true;
            this.customerNotHomeRadioButton.Location = new System.Drawing.Point(240, 53);
            this.customerNotHomeRadioButton.Name = "customerNotHomeRadioButton";
            this.customerNotHomeRadioButton.Size = new System.Drawing.Size(353, 17);
            this.customerNotHomeRadioButton.TabIndex = 33;
            this.customerNotHomeRadioButton.TabStop = true;
            this.customerNotHomeRadioButton.Text = "Customer was not home but package was  left as at address provided";
            this.customerNotHomeRadioButton.UseVisualStyleBackColor = true;
            // 
            // customerReceivedRadioButton
            // 
            this.customerReceivedRadioButton.AutoSize = true;
            this.customerReceivedRadioButton.Location = new System.Drawing.Point(240, 30);
            this.customerReceivedRadioButton.Name = "customerReceivedRadioButton";
            this.customerReceivedRadioButton.Size = new System.Drawing.Size(176, 17);
            this.customerReceivedRadioButton.TabIndex = 32;
            this.customerReceivedRadioButton.TabStop = true;
            this.customerReceivedRadioButton.Text = "Customer recieved the package";
            this.customerReceivedRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(15, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 100);
            this.panel1.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Name of who recieved package:";
            // 
            // familyMemberTextBox
            // 
            this.familyMemberTextBox.Enabled = false;
            this.familyMemberTextBox.Location = new System.Drawing.Point(285, 112);
            this.familyMemberTextBox.Name = "familyMemberTextBox";
            this.familyMemberTextBox.Size = new System.Drawing.Size(234, 20);
            this.familyMemberTextBox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Street Adress";
            // 
            // recepientNameTextBox
            // 
            this.recepientNameTextBox.Location = new System.Drawing.Point(15, 29);
            this.recepientNameTextBox.Name = "recepientNameTextBox";
            this.recepientNameTextBox.ReadOnly = true;
            this.recepientNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.recepientNameTextBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Recepient Name:";
            // 
            // responsibilityCheckBox
            // 
            this.responsibilityCheckBox.AutoSize = true;
            this.responsibilityCheckBox.Location = new System.Drawing.Point(15, 279);
            this.responsibilityCheckBox.Name = "responsibilityCheckBox";
            this.responsibilityCheckBox.Size = new System.Drawing.Size(418, 17);
            this.responsibilityCheckBox.TabIndex = 22;
            this.responsibilityCheckBox.Text = "By checking this box you accept full responsibility for this package and its cont" +
                "ents.";
            this.responsibilityCheckBox.UseVisualStyleBackColor = true;
            this.responsibilityCheckBox.CheckedChanged += new System.EventHandler(this.responsibilityCheckBox_CheckedChanged);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(471, 433);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 29);
            this.exitButton.TabIndex = 21;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Enabled = false;
            this.acceptButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(373, 432);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 30);
            this.acceptButton.TabIndex = 20;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // streetAddressTextBox
            // 
            this.streetAddressTextBox.Location = new System.Drawing.Point(15, 155);
            this.streetAddressTextBox.Multiline = true;
            this.streetAddressTextBox.Name = "streetAddressTextBox";
            this.streetAddressTextBox.ReadOnly = true;
            this.streetAddressTextBox.Size = new System.Drawing.Size(504, 118);
            this.streetAddressTextBox.TabIndex = 35;
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 497);
            this.Controls.Add(this.streetAddressTextBox);
            this.Controls.Add(this.familyMemberRadioButton);
            this.Controls.Add(this.customerNotHomeRadioButton);
            this.Controls.Add(this.customerReceivedRadioButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.familyMemberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.recepientNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.responsibilityCheckBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.acceptButton);
            this.Name = "DeliveryForm";
            this.Text = "Delivery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryForm_FormClosing);
            this.Load += new System.EventHandler(this.DeliveryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton familyMemberRadioButton;
        private System.Windows.Forms.RadioButton customerNotHomeRadioButton;
        private System.Windows.Forms.RadioButton customerReceivedRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox familyMemberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox recepientNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox responsibilityCheckBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox streetAddressTextBox;
    }
}