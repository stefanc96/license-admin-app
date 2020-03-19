using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdminApp
{
    class UdpHelper
    {
        private readonly UdpClient udpClient;
        private static UdpHelper instance;
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
        const string MethodSendInfo = "INFO";
        const string MethodInstall = "INSTALL";
        const string MethodShare = "SHARE";
        const string MethodDiscover = "DISCOVER";
        List<ClientInfo> clients = new List<ClientInfo>();
        Aes myAes = Aes.Create();
        private string key;
        private string IV;
        private UdpHelper()
        {
            udpClient = new UdpClient(Constants.LocalUdpPort);
        }

        public static UdpHelper Instance()
        {
            if (instance == null)
            {
                instance = new UdpHelper();
            }
            return instance;
        }

        IAsyncResult asyncResult = null;

        public void StartListening()
        {
            asyncResult = udpClient.BeginReceive(Receive, new object());
        }

        private void ProcessSendInfo(byte[] info)
        {
            string message = DecryptStringFromBytes_Aes(info, myAes.Key, myAes.IV);
   
            JObject jObject = JObject.Parse(message);
            string ip = jObject["ip"].ToString();
 
            string connection = jObject["connectionString"].ToString();
            RDPClient client = new RDPClient(connection, ip);
            HostList.clients.Add(client);
            Distribute.clients.Add(client.ip);
            HostList.Instance().CreateControl();
            if (HostList.Instance().IsHandleCreated)
            {
                HostList.AddClient(client);
            }
            if (InstallApps.Instance().IsHandleCreated)
            {
                InstallApps.AddClient(client);
            }
            if (Distribute.Instance().IsHandleCreated)
            {
                Distribute.AddClient(client);
            }
        }

        private void ProcessInstall(byte[] info)
        {
            string message = DecryptStringFromBytes_Aes(info, myAes.Key, myAes.IV);
            Response response = JsonConvert.DeserializeObject<Response>(message);
            if (response.isSucces)
            {
                InstallApps.AddSuccesufulClient(response.ip);
            }
            else
            {
                InstallApps.AddFailClient(response.ip);
            }
       
        }

        private void ProcessShare(byte[] info)
        {
            string message = DecryptStringFromBytes_Aes(info, myAes.Key, myAes.IV);
            Response response = JsonConvert.DeserializeObject<Response>(message);
            if (response.isSucces)
            {
                Distribute.AddSuccesfullClient(response.ip);
            }
            else
            {
                Distribute.AddFailClient(response.ip);
            }
        }

        public void ProcessDiscover(byte[] info)
        {
            JObject jObject = JObject.Parse(Encoding.ASCII.GetString(info));
            string ip = jObject["ip"].ToString();
            string PK = jObject["PK"].ToString();
            ClientInfo client = new ClientInfo(ip, PK);
            if (!clients.Contains(client))
            {
                clients.Add(client);
            }
            GetInfo(ip, PK);
        }
        private void ProcessMethod(string method, byte[] info)
        {
            switch (method)
            {
                case MethodSendInfo:
                    ProcessSendInfo(info);
                    break;
                case MethodInstall:
                    ProcessInstall(info);
                    break;
                case MethodShare:
                    ProcessShare(info);
                    break;
                case MethodDiscover:
                    ProcessDiscover(info);
                    break;

            }
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
     

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;

        }
        static string GetLocalIp()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
           
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        private byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, Constants.LocalUdpPort);
            byte[] bytes = udpClient.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
   
            ProcessMethod(message.Split(' ')[1], GetData(bytes));
            StartListening();
        }

        public void SendInstallInfo(string info, List<string> targets)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), Constants.DefaultBroadcastUdpPort);
            string method = "Method: INSTALL ";
            string infoMessage = JsonConvert.SerializeObject(new Message(info, targets.ToArray()));
            byte[] encryptedInfo = EncryptStringToBytes_Aes(infoMessage, myAes.Key, myAes.IV);
            byte[] bytes = Combine(Encoding.ASCII.GetBytes(method), encryptedInfo);
            udpClient.Send(bytes, bytes.Length, ip);
        }

        public void SendFile(string info, List<string> targets)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), Constants.DefaultBroadcastUdpPort);
            string method = "Method: SHARE ";
          
            string infoMessage = JsonConvert.SerializeObject(new Message(info, targets.ToArray()));
            byte[] encryptedInfo = EncryptStringToBytes_Aes(infoMessage, myAes.Key, myAes.IV);
            byte[] bytes = Combine(Encoding.ASCII.GetBytes(method), encryptedInfo);
            udpClient.Send(bytes, bytes.Length, ip);
        }

        public void SendDiscoverMessage()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), Constants.DefaultBroadcastUdpPort);
            string method = "Method: DISCOVER ";
            string localIp = GetLocalIp();
            byte[] bytes = Encoding.ASCII.GetBytes(method + localIp);
            udpClient.Send(bytes, bytes.Length, ip);
        }

        public void GetInfo(string clientIp, string PK)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(clientIp), Constants.DefaultBroadcastUdpPort);
            string method = "Method: INFO ";
            key = Encoding.ASCII.GetString(myAes.Key);
            IV = Encoding.ASCII.GetString(myAes.IV);
            string message = JsonConvert.SerializeObject(new AesInfo(myAes.Key, myAes.IV));
            rsaProvider.FromXmlString(PK);
            byte[] encryptedInfo = rsaProvider.Encrypt(Encoding.ASCII.GetBytes(message), false);
            byte[] bytes = Combine(Encoding.ASCII.GetBytes(method), encryptedInfo);
            udpClient.Send(bytes, bytes.Length, ip);
        }

        private static byte[] GetData(byte[] info)
        {
            int spaceCounter = 0;
            List<byte> array = new List<byte>();
            for (int i = 0; i < info.Length; i++)
            {
                char c = Convert.ToChar(info[i]);
                if (c == ' ')
                {
                    spaceCounter++;
                    if (spaceCounter == 2) continue;
                }
                if (spaceCounter >= 2)
                {
                    array.Add(info[i]);
                }
            }
            return array.ToArray();
        }
    }
}
