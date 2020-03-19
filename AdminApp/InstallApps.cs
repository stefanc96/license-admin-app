using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using FluentFTP;
using ICSharpCode.SharpZipLib.Zip;

namespace AdminApp
{
    public partial class InstallApps : Form
    {
        ArrayList selectedFiles = new ArrayList();
        readonly AmazonS3Uploader amazonS3Uploader;
        System.Threading.Timer timer = null;

        public static List<string> clients = new List<string>();
        private static InstallApps instance;

        public static InstallApps Instance()
        {
            if (instance == null)
            {
                instance = new InstallApps();
            }
            return instance;
        }
        private InstallApps()
        {
            InitializeComponent();
            this.CreateControl();
            this.TopLevel = false;
            amazonS3Uploader = new AmazonS3Uploader();
        }

        public static void Clear()
        {
            clients.Clear();
            Instance().succesList.Invoke(new Action(() => Instance().succesList.Items.Clear()));
            Instance().failList.Invoke(new Action(() => Instance().failList.Items.Clear()));
        }

        public static void AddClient(RDPClient client)
        {
            if (!clients.Contains(client.ip))
            {
                clients.Add(client.ip);
                Instance().hostList.Invoke(new Action(() => Instance().hostList.Items.Add(client.ip)));
            }
      
        }

        public static void AddSuccesufulClient(string ip)
        {
            Instance().succesList.Invoke(new Action(() => Instance().succesList.Items.Add(ip)));
        }

        public static void AddFailClient(string ip)
        {
            Instance().failList.Invoke(new Action(() => Instance().failList.Items.Add(ip)));
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

        public void StartTimeout()
        {
   
            timer = new System.Threading.Timer((obj) =>
            {
                ExecuteAfterTimeout();
                timer.Dispose();
            },null, 60000, System.Threading.Timeout.Infinite);
        }

        public void ExecuteAfterTimeout()
        {

            foreach (string client in clients)
            {
                Instance().succesList.Invoke(new Action(() => {
                    if (Instance().succesList.Items.ContainsKey(client))
                    {
                        Instance().failList.Items.Add(client);
                    }
                }));
            }
        }
        private void OnInstallClick(object sender, EventArgs e)
        {
            string fileName = "test.zip";
            if (selectedFiles.Count > 0)
            {
                progressBar.Value = 0;
                failList.Items.Clear();
                succesList.Items.Clear();
                progressBar.Increment(20);
                CreateZipFile(fileName);
                selectedFiles.Clear();
                succesList.Items.Clear();
                failList.Items.Clear();
                SelectedListView.Clear();
                progressBar.Increment(40);
                amazonS3Uploader.UploadFile(fileName);
                progressBar.Increment(80);
                File.Delete(fileName);
                UdpHelper.Instance().SendInstallInfo("https://licenta-stefan.s3.eu-central-1.amazonaws.com/" + fileName, clients);
                StartTimeout();
                progressBar.Increment(100);
            }
            else
            {
                MessageBox.Show("Please select files to install!");
            }
        }

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
                    SelectedListView.Items.Add(file);
                }
            }
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            string fileName = "test.zip";
            if(failList.Items.Count > 0)
            {
                List<string> retryList = new List<string>();
                foreach(ListViewItem item in failList.Items)
                {
                    retryList.Add(item.Text);
                }
                UdpHelper.Instance().SendInstallInfo("https://licenta-stefan.s3.eu-central-1.amazonaws.com/" + fileName, retryList);
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
            SelectedListView.Items.Clear();
            progressBar.Value = 0;
        }
    }
}
