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

    public partial class WarehouseForm : Form
    {
        Form parentForm;
        ShippingSystem shippingSystem;
        WarehouseEmployee em;
        Warehouse currentWarehouse;
        StoreFront currentStoreFront;

        public WarehouseForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
            em = shippingSystem.LoggedInEmployee as WarehouseEmployee;
            currentWarehouse = em.CurrentLocation as Warehouse;
            currentStoreFront = em.CurrentLocation as StoreFront;

            updateReceivingListBox();

            if (currentStoreFront != null)
                Text = currentStoreFront.Id;
            else
                Text = currentWarehouse.Id;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //An example of opening the ChangePasswordForm modally (other forms are unfocusable when changePasswordForm is open)
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            lookupTrackingNumber(addTextBox.Text);
        }

        private void lookupTrackingNumber(string trackingNumber)
        {
            Package p = shippingSystem.lookupTrackingNumber(trackingNumber);
            if (p != null)
            {
                if (currentStoreFront != null)
                    currentStoreFront.addPackage(p);
                else
                    currentWarehouse.addPackage(p);
                updateReceivingListBox();
            }
            else
            {
                //TODO: add code to notify user if number is not found
            }

        }

        private void updateReceivingListBox()
        {
            if (currentStoreFront != null)
                receivingListBox.Items.AddRange(currentStoreFront.Packages);
            else
                receivingListBox.Items.AddRange(currentWarehouse.Packages);
        }

        private void WarehouseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shippingSystem.logOut();
            parentForm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
