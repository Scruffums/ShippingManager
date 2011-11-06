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
    public partial class AdminForm : Form
    {
        const String ADD = "&Add and Clear";
        const String SAVE = "&Save and Clear";

        ShippingSystem shippingSystem;
        Form parentForm;

        Employee currentEmployee;
        Location currentLocation;
        Moveable currentMoveable;
        bool addEmployee = true;
        bool addLocation = true;
        bool addMoveable = true;
                
        public AdminForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            shippingSystem = sm;
            parentForm = parent;
            employeeTypeComboBox.SelectedIndex = 0;
            locationTypeComboBox.SelectedIndex = 0;
            employeesListBox.Items.AddRange(sm.Employees);
            locationsListBox.Items.AddRange(sm.Locations);
            moveablesListBox.Items.AddRange(sm.Moveables);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            shippingSystem.logOut();
            Hide();
            parentForm.Show();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            logoutButton_Click(sender, e);
        }

        #region EmployeeTab
        private void employeeEditButton_Click(object sender, EventArgs e)
        {
            employeeAddButton.Text = SAVE;
            addEmployee = false;

            currentEmployee = employeesListBox.SelectedItem as Employee;
            employeesListBox.ClearSelected();
            idTextBox.Text = currentEmployee.Id;
            firstNameTextBox.Text = currentEmployee.FirstName;
            middleNameTextBox.Text = currentEmployee.MiddleName;
            lastNameTextBox.Text = currentEmployee.LastName;
            newPasswordTextBox.Focus();

            if (currentEmployee is AdminEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 0;
            }
            else if (currentEmployee is AcceptanceEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 1;
            }
            else if (currentEmployee is WarehouseEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 2;
            }
            else if (currentEmployee is DeliveryEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 3;
            }

        }

        private void clearEmployeeTab()
        {
            firstNameTextBox.Clear();
            middleNameTextBox.Clear();
            lastNameTextBox.Clear();
            newPasswordTextBox.Clear();
            confirmPasswordTextBox.Clear();
            idTextBox.Clear();
        }

        private void employeesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeEditButton.Enabled = !(employeesListBox.SelectedIndex == -1);
        }

        private void employeeAddButton_Click(object sender, EventArgs e)
        {
            if (addEmployee)
            {
                bool idAvailable = true;
                switch (employeeTypeComboBox.SelectedIndex)
                {
                    case 0:
                        idAvailable = shippingSystem.addAdminEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, idTextBox.Text, confirmPasswordTextBox.Text); break;
                    case 1:
                        idAvailable = shippingSystem.addAcceptanceEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, idTextBox.Text, confirmPasswordTextBox.Text); break;
                    case 2:
                        idAvailable = shippingSystem.addWarehouseEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, idTextBox.Text, confirmPasswordTextBox.Text); break;
                    case 3:
                        idAvailable = shippingSystem.addDeliveryEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, idTextBox.Text, confirmPasswordTextBox.Text); break;
                }

                //TODO: notify user that the ID has already been used if idAvailable == false;
            }
            else//Edit employee
            {
                //TODO: allow user to change type
                currentEmployee.FirstName = firstNameTextBox.Text;
                currentEmployee.MiddleName = middleNameTextBox.Text;
                currentEmployee.LastName = lastNameTextBox.Text;

                if (newPasswordTextBox.Text != "")
                {
                    if (newPasswordTextBox.Text == confirmPasswordTextBox.Text)
                    {
                        currentEmployee.changePassword(shippingSystem.LoggedInEmployee, confirmPasswordTextBox.Text);
                    }
                    else
                    {
                        //TODO: Notify user that passwords do not match
                    }
                }


                employeeAddButton.Text = ADD;
            }

            employeesListBox.Items.Clear();
            employeesListBox.Items.AddRange(shippingSystem.Employees);
            clearEmployeeTab();
        } 
        #endregion

        #region LocationTab
        private void locationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            locationEditButton.Enabled = !(locationsListBox.SelectedIndex == -1);
        }

        private void locationEditButton_Click(object sender, EventArgs e)
        {
            locationTypeComboBox.Enabled = false;
            locationAddButton.Text = SAVE;
            addLocation = false;

            currentLocation = locationsListBox.SelectedItem as Location;
            locationsListBox.ClearSelected();

            locationIdTextBox.Text = currentLocation.Id;

            locationStreetAddressTextBox.Enabled = locationZipCodetextBox.Enabled = !(currentLocation is Abroad);

            if (locationStreetAddressTextBox.Enabled)
            {
                locationStreetAddressTextBox.Text = currentLocation.StreetAddress;
                locationZipCodetextBox.Text = currentLocation.Zipcode;
            }

            locationVolumeCapacityTextBox.Enabled = currentLocation is Warehouse;

            locationZipcodesServedTextBox.Enabled = currentLocation is Abroad;
        }

        private void locationAddButton_Click(object sender, EventArgs e)
        {
            bool locationAdded = true;
            if (addLocation)
            {

                switch (locationTypeComboBox.SelectedIndex)
                {
                    case 0:
                        locationAdded = shippingSystem.addStoreFront(locationIdTextBox.Text, locationStreetAddressTextBox.Text, locationZipCodetextBox.Text); break;
                    case 1://TODO: Add code to handle when the user inputs something other than a number in the volumeCapacityTextbox
                        locationAdded = shippingSystem.addWarehouse(locationIdTextBox.Text, locationStreetAddressTextBox.Text, locationZipCodetextBox.Text, int.Parse(locationVolumeCapacityTextBox.Text)); break;
                    case 2:
                        locationAdded = shippingSystem.addAbroad(locationIdTextBox.Text, locationStreetAddressTextBox.Text, locationZipCodetextBox.Text, locationZipcodesServedTextBox.Text.Split(',')); break;
                }
                //TODO: Inform user that the location was not added because the address has already been used by another location
            }
            else//edit location
            {
                locationTypeComboBox.Enabled = true;
                currentLocation.Id = locationIdTextBox.Text;
                currentLocation.StreetAddress = locationStreetAddressTextBox.Text;
                currentLocation.Zipcode = locationZipCodetextBox.Text;



                if (currentLocation is Abroad)
                {
                    (currentLocation as Abroad).ZipCodes = locationZipcodesServedTextBox.Text.Split(',');
                }
            }

            locationsListBox.Items.Clear();
            locationsListBox.Items.AddRange(shippingSystem.Locations);
            clearLocationsTab();
        }

        private void clearLocationsTab()
        {
            locationIdTextBox.Clear();
            locationStreetAddressTextBox.Clear();
            locationZipCodetextBox.Clear();
            locationZipcodesServedTextBox.Clear();
            locationVolumeCapacityTextBox.Clear();
        }

        private void locationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            locationVolumeCapacityTextBox.Enabled = locationTypeComboBox.SelectedIndex == 1;
            locationZipcodesServedTextBox.Enabled = locationTypeComboBox.SelectedIndex == 2;
            locationStreetAddressTextBox.Enabled = locationZipCodetextBox.Enabled = !(locationTypeComboBox.SelectedIndex == 2);
        } 
        #endregion

        #region MoveableTab
        private void moveableEditButton_Click(object sender, EventArgs e)
        {
            moveableTypeComboBox.Enabled = false;
            moveableAddButton.Text = SAVE;
            addMoveable = false;

            currentMoveable = moveablesListBox.SelectedItem as Moveable;
            moveablesListBox.ClearSelected();

            moveableIdTextBox.Text = currentMoveable.Id;
            moveableVolumeTextBox.Text = currentMoveable.VolumeCapacity + "";
            moveableWeightTextBox.Text = currentMoveable.WeightCapacity + "";

            moveableTransportTypeComboBox.Enabled = moveableTemperatureCheckBox.Enabled = currentMoveable is Transport;

            if (moveableTransportTypeComboBox.Enabled)
            {
                Transport t = currentMoveable as Transport;

                moveableTransportTypeComboBox.SelectedIndex = t.TransportType;
                moveableTemperatureCheckBox.Checked = t.TempControlled;
            }
        }

        private void moveableAddButton_Click(object sender, EventArgs e)
        {
            bool moveableAdded = true;
            if (addMoveable)
            {

                switch (moveableTypeComboBox.SelectedIndex)
                {
                    case 0:
                        moveableAdded = shippingSystem.addDeliveryVehicle(moveableIdTextBox.Text, int.Parse(moveableVolumeTextBox.Text), int.Parse(moveableWeightTextBox.Text)); break;
                    case 1://TODO: Add code to handle when the user inputs something other than a number in the volumeCapacityTextbox
                        moveableAdded = shippingSystem.addTransport(moveableIdTextBox.Text, moveableTransportTypeComboBox.SelectedIndex, int.Parse(moveableVolumeTextBox.Text), int.Parse(moveableWeightTextBox.Text), moveableTemperatureCheckBox.Checked); break;
                }
                //TODO: Inform user that the location was not added because the address has already been used by another location
            }
            else//edit moveable
            {
                moveableTypeComboBox.Enabled = true;
                currentMoveable.Id = moveableIdTextBox.Text;
                currentMoveable.WeightCapacity = int.Parse(moveableWeightTextBox.Text);
                currentMoveable.VolumeCapacity = int.Parse(moveableVolumeTextBox.Text);

                Transport transport = currentMoveable as Transport;
                if (transport != null)
                {
                    transport.TempControlled = moveableTemperatureCheckBox.Checked;
                    transport.TransportType = moveableTransportTypeComboBox.SelectedIndex;
                }
            }

            moveablesListBox.Items.Clear();
            moveablesListBox.Items.AddRange(shippingSystem.Moveables);
            clearMoveablesTab();
        }

        private void clearMoveablesTab()
        {
            moveableIdTextBox.Clear();
            moveableTemperatureCheckBox.Checked = false;
            moveableVolumeTextBox.Clear();
            moveableWeightTextBox.Clear();
        }

        private void moveableTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveableTemperatureCheckBox.Enabled = moveableTransportTypeComboBox.Enabled = moveableTypeComboBox.SelectedIndex == 1;
        }

        private void moveablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveableEditButton.Enabled = moveablesListBox.SelectedIndex != -1;
        }
        #endregion

        
    }
}
