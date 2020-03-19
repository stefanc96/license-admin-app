using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public class AmazonS3Uploader
    {
        private string bucketName = "licenta-stefan";
        AmazonS3Client client;
        TransferUtility transferUtility;

        public AmazonS3Uploader()
        {
            client = new AmazonS3Client(Amazon.RegionEndpoint.EUCentral1);
            transferUtility = new TransferUtility(client);
        }

        public void UploadFile(string filePath)
        {
            try
            {
              
                TransferUtilityUploadRequest putRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                };
                try
                {
                    transferUtility.Upload(putRequest);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Failed to connect to Amazon!");
                }
            
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }

}
