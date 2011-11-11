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
            int i = codes.Count;
        }
    }
}
