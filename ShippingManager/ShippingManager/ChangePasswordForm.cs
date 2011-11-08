using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShippingManager
{
    public partial class ChangePasswordForm : Form
    {
        Form parentForm;
        ShippingSystem shippingSystem;

        public ChangePasswordForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {

            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string newPasswordConfirm = confirmPasswordTextBox.Text;

            if (newPassword == newPasswordConfirm)
            {

                if (shippingSystem.LoggedInEmployee.changePassword(oldPassword, newPassword) == false)
                {
                    MessageBox.Show("Current password entry is incorrect.");
                }
                else
                {
                    shippingSystem.LoggedInEmployee.changePassword(oldPassword, newPassword);
                    MessageBox.Show("Password successfully changed.");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("New password does not match confirmed password.");
            }

        }
        
    }
}
