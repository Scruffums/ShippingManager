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
        const string ADD = "&Add and Clear";
        const string SAVE = "&Save and Clear";
        const string STOREFRONT = "Current Storefront:";
        const string WAREHOUSE = "Current Store Front or Warehouse:";
        const string ROUTE = "Current Route: ";

        ShippingSystem shippingSystem;
        Form parentForm;

        Employee currentEmployee;
        Location currentLocation;
        Moveable currentMoveable;
        Route currentRoute;
        bool addEmployee = true;
        bool addLocation = true;
        bool addMoveable = true;
        bool addRoute = true;
                
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
            routesListBox.Items.AddRange(sm.Routes);
            //routeLocationOneListBox.Items.AddRange(sm.Locations);
            //routeLocationTwoListBox.Items.AddRange(sm.Locations);
            //routeUsingListBox.Items.AddRange(sm.RoutelessMoveable);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shippingSystem.logOut();
            parentForm.Show();
        }

        private void objectsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectsTabControl.SelectedIndex == 3)
            {
                routeLocationOneListBox.Items.Clear();
                routeLocationTwoListBox.Items.Clear();
                routeUsingListBox.Items.Clear();
                routeLocationOneListBox.Items.AddRange(shippingSystem.Locations);
                routeLocationTwoListBox.Items.AddRange(shippingSystem.Locations);
                routeUsingListBox.Items.AddRange(shippingSystem.RoutelessMoveable);
            }
        }

        #region EmployeeTab
        private void employeeEditButton_Click(object sender, EventArgs e)
        {
            employeeAddButton.Text = SAVE;
            addEmployee = false;

            currentEmployee = employeesListBox.SelectedItem as Employee;
            employeesListBox.ClearSelected();
            employeeIdTextBox.Text = currentEmployee.Id;
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
                AcceptanceEmployee a = currentEmployee as AcceptanceEmployee;
                if (a != null)
                    employeeCurrentComboBox.SelectedItem = a.CurrentStoreFront;
            }
            else if (currentEmployee is WarehouseEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 2;
                WarehouseEmployee a = currentEmployee as WarehouseEmployee;
                if (a != null)
                    employeeCurrentComboBox.SelectedItem = a.CurrentLocation;
            }
            else if (currentEmployee is DeliveryEmployee)
            {
                employeeTypeComboBox.SelectedIndex = 3;
                DeliveryEmployee a = currentEmployee as DeliveryEmployee;
                if (a != null)
                    employeeCurrentComboBox.SelectedItem = a.CurrentRoute;
            }

        }

        private void clearEmployeeTab()
        {
            firstNameTextBox.Clear();
            middleNameTextBox.Clear();
            lastNameTextBox.Clear();
            newPasswordTextBox.Clear();
            confirmPasswordTextBox.Clear();
            employeeIdTextBox.Clear();
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
                        idAvailable = shippingSystem.addAdminEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, employeeIdTextBox.Text, confirmPasswordTextBox.Text); break;
                    case 1:
                        idAvailable = shippingSystem.addAcceptanceEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, employeeIdTextBox.Text, confirmPasswordTextBox.Text, employeeCurrentComboBox.SelectedItem as StoreFront); break;
                    case 2:
                        idAvailable = shippingSystem.addWarehouseEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, employeeIdTextBox.Text, confirmPasswordTextBox.Text, employeeCurrentComboBox.SelectedItem as Location); break;
                    case 3:
                        idAvailable = shippingSystem.addDeliveryEmployee(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, employeeIdTextBox.Text, confirmPasswordTextBox.Text, employeeCurrentComboBox.SelectedItem as Route); break;
                }

                //TODO: notify user that the ID has already been used if idAvailable == false;
            }
            else//Edit employee
            {
                //TODO: allow user to change type
                currentEmployee.Id = employeeIdTextBox.Text;
                currentEmployee.FirstName = firstNameTextBox.Text;
                currentEmployee.MiddleName = middleNameTextBox.Text;
                currentEmployee.LastName = lastNameTextBox.Text;

                switch (employeeTypeComboBox.SelectedIndex)
                {
                    case 1:
                        (currentEmployee as AcceptanceEmployee).CurrentStoreFront = employeeCurrentComboBox.SelectedItem as StoreFront; break;
                    case 2:
                        (currentEmployee as WarehouseEmployee).CurrentLocation = employeeCurrentComboBox.SelectedItem as Location; break;
                    case 3:
                        (currentEmployee as DeliveryEmployee).CurrentRoute = employeeCurrentComboBox.SelectedItem as Route; break;
                }

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

                addEmployee = true;
                employeeAddButton.Text = ADD;
            }

            employeesListBox.Items.Clear();
            employeesListBox.Items.AddRange(shippingSystem.Employees);
            clearEmployeeTab();
        }

        private void employeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeCurrentComboBox.Enabled = employeeTypeComboBox.SelectedIndex != 0;
            switch (employeeTypeComboBox.SelectedIndex)
            {
                case 1://Acceptance
                    employeeCurrentLabel.Text = STOREFRONT;
                    employeeCurrentComboBox.Items.Clear();
                    employeeCurrentComboBox.Items.AddRange(shippingSystem.StoreFronts);
                    break;
                case 2://warehouse
                    employeeCurrentLabel.Text = WAREHOUSE;
                    employeeCurrentComboBox.Items.Clear();
                    employeeCurrentComboBox.Items.AddRange(shippingSystem.Locations);//Warehouse employees can be in a storeFront or Warehouse
                    break;
                case 3://Delivery
                    employeeCurrentLabel.Text = ROUTE;
                    employeeCurrentComboBox.Items.Clear();
                    employeeCurrentComboBox.Items.AddRange(shippingSystem.Routes);
                    break;
            }
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
                if (currentLocation is Warehouse)
                {
                    locationVolumeCapacityTextBox.Enabled = true;
                    locationVolumeCapacityTextBox.Text = (currentLocation as Warehouse).VolumeCapacity+"";
                }
            }
            else//We have an abroad
            {
                locationZipcodesServedTextBox.Enabled = true;
                locationZipcodesServedTextBox.Text = (currentLocation as Abroad).ZipcodesString;
            }


            
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
                        if (locationZipcodesServedTextBox.Text.StartsWith("<"))
                        {
                            //http://www.zipcodedownload.com/Directory/ZIP5/
                            List<string> zipcodes = new List<string>();
                            String text = locationZipcodesServedTextBox.Text;
                            int i=0;
                            int j = 0;
                            while((i=text.IndexOf('(',i))!=-1)
                            {
                                j = text.IndexOf(')', i);
                                zipcodes.Add(text.Substring(i+1,5));
                                i+=6;
                            }
                            locationAdded = shippingSystem.addAbroad(locationIdTextBox.Text, locationStreetAddressTextBox.Text, locationZipCodetextBox.Text, zipcodes.ToArray()); break;
                        }
                        else
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
                    if (locationZipcodesServedTextBox.Text.StartsWith("<"))
                    {
                        //http://www.zipcodedownload.com/Directory/ZIP5/
                        List<string> zipcodes = new List<string>();
                        String text = locationZipcodesServedTextBox.Text;
                        int i = 0;
                        int j = 0;
                        while ((i = text.IndexOf('(', i)) != -1)
                        {
                            j = text.IndexOf(')', i);
                            zipcodes.Add(text.Substring(i + 1, 5));
                            i += 6;
                        }
                        (currentLocation as Abroad).ZipCodes = zipcodes.ToArray();
                    }
                    else
                        (currentLocation as Abroad).ZipCodes = locationZipcodesServedTextBox.Text.Split(',');
                }
                locationAddButton.Text = ADD;
            }

            if (locationAdded)
            {
                addLocation = true;
                locationsListBox.Items.Clear();
                locationsListBox.Items.AddRange(shippingSystem.Locations);
                clearLocationsTab(); 
            }
        }

        private void clearLocationsTab()
        {
            locationIdTextBox.Clear();
            locationStreetAddressTextBox.Clear();
            locationZipCodetextBox.Clear();
            locationZipcodesServedTextBox.Clear();
            locationVolumeCapacityTextBox.Clear();
            //locationZipcodesServedTextBox.Enabled = false;
            //locationVolumeCapacityTextBox.Enabled = true;
            //locationStreetAddressTextBox.Enabled = true;
            //locationZipCodetextBox.Enabled = true;
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

                moveableTransportTypeComboBox.SelectedIndex = (int)t.TransportType;
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
                moveableIdTextBox.Focus();
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
                    transport.TransportType = (moveableTransportTypeComboBox.SelectedIndex==0)?Transport.TRANSPORT_TYPES.ground:Transport.TRANSPORT_TYPES.air;
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

        #region RouteTab
        private void routesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            routeEditButton.Enabled = routesListBox.SelectedIndex != -1;
        }

        private void routeEditButton_Click(object sender, EventArgs e)
        {
            addRoute = false;
            routeAddButton.Text = SAVE;
            currentRoute = routesListBox.SelectedItem as Route;

            routeIdTextBox.Text = currentRoute.Id;
            routeDurationTextBox.Text = currentRoute.DurationInDays + "";

            routeUsingListBox.Items.Clear();
            routeUsingListBox.Items.AddRange(shippingSystem.RoutelessMoveable);
            routeUsingListBox.Items.Insert(0, currentRoute.CurrentMoveable);
            routeUsingListBox.SelectedIndex = 0;
            routeLocationOneListBox.SelectedIndex = shippingSystem.indexOf(currentRoute.Locations[0]);
            routeLocationTwoListBox.SelectedIndex = shippingSystem.indexOf(currentRoute.Locations[1]);
        }

        private void routeAddButton_Click(object sender, EventArgs e)
        {
            if (addRoute)
            {
                bool routeAdded = shippingSystem.addRoute(routeIdTextBox.Text, float.Parse(routeDurationTextBox.Text), routeLocationOneListBox.SelectedItem as Location, routeLocationTwoListBox.SelectedItem as Location, routeUsingListBox.SelectedItem as Moveable);
                //TODO: add code to inform user route was not added due to ID being used.
            }
            else//edit route
            {
                currentRoute.Id = routeIdTextBox.Text;
                currentRoute.DurationInDays = float.Parse(routeDurationTextBox.Text);//TODO: add code to inform user of non numeric input
                foreach (Location rLocation in currentRoute.Locations)
                {
                    if (rLocation is StoreFront)
                        (rLocation as StoreFront).removeRoute(currentRoute);
                    else if (rLocation is Warehouse)
                        (rLocation as Warehouse).removeRoute(currentRoute);
                }
                currentRoute.Locations[0] = routeLocationOneListBox.SelectedItem as Location;
                currentRoute.Locations[1] = routeLocationTwoListBox.SelectedItem as Location;
                currentRoute.CurrentMoveable = routeUsingListBox.SelectedItem as Moveable;
                foreach (Location rLocation in currentRoute.Locations)
                {
                    if (rLocation is StoreFront)
                        (rLocation as StoreFront).addRoute(currentRoute);
                    else if (rLocation is Warehouse)
                        (rLocation as Warehouse).addRoute(currentRoute);
                }
            }

            routeIdTextBox.Focus();
            addRoute = true;
            routeAddButton.Text = ADD;
            routesListBox.Items.Clear();
            routesListBox.Items.AddRange(shippingSystem.Routes);
            clearRouteTab();
        }

        private void clearRouteTab()
        {
            routeIdTextBox.Clear();
            routeDurationTextBox.Clear();
            routeUsingListBox.Items.Clear();
            routeUsingListBox.Items.AddRange(shippingSystem.RoutelessMoveable);
        } 
        #endregion

        private void moveablesListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && moveablesListBox.SelectedIndex != -1)
                moveableContextMenu.Show(moveablesListBox, new Point(e.X, e.Y));
        }

        private void changeCurrentLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (moveablesListBox.SelectedItem as Moveable).changeLocation();
        }

    }
}
