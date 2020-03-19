using AxRDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class RemoteDesktop : Form
    {
        public RemoteDesktop(string connectionString)
        {
            InitializeComponent();
            Connect(connectionString, this.axRDPViewer, "Licenta", "");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Disconnect(this.axRDPViewer);
        }
        public static void Connect(string invitation, AxRDPViewer display, string userName, string password)
        {
            display.Connect(invitation, userName, password);
        }

        public static void Disconnect(AxRDPViewer display)
        {
            display.Disconnect();
        }
    }
}
