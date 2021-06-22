using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodaHook.xyz_Loader
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Indian tut remember me c# ez asf  
            Properties.Settings.Default.username = username.Text;
            Properties.Settings.Default.password = password.Text;
            Properties.Settings.Default.seccode = Code.Text;

            //If logged-in:
            if (Code.Text == "109871" && password.Text == "Test" && username.Text == "Dev")
            {
                authed auth = new authed();
                auth.Show();
                this.Hide(); 
            }
            
            /*   //Not complete
               bool logged = false;

               if(!logged)
               {
                   MessageBox.Show("User not found or the password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }*/
        }

        private void Login_Load(object sender, EventArgs e)
        {
            username.Text = Properties.Settings.Default.username;
            password.Text = Properties.Settings.Default.password;
            Code.Text = Properties.Settings.Default.seccode;
        }

        private void Code_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
