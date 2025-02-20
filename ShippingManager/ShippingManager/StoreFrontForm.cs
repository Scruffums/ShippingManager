﻿using System;
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

        #region Listeners
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void packageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((editButton.Enabled = deleteButton.Enabled = packageListBox.SelectedIndex != -1))
            {
                Package currentPackage = packageListBox.SelectedItem as Package;
                packageInfoTextBox.Text = currentPackage.Source + "\r\n\r\n" + currentPackage.Destination + "\r\n\r\n" + currentPackage.MailService + "\r\n\r\n";
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Package currentPackage = packageListBox.SelectedItem as Package;

            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile("free3of9.ttf");
            Font font = new Font(privateFonts.Families[0], 64);
            privateFonts.Dispose();

            PrintDialog pd = new PrintDialog();
            PrinterSettings ps = new PrinterSettings();
            pd.PrinterSettings = ps;
            DialogResult dr = pd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                PCPrint printer = new PCPrint(currentPackage.TrackingNumber);
                printer.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;
                printer.PrinterFont = font;// new Font("Free 3 of 9", 45, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                printer.Print();
            }
        }

        private void packageListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && packageListBox.SelectedIndex != -1)
                packageContextMenu.Show(packageListBox, new Point(e.X, e.Y));
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //TODO: edit package logic
        }

        private void copyTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((packageListBox.SelectedItem as Package).TrackingNumber);
        }

        #endregion

        
    }
}
