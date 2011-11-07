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
    public partial class AddPackageForm : Form
    {
        Form parentForm;
        ShippingSystem shippingSystem;

        public AddPackageForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            parentForm = parent;
            shippingSystem = sm;

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //TODO: Add error checking: empty fields, non-numeric, etc...
            Address source = new Address(sourceAddresseeTextBox.Text, sourceStreetTextbox.Text, sourceZipTextBox.Text);
            Address destination = new Address(destinationAddresseeTextBox.Text, destinationStreetTextBox.Text, destinationZipTextBox.Text);
            float[] lhw = { float.Parse(lengthTextbox.Text),float.Parse(widthTextBox.Text),float.Parse(heightTextBox.Text)};
            shippingSystem.AddPackage(weightClassComboBox.SelectedIndex, lhw, serviceTypeComboBox.SelectedIndex, fragileCheckBox.Checked, irregularCheckBox.Checked, perishableCheckBox.Checked, source, destination);
            (parentForm as StoreFrontForm).updatePackageList();
            Close();
        }

        private void AddPackageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
