using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class HostList : Form
    {
        public static List<RDPClient> clients = new List<RDPClient>();
        private static HostList instance;

        public static HostList Instance()
        {
            if (instance == null)
            {
                instance = new HostList();
            }
            return instance;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
 
            foreach (RDPClient client in clients)
            {

                if (!this.hostsList.Items.ContainsKey(client.ip))
                {
                    this.hostsList.Items.Add(client.ip, 0);
                }
            }
        }
        public HostList()
        {
            InitializeComponent();
        }

        public static void AddClient(RDPClient client)
        {
            if (!clients.Contains(client))
            {
                clients.Add(client);
                Instance().hostsList.Invoke(new Action(() => HostList.Instance().hostsList.Items.Add(client.ip, 0)));
            }
        }

       private void OnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void OnSelectItem(object sender, EventArgs e)
        {
            var item = hostsList.SelectedItems[0];
            var client = clients.Find(c => c.ip == item.Text);
            new RemoteDesktop(client.connectionString).Show();
        }
    }
}
