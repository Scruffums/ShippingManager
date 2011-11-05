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

        public StoreFrontForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            shippingSystem.logOut();
            Hide();
            parentForm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: show ChangePassword Form
        }
    }
}
