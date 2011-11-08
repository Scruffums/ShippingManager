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

        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //An example of opening the ChangePasswordForm modally (other forms are unfocusable when changePasswordForm is open)
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
