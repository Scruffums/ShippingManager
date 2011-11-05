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
        bool addEmployee = true;
        
        

        public AdminForm(Form parent, ShippingSystem sm)
        {
            InitializeComponent();
            shippingSystem = sm;
            parentForm = parent;
            typeComboBox.SelectedIndex = 0;
            employeesListBox.Items.AddRange(sm.Employees);
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
                typeComboBox.SelectedIndex = 0;
            }
            else if (currentEmployee is AcceptanceEmployee)
            {
                typeComboBox.SelectedIndex = 1;
            }
            else if (currentEmployee is WarehouseEmployee)
            {
                typeComboBox.SelectedIndex = 2;
            }
            else if (currentEmployee is DeliveryEmployee)
            {
                typeComboBox.SelectedIndex = 3;
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
            editButton.Enabled = !(employeesListBox.SelectedIndex == -1);
        }

        private void employeeAddButton_Click(object sender, EventArgs e)
        {
            if (addEmployee)
            {
                bool idAvailable = true;
                switch (typeComboBox.SelectedIndex)
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
    }
}
