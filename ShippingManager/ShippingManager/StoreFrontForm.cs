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
    public partial class StoreFrontForm : Form
    {
        Form parentForm;
        ShippingSystem shippingSystem;
        AcceptanceEmployee em;

        public StoreFrontForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
            em = shippingSystem.LoggedInEmployee as AcceptanceEmployee;
            Text = em.CurrentStoreFront.ToString();
            packageListBox.Items.AddRange(em.CurrentStoreFront.Packages);
        }

        public void updatePackageList()
        {
            packageListBox.Items.Clear();
            packageListBox.Items.AddRange(em.CurrentStoreFront.Packages);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //An example of opening the ChangePasswordForm modally (other forms are unfocusable when changePasswordForm is open)
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }

        private void StoreFrontForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shippingSystem.logOut();
            parentForm.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPackageForm af = new AddPackageForm(this, shippingSystem);
            this.Hide();
            af.Show();
        }
    }
}
