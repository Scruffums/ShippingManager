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

        public DeliverPackageForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }
    }
}
