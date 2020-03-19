using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uhttpsharp;
using uhttpsharp.Listeners;
using uhttpsharp.RequestProviders;

namespace AdminApp
{
    public partial class App : Form
    {
        public App()
        {
            UdpHelper.Instance().StartListening();
            InitializeComponent();
            Distribute.Instance();
            HostList.Instance();
            UdpHelper.Instance().SendDiscoverMessage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InstallApps main = InstallApps.Instance();
            content.Controls.Clear();
            content.Controls.Add(main);
            main.Show();
        }

        private void OnPressDistribute(object sender, EventArgs e)
        {
            Distribute distribute = Distribute.Instance();
            content.Controls.Clear();
            content.Controls.Add(distribute);
            distribute.Show();
        }

        private void OnHostClick(object sender, EventArgs e)
        {
            HostList controls = HostList.Instance();
            controls.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(controls);
            controls.Show();
        }

        private void OnInstallClick(object sender, EventArgs e)
        {
            InstallApps main = InstallApps.Instance();
            content.Controls.Clear();
            content.Controls.Add(main);
            main.Show();
        }
    }
}
