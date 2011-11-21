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
    public partial class GuestForm : Form
    {
        private Form parentForm;
        private ShippingSystem shippingSystem;


        public GuestForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;
        }

        private void GuestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string trackNumber = textBox1.Text;

            if (shippingSystem.lookUpTrackingNumber(trackNumber) == null)
            {
                MessageBox.Show(this,"Tracking number does not exist.");
            }
            else
            {
                Package p = shippingSystem.lookUpTrackingNumber(trackNumber);

                foreach (Snapshot s in p.Snapshots)
                {
                    textBox2.Text += s + "\r\n\r\n";
                }
            }
        }
    }
}
