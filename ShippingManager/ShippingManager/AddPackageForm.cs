using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

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
            serviceTypeComboBox.SelectedIndex = 0;
            weightClassComboBox.SelectedIndex = 0;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            float length = 0;
            float width = 0;
            float height = 0;
            float insuranceAmount = 0;
            int zip = 0;


            if (float.TryParse(lengthTextbox.Text, out length) && float.TryParse(widthTextBox.Text, out width) && float.TryParse(heightTextBox.Text, out height) && 
                ( insuranceCheckBox.Checked == float.TryParse(insuranceAmountTextBox.Text, out insuranceAmount)) && destinationZipTextBox.Text.Length == 5 && int.TryParse(destinationZipTextBox.Text, out zip) &&
                sourceZipTextBox.Text.Length == 5 && int.TryParse(sourceZipTextBox.Text, out zip) && (sourceStreetTextbox.Text != "") && (destinationAddresseeTextBox.Text != "") &&
                (sourceStreetTextbox.Text != "") && (destinationStreetTextBox.Text != ""))
            {
                //TODO: Add error checking: empty fields, non-numeric, etc...
                Address source = new Address(sourceAddresseeTextBox.Text, sourceStreetTextbox.Text, sourceZipTextBox.Text);
                Address destination = new Address(destinationAddresseeTextBox.Text, destinationStreetTextBox.Text, destinationZipTextBox.Text);
                float[] lhw = { length, width, height};
                Package p = shippingSystem.addPackage(weightClassComboBox.SelectedIndex, lhw, (serviceTypeComboBox.SelectedIndex == 0) ? Package.SERVICE_TYPE.Economy : Package.SERVICE_TYPE.Air, fragileCheckBox.Checked, irregularCheckBox.Checked, perishableCheckBox.Checked, source, destination);
                if (p != null)
                {
                    (parentForm as StoreFrontForm).updatePackageList();

                    PrintDialog pd = new PrintDialog();
                    PrinterSettings ps = new PrinterSettings();
                    pd.PrinterSettings = ps;
                    DialogResult dr = pd.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                        privateFonts.AddFontFile("free3of9.ttf");
                        Font font = new Font(privateFonts.Families[0], 64);

                        PCPrint printer = new PCPrint(p.TrackingNumber);
                        printer.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;
                        printer.PrinterFont = font;
                        printer.Print();
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("There was a problem creating this package. \r\nMaybe the destination zipcode is not in the system.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void AddPackageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void insuranceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            insuranceAmountTextBox.Enabled = insuranceCheckBox.Checked;
        }
    }
}
