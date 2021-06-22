using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodaHook.xyz_Loader
{
    public partial class authed : Form
    {

        string dll_name = "sys32";
        int time_to_wait = 40000;

        public authed()
        {
            InitializeComponent();
        }

        private void authed_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome back," + Properties.Settings.Default.username;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            this.Hide();
            string mainpath = "C:\\Windows\\" + dll_name + ".dll";
            wb.DownloadFile("https://sidesense.000webhostapp.com/urmad.iq_hhaja_mad_iq_uncrakable_nigga_ez.dll", mainpath);

            Process.Start("steam://rungameid/730");
            Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            Process[] csgo_array = Process.GetProcessesByName("csgo");
            await Task.Delay(time_to_wait);
            if (csgo_array.Length != 0)
            {
                Inject.InjectMethod.Inject(mainpath, "csgo");
                Console.Read();
                csgo.WaitForExit();

                if (File.Exists(mainpath))
                {
                    File.Delete(mainpath);
                }
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}