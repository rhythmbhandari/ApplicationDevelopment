using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //username and password of the admin
            string adminUsername = "admin";
            string adminPassword = "admin";

            //username and password of the staff
            string staffUsername = "staff";
            string staffPassword = "staff";

            //getting values from user input
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //checking if the username and password are correct.

            //Incase of admin login
            if (username == adminUsername && password == adminPassword)
            {
                MessageBox.Show("Admin Login Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Home home = new Home("admin");
                home.Show();

            }
            //Incase of staff login
            else if (username == staffUsername && password == staffPassword)
            {
                MessageBox.Show("Staff Login Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Home home = new Home("staff");
                home.Show();
            }
            //if one or more field is left empty
            else if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both your username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Incase of incorrect credentials.
            {
                MessageBox.Show("Incorrect password or username! Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
