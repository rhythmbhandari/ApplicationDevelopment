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
            //username and password of the user
            string adminUsername = "admin";
            string adminPassword = "admin";

            string staffUsername = "admin";
            string staffPassword = "admin";
            //getting the value from the textbox where user types
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            //check if the username and password are correct
            if (username == adminUsername && password == adminPassword)//if matches then login
            {
                MessageBox.Show("Admin Login Success!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Home home = new Home();
                home.Show();
            }else if (username == staffUsername && password == staffPassword)//if matches then login
            {
                MessageBox.Show("Staff Login Success!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            //if one or more field is left empty
            else if (username == "" || password == "")
            {
                MessageBox.Show("One or more field empty !!! Please enter credentails!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //if doesnt match then show error message
            {
                MessageBox.Show("Invalid Credentials !!! Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
