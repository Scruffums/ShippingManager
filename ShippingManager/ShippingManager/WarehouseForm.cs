using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Reference for Microsoft Windows Image Acquisition Library v2.0
using WIA;
using System.IO;
using System.Collections;

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
            updateVehiclesListBox();

            if (currentStoreFront != null)
                Text = currentStoreFront.Id;
            else
                Text = currentWarehouse.Id;
        }


        private bool lookupTrackingNumber(string trackingNumber)
        {
            Package p = shippingSystem.lookupTrackingNumber(trackingNumber);
            if (p != null)
            {
                foreach (Moveable m in vehiclesListBox.Items)
                    if (m.hasPackage(p))
                    {
                        shippingSystem.movePackageToWarehouse(m, currentWarehouse, p);
                    }
                updateReceivingListBox();
                return true;
            }
            return false;
        }

        private void updateReceivingListBox()
        {
            receivingListBox.Items.Clear();
            if (currentStoreFront != null)
                receivingListBox.Items.AddRange(currentStoreFront.Packages);
            else
                receivingListBox.Items.AddRange(currentWarehouse.Packages);
        }

        private void updateVehiclesListBox()
        {
            vehiclesListBox.Items.Clear();

            if (currentStoreFront != null)
            {
                foreach (Route r in currentStoreFront.Routes)
                    if (r.CurrentMoveable.CurrentLocation.Equals(currentStoreFront))
                        vehiclesListBox.Items.Add(r.CurrentMoveable);
            }
            else
            {
                foreach (Route r in currentWarehouse.Routes)
                    if (r.CurrentMoveable.CurrentLocation.Equals(currentWarehouse))
                        vehiclesListBox.Items.Add(r.CurrentMoveable);
            }
        }

        private void updateButtons()
        {
            loadButton.Enabled = receivingListBox.SelectedIndex != -1 && vehiclesListBox.SelectedIndex != -1;
            distributeButton.Enabled = vehiclesListBox.SelectedIndex != -1;
        }

        #region Listeners
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(this, shippingSystem);
            c.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (lookupTrackingNumber(addTextBox.Text))
                addTextBox.Clear();
            else
            {
                //TODO: add code to notify user if number is not found
            }
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

        private void scanButton_Click(object sender, EventArgs e)
        {
            //WIA Reference requires "embed interop types" property set to false
            const string wiaFormatBMP = FormatID.wiaFormatBMP;// "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
            CommonDialogClass wiaDiag = new CommonDialogClass();
            WIA.ImageFile wiaImage = null;

            wiaImage = wiaDiag.ShowAcquireImage(
                    WiaDeviceType.ScannerDeviceType,
                    WiaImageIntent.GrayscaleIntent,
                    WiaImageBias.MaximizeQuality,
                    wiaFormatBMP, true, true, false);

            byte[] buffer = (byte[])wiaImage.FileData.get_BinaryData();
            MemoryStream ms = new MemoryStream(buffer);
            Bitmap bmp = new Bitmap(Image.FromStream(ms));

            ArrayList codes = new ArrayList();
            BarcodeImaging.FullScanPage(ref codes, bmp, 75);
            //BarcodeImaging.ScanPage(ref codes, bmp, 75, BarcodeImaging.ScanDirection.Horizontal, BarcodeImaging.BarcodeType.All);
            foreach (string code in codes)
                if (!lookupTrackingNumber(code))
                    MessageBox.Show("Tracking number: " + code + "\n not found");
        }

        private void receivingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
            Package p;
            if (null != (p = receivingListBox.SelectedItem as Package))
            {
                Location nextLocation = shippingSystem.nextLocation(p);

                if (currentStoreFront != null)
                {
                    foreach (Route r in currentStoreFront.Routes)
                        if (r.containsLocation(nextLocation))
                            vehicleLabel.Text += "\n" + r.CurrentMoveable;
                }
                else
                {
                    foreach (Route r in currentWarehouse.Routes)
                        if (r.containsLocation(nextLocation))
                            vehicleLabel.Text += "\n" + r.CurrentMoveable;
                }
            }
        }

        private void vehiclesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Package p = receivingListBox.SelectedItem as Package;
            Moveable m = vehiclesListBox.SelectedItem as Moveable;

            if (currentStoreFront != null)
            {
                shippingSystem.movePackageToMoveable(currentStoreFront, m, p);
            }
            else
            {
                shippingSystem.movePackageToMoveable(currentWarehouse, m, p);
            }
            updateReceivingListBox();
        }

        private void distributeButton_Click(object sender, EventArgs e)
        {
            Moveable m = vehiclesListBox.SelectedItem as Moveable;
            m.changeLocation();
            updateVehiclesListBox();
        } 
        #endregion
    }
}
