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
    public partial class LoginForm : Form
    {
        ShippingSystem shippingSystem;

        public LoginForm(ShippingSystem ss)
        {
            shippingSystem = ss;
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            idTextBox.Focus();
            if (idTextBox.Text == "guest")
            {
                GuestForm g = new GuestForm(this, shippingSystem);
                Hide();
                g.Show();
            }
            else
            {
                Employee employee = shippingSystem.validateEmployeeLogin(idTextBox.Text, passwordTextBox.Text);

                if (employee == null)
                {
                    //TODO: notify user that their id or password is incorrect or does not exist
                }
                else
                {
                    if (employee is AdminEmployee)
                    {
                        AdminForm af = new AdminForm(this, shippingSystem);
                        this.Hide();
                        af.Show();
                    }
                    else if (employee is AcceptanceEmployee)
                    {
                        StoreFrontForm sf = new StoreFrontForm(this, shippingSystem);
                        this.Hide();
                        sf.Show();
                    }
                    else if (employee is WarehouseEmployee)
                    {
                        WarehouseForm wf = new WarehouseForm(this, shippingSystem);
                        this.Hide();
                        wf.Show();
                    }
                    else//Employee is delivery
                    {
                        DeliverPackageForm dp = new DeliverPackageForm(this, shippingSystem);
                        this.Hide();
                        dp.Show();
                    } 
                }

                idTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {

            //BUG: Windows makes an error noise when the enter key is hit in a textBox. We may need to use the KeyPress event instead of KeyDown
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                acceptButton_Click(sender, e);
            }
        }
    }
}
