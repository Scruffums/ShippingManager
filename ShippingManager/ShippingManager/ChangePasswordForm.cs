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
            //TODO: add Logic for checking old password, and ensuring the new and confirm passwords match; then setting the new password to the loggedInEmployee.

            //Make sure oldPassword==newPassword;If not notify the user with a MessageBox (it's part of c#)
            //shippingSystem.LoggedInEmployee.changePassword(oldPassword, newPassword);
            //if changePassword returns false, inform user that the oldPassword was incorrect. Use MessageBox to inform the user.

            //You can test your code if you log in using Username: lhwalace, Password:password; then you can make a new user of any type other than Admin, then log in for that user, then attempt to the change the password--then logout and try the new password.
        }

        
    }
}
