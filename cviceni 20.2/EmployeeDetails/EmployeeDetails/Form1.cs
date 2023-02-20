﻿using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class Form1 : Form
    {
        Employee employee = new Employee();
        public Form1()
        {
            InitializeComponent();
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cboGender.SelectedItem.ToString();
            var success = employee.InsertEmployee(employee);
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            ClearControls();
            if (success)
                MessageBox.Show("Employee has been added successfully");
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cboGender.SelectedItem.ToString();
            var success = employee.UpdateEmployee(employee);
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            ClearControls();
            if (success)
                MessageBox.Show("Employee has been updated successfully");
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            var success = employee.DeleteEmployee(employee);
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            if (success)
                MessageBox.Show("Employee has been deleted successfully");
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            txtAge.Text = "";
            txtContactNo.Text = "";
            cboGender.Text = "";
        }

        private void dgvEmployeeDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtEmpId.Text = dgvEmployeeDetails.Rows[index].Cells[0].Value.ToString();
            txtEmpName.Text = dgvEmployeeDetails.Rows[index].Cells[1].Value.ToString();
            txtAge.Text = dgvEmployeeDetails.Rows[index].Cells[2].Value.ToString();
            txtContactNo.Text = dgvEmployeeDetails.Rows[index].Cells[3].Value.ToString();
            cboGender.Text = dgvEmployeeDetails.Rows[index].Cells[4].Value.ToString();
        }
    }
}
