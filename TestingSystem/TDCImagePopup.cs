using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace TestingSystems
{
    public partial class TDCImagePopup : Form
    {

        DataTable dtFetchImageFiles;
        int Fileuploadpos = 0;
        List<String> multipleImage = new List<string>();

        public TDCImagePopup(DataTable dtImage_)
        {
            InitializeComponent();
            dtFetchImageFiles = dtImage_;
        }

        private void TDCImagePopup_Load(object sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();

                for (int i = 0; i < dtFetchImageFiles.Rows.Count; i++)
                {
                    if (File.Exists(Helpers.PathHelper.CustomerTDCImageFile() + dtFetchImageFiles.Rows[i]["FileName"].ToString()))
                    {
                        String TransferFileFrom = Helpers.PathHelper.CustomerTDCImageFile() + dtFetchImageFiles.Rows[i]["FileName"].ToString();
                        String Name = TransferFileFrom.Substring(TransferFileFrom.LastIndexOf("\\") + 1);
                        multipleImage.Add(TransferFileFrom + "," + Name.Substring(10));
                        // File.Copy(multipleImage[i].Split(',')[0], pathString + dtFetchImageFiles.Rows[i]["FilePath"].ToString(), true);
                    }

                    if (multipleImage[i].Split(',')[0].EndsWith(".pdf") == true || multipleImage[i].Split(',')[0].EndsWith(".PDF") == true)
                    {
                        axUploadTDCPDF.LoadFile(multipleImage[i].Split(',')[0]);
                        lblTDCImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].LastIndexOf("\\") + 1);
                        axUploadTDCPDF.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDownload1_Click(object sender, EventArgs e)
        {
            try
            {
                string networkPath;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.Title = "Download";
                saveFileDialog1.FileName = lblTDCImageName.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    networkPath = Helpers.PathHelper.CustomerTDCImageFile() + lblTDCImageName.Text;

                    // If the file name is not an empty string open it for saving. 
                    if (saveFileDialog1.FileName != "")
                    {
                        File.Copy(networkPath, saveFileDialog1.FileName);
                        System.Windows.Forms.MessageBox.Show("Pdf file downloaded successfully", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
