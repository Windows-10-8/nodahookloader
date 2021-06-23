using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
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
        public string get_web_content(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();

            return output;
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

                    var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
                    ManagementObjectCollection mbsList = mbs.Get();
                    string id = "";
                    foreach (ManagementObject mo in mbsList)
                    {
                        id = mo["ProcessorId"].ToString();
                        break;
                    }


                    string json = get_web_content("https://nodahook.000webhostapp.com/api/v1/?mode=check&pwd=" + password.Text + "&key=" + username.Text + "&hw=" + id.ToString() + "&cc=" + Code.Text);
                    Console.WriteLine("https://nodahook.000webhostapp.com/api/v1/?mode=check&pwd=" + password.Text + "&key=" + username.Text + "&hw=" + id.ToString() + "&cc=" + Code.Text);
                    dynamic array = JsonConvert.DeserializeObject(json);

                    Console.WriteLine(json.ToString());

                    if (array.key == "valid")
                    {
                        Properties.Settings.Default.ex = array.expiry;
                        Properties.Settings.Default.Save();
                        authed auth = new authed();
                        auth.Show();
                        this.Hide();
                    }
                    else if(array.err == "expired")
                    {
                        MessageBox.Show("Error, account expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(array.err == "hwid2")
                    {
                        MessageBox.Show("An error occured when updating hwid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (array.err == "hwid")
                    {
                        MessageBox.Show("Error, hwid dismatch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (array.err == "cc")
                    {
                        MessageBox.Show("Error, security code doesn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (array.err == "pwd")
                    {
                        MessageBox.Show("Error, the password don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (array.err == "404")
                    {
                        MessageBox.Show("Error, user not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
