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
    public partial class DeliverPackageForm : Form
    {
        Form parentForm;
        ShippingSystem shippingSystem;
        DeliveryEmployee currentEmployee;

        public DeliverPackageForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
            currentEmployee = shippingSystem.LoggedInEmployee as DeliveryEmployee;
            if (!(currentEmployee.CurrentRoute.CurrentMoveable.CurrentLocation is Abroad))
                currentEmployee.CurrentRoute.CurrentMoveable.changeLocation();
            updatePackagesListBox();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }

        private void DeliverPackageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shippingSystem.logOut();
            currentEmployee.CurrentRoute.CurrentMoveable.changeLocation();
            parentForm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void packagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deliverButton.Enabled = postponeButton.Enabled = packagesListBox.SelectedIndex != -1)
            {
                Package currentPackage = (packagesListBox.SelectedItem as Package);
                detailsTextBox.Text = currentPackage.Source + "\r\n\r\n" + currentPackage.Destination + "\r\n\r\n" + currentPackage.MailService + "\r\n\r\n";
            }

        }

        public void updatePackagesListBox()
        {
            packagesListBox.Items.Clear();
            packagesListBox.Items.AddRange(currentEmployee.CurrentRoute.CurrentMoveable.Packages);
        }

        private void deliverButton_Click(object sender, EventArgs e)
        {
            DeliveryForm df = new DeliveryForm(this, shippingSystem, packagesListBox.SelectedItem as Package);
            Hide();
            df.ShowDialog();
        }
    }
}
