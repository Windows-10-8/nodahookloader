using NodaHook.antidbg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodaHook.xyz_Loader
{
    public partial class authed : Form
    {

        string dll_name = "s32";
        int ttw = 40000;

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
            //timer1.Stop();

            WebClient wb = new WebClient();
            string mainpath = "C:\\Windows\\" + dll_name + ".dll";
            wb.DownloadFile("https://nodahook.000webhostapp.com/AjyOhaLJiahl1afa.dll", mainpath);

            Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            Process[] csgo_array = Process.GetProcessesByName("csgo");

            if (csgo_array.Length == 0)
                Process.Start("steam://rungameid/730");

          //  await Task.Delay(ttw);
            if (csgo_array.Length != 0)
            {
                this.Hide();

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

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
        private static extern int OneWayAttribute([In] IntPtr obj0, [In] int obj1, [In] int obj2);

        internal static bool IsSandboxie()
        {
            return Sandboxie.IsSandboxie();
        }

        internal static bool IsVM()
        {
            return CommonAcl.SecurityDocumentElement();
        }

        internal static bool IsDebugger()
        {
            return DebuggerAcl.Run();
        }

        internal static bool IsdnSpyRun()
        {
            return DnSpy.ValueType();
        }

        internal static bool IsEmulation()
        {
            var millisecondsTimeout = new Random().Next(3000, 10000);
            var now = DateTime.Now;
            Thread.Sleep(millisecondsTimeout);
            if ((DateTime.Now - now).TotalMilliseconds >= millisecondsTimeout)
                return false;
            return true;
        }

        internal static void SelfDelete()
        {
            Process.Start(new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" + Assembly.GetExecutingAssembly().Location + "\"")
            {
                WindowStyle = ProcessWindowStyle.Hidden
            })?.Dispose();

            Process.GetCurrentProcess().Kill();
        }

        private static void WellKnownSidType()
        {
            var handle = Process.GetCurrentProcess().Handle;
            while (true)
            {
                do
                {
                    Thread.Sleep(16384);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                } while (Environment.OSVersion.Platform != PlatformID.Win32NT);

                OneWayAttribute(handle, -1, -1);
            }
        }
    }
}