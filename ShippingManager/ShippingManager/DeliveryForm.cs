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
    public partial class DeliveryForm : Form
    {
        const string RECEIVED_BY_RECEPIENT = "Customer received the package";
        const string LEFT_AT_ADDRESS = "Customer was not home but package as left at address provided";
        const string RECEIVED_BY_OTHER = "Customer family member received package";

        DeliverPackageForm parentForm;
        ShippingSystem shippingSystem;
        Package package;

        public DeliveryForm(Form parent, ShippingSystem sm, Package p)
        {
            InitializeComponent();
            parentForm = parent as DeliverPackageForm;
            shippingSystem = sm;
            package = p;
            recepientNameTextBox.Text = p.Destination.Addressee;
            streetAddressTextBox.Text = p.Destination.StreetAddress;
        }

        private void responsibilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            acceptButton.Enabled = responsibilityCheckBox.Checked;
        }

        private void familyMemberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            familyMemberTextBox.Enabled = familyMemberRadioButton.Checked;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeliveryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            shippingSystem.deliverPackage(package);
            if (customerReceivedRadioButton.Checked)
                package.takeSnapshot(RECEIVED_BY_RECEPIENT, (shippingSystem.LoggedInEmployee as DeliveryEmployee).CurrentRoute.CurrentMoveable.CurrentLocation);
            else if (customerNotHomeRadioButton.Checked)
                package.takeSnapshot(LEFT_AT_ADDRESS, (shippingSystem.LoggedInEmployee as DeliveryEmployee).CurrentRoute.CurrentMoveable.CurrentLocation);
            else
            {
                //TODO: Make sure familyMemberTextBox.Text is not empty. If it is the user should be notified, and all three lines after this comment should not be executed (the easiest way would be to use an empty return statement (e.g. return;)).
                package.takeSnapshot(RECEIVED_BY_OTHER + ": " + familyMemberTextBox.Text, (shippingSystem.LoggedInEmployee as DeliveryEmployee).CurrentRoute.CurrentMoveable.CurrentLocation);
            }

            parentForm.updatePackagesListBox();
            Close();
        }

    }
}
