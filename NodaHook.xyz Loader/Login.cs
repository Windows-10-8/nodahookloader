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
            //Not complete
            bool logged = false;

            if(!logged)
            {
                MessageBox.Show("User not found or the password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
