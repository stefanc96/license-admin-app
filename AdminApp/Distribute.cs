using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Distribute : Form
    {
        public static List<string> clients = new List<string>();
        private static Distribute instance;
        System.Threading.Timer timer = null;

        public static Distribute Instance()
        {
            if (instance == null)
            {
                instance = new Distribute();
            }
            return instance;
        }
        private Distribute()
        {
            this.TopLevel = false;
            InitializeComponent();
            this.CreateControl();
            amazonS3Uploader = new AmazonS3Uploader();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string client in clients)
            {

                if (!this.hostList.Items.ContainsKey(client))
                {
                    this.hostList.Items.Add(client);
                }
            }
        }

        ArrayList selectedFiles = new ArrayList();
        readonly AmazonS3Uploader amazonS3Uploader;
        readonly string zipName = "share.zip";

        private void OnSelectClick(object sender, EventArgs e)
        {
            selectedFiles = new ArrayList();
            OpenFileDialog fileSelector = new OpenFileDialog
            {
                Multiselect = true
            };
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in fileSelector.FileNames)
                {
                    selectedFiles.Add(file);
                    selectedListView.Items.Add(file);
                }
            }
        }

        public static void Clear()
        {
            Instance().succesList.Invoke(new Action(() => Instance().succesList.Items.Clear()));
            Instance().failList.Invoke(new Action(() => Instance().failList.Items.Clear()));
        }

        public void CreateZipFile(string fileName)
        {
            ZipFile zipFile = ZipFile.Create(fileName);
            foreach (string file in selectedFiles)
            {
                IStaticDataSource data = new StaticDiskDataSource(file);
                zipFile.BeginUpdate();
                zipFile.Add(data, Path.GetFileName(file));
                zipFile.CommitUpdate();

            }
            zipFile.Close();

        }

        public static void AddClient(RDPClient client)
        {
            if (!clients.Contains(client.ip))
            {
                clients.Add(client.ip);
                Instance().hostList.Invoke(new Action(() => Instance().hostList.Items.Add(client.ip)));
            }

        }
        public static void AddSuccesfullClient(string ip)
        {
            Instance().succesList.Invoke(new Action(() => Instance().succesList.Items.Add(ip)));
        }
        public static void AddFailClient(string ip)
        {
            Instance().failList.Invoke(new Action(() => Instance().failList.Items.Add(ip)));
        }

        public void StartTimeout()
        {
            timer = new System.Threading.Timer((obj) =>
            {
                ExecuteAfterTimeout();
                timer.Dispose();
            }, null, 60000, System.Threading.Timeout.Infinite);
        }

        public void ExecuteAfterTimeout()
        {
            foreach (string client in clients)
            {
                Instance().succesList.Invoke(new Action(() => {
                    if (Instance().succesList.Items.ContainsKey(client)) {
                        Instance().failList.Items.Add(client);
                    }
                }));
            }
        }

        private void OnSendClick(object sender, EventArgs e)
        {
            if (selectedFiles.Count > 0)
            {
                progressBar.Value = 0;
                failList.Items.Clear();
                succesList.Items.Clear();
                progressBar.Increment(20);
                CreateZipFile(zipName);
                progressBar.Increment(60);
                selectedFiles.Clear();
                selectedListView.Clear();
                amazonS3Uploader.UploadFile(zipName);
                progressBar.Increment(80);
                File.Delete(zipName);
                UdpHelper.Instance().SendFile("https://licenta-stefan.s3.eu-central-1.amazonaws.com/" + zipName, clients);
                progressBar.Increment(100);
                StartTimeout();
            }
            else
            {
                MessageBox.Show("Please select files to distribute!");
            }
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            string zipName = "share.zip";
            if (failList.Items.Count > 0)
            {
                List<string> retryList = new List<string>();
                foreach (ListViewItem item in failList.Items)
                {
                    retryList.Add(item.Text);
                }
                UdpHelper.Instance().SendInstallInfo("https://licenta-stefan.s3.eu-central-1.amazonaws.com/" + zipName, retryList);
            }
            else
            {
                MessageBox.Show("Fail List is empty!");
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Clear();
            if (timer != null)
            {
                timer.Dispose();
            }
            selectedFiles.Clear();
            selectedListView.Items.Clear();
            progressBar.Value = 0;
        }
    }
}
