using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodaHook.xyz_Loader
{
    public partial class Login : Form
    {

        bool online;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkonline();
            if (online)
            {
                WebClient wb = new WebClient();
                string ver = wb.DownloadString("https://nodahook.000webhostapp.com/ver.php");

                if (ver == "1.0.0")
                {
                    //Indian tut remember me c# ez asf  
                    Properties.Settings.Default.username = username.Text;
                    Properties.Settings.Default.password = password.Text;
                    Properties.Settings.Default.seccode = Code.Text;
                    Properties.Settings.Default.Save();

                    //If logged-in:
                    if (Code.Text == "109871" && password.Text == "Test" && username.Text == "Dev")
                    {
                        authed auth = new authed();
                        auth.Show();
                        this.Hide();
                    }
                }
                else
                    MessageBox.Show("Invalid version of loader! Please download the new loader!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                /*   //Not complete
                   bool logged = false;

                   if(!logged)
                   {
                       MessageBox.Show("User not found or the password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }*/
            }
            else
                MessageBox.Show("You are not connected to internet! Please connect to your internet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void checkonline()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        online = true;
                    }
                }
            }
            catch
            {
                online = false;
                Application.Exit();
            }
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

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
