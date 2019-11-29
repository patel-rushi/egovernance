using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TestingSystems.App_Data;
using TestingSystems.Helpers;
using TestingSystems;
//using iTextSharp.text.pdf;
//using iTextSharp.text;

namespace Inventory_Management
{
    public partial class PatternImagePopup : Form
    {
        DataTable dtFetchImageFiles;
        int Fileuploadpos = 0;
        List<String> multipleImage = new List<string>();
        public Boolean IsSupplierEvaluation { get; set; }
        public PatternImagePopup(DataTable dtImage_, Boolean _IsSupplierEvaluation = false)
        {
            InitializeComponent();
            dtFetchImageFiles = dtImage_;
            IsSupplierEvaluation = _IsSupplierEvaluation;
        }

        private void PatternImagePopup_Load(object sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();

                string destinationpathCheck = "0";
                if (IsSupplierEvaluation)
                {
                    destinationpathCheck = TestingSystems.Helpers.PathHelper.MaterialSampleInspectionFiles();
                }
                else
                {
                    destinationpathCheck = TestingSystems.Helpers.PathHelper.TestingSystems();
                }
                
                if (destinationpathCheck == "0")
                {
                    const string type = "Shared folder of iCast file on server is not accessible files , so can not be uploaded.";
                    System.Windows.Forms.MessageBox.Show(type, TestingSystems.Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }

                if (destinationpathCheck != "0")
                {
                    for (int i = 0; i < dtFetchImageFiles.Rows.Count; i++)
                    {
                        if (!IsSupplierEvaluation)
                        {
                            if (File.Exists(TestingSystems.Helpers.PathHelper.TestingSystems() + dtFetchImageFiles.Rows[i]["FileName"].ToString()))
                            {
                                String TransferFileFrom = TestingSystems.Helpers.PathHelper.TestingSystems() + dtFetchImageFiles.Rows[i]["FileName"].ToString();
                                String Name = TransferFileFrom.Substring(TransferFileFrom.LastIndexOf("\\") + 1);
                                multipleImage.Add(TransferFileFrom + "," + Name.Substring(10));
                                // File.Copy(multipleImage[i].Split(',')[0], pathString + dtFetchImageFiles.Rows[i]["FilePath"].ToString(), true);


                                if (multipleImage[i].Split(',')[0].EndsWith(".pdf") == true || multipleImage[i].Split(',')[0].EndsWith(".PDF") == true)
                                {
                                    PatternPictureBox.Hide();
                                    axUploadPatternPDF.Show();
                                    axUploadPatternPDF.LoadFile(multipleImage[i].Split(',')[0]);
                                    lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].LastIndexOf("\\") + 1);
                                    axUploadPatternPDF.Refresh();
                                }
                                else
                                {
                                    PatternPictureBox.Show();
                                    axUploadPatternPDF.Hide();

                                    lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].Split(',')[0].LastIndexOf("\\") + 1);
                                    PatternPictureBox.Image = Bitmap.FromFile(multipleImage[i].Split(',')[0]);
                                    PatternPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                        }
                        else
                        {
                            if (File.Exists(TestingSystems.Helpers.PathHelper.MaterialSampleInspectionFiles() + dtFetchImageFiles.Rows[i]["FileName"].ToString()))
                            {
                                String TransferFileFrom = TestingSystems.Helpers.PathHelper.MaterialSampleInspectionFiles() + dtFetchImageFiles.Rows[i]["FileName"].ToString();
                                String Name = TransferFileFrom.Substring(TransferFileFrom.LastIndexOf("\\") + 1);
                                multipleImage.Add(TransferFileFrom + "," + Name.Substring(10));
                                // File.Copy(multipleImage[i].Split(',')[0], pathString + dtFetchImageFiles.Rows[i]["FilePath"].ToString(), true);


                                if (multipleImage[i].Split(',')[0].EndsWith(".pdf") == true || multipleImage[i].Split(',')[0].EndsWith(".PDF") == true)
                                {
                                    PatternPictureBox.Hide();
                                    axUploadPatternPDF.Show();
                                    axUploadPatternPDF.LoadFile(multipleImage[i].Split(',')[0]);
                                    lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].LastIndexOf("\\") + 1);
                                    axUploadPatternPDF.Refresh();
                                }
                                else
                                {
                                    PatternPictureBox.Show();
                                    axUploadPatternPDF.Hide();

                                    lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].Split(',')[0].LastIndexOf("\\") + 1);
                                    PatternPictureBox.Image = Bitmap.FromFile(multipleImage[i].Split(',')[0]);
                                    PatternPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                        }
                    }
                }
                int count = 0;
                count = multipleImage.Count();
                if (count == 1)
                {
                    btnPatternPrev.Visible = false;
                    btnPatternNext.Visible = false;
                }
                if (count >= 2)
                {
                    btnPatternPrev.Visible = true;
                }
                if (Fileuploadpos == (count - 1))
                {
                    btnPatternNext.Visible = false;
                }
            }
            catch (Exception ex)
            {

                //ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(TestingSystems.Helper.MessageBoxMessages.entryerror, TestingSystems.Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Image or pdf will be open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDownload1_Click(object sender, EventArgs e)
        {
            try
            {
                string networkPath;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.Title = "Download";
                saveFileDialog1.FileName = lblPatternImageName.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destinationpathCheck = TestingSystems.Helpers.PathHelper.TestingSystems();
                    if (destinationpathCheck == "0")
                    {
                        const string type = "Shared folder of iCast file on server is not accessible files , so can not be uploaded. do you want to continue with data ?";
                       DialogResult dresult = System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                       if (dresult == DialogResult.No)
                       {
                           return;
                       }                    
                    }

                    if (destinationpathCheck != "0")
                    {
                        networkPath = TestingSystems.Helpers.PathHelper.TestingSystems() + lblPatternImageName.Text;

                        // If the file name is not an empty string open it for saving. 
                        if (saveFileDialog1.FileName != "")
                        {
                            if ((lblPatternImageName.Text.Substring(lblPatternImageName.Text.LastIndexOf(".")) != ".pdf")
                            && (lblPatternImageName.Text.Substring(lblPatternImageName.Text.LastIndexOf(".")) != ".PDF"))
                            {
                                // Saves the Image in the appropriate ImageFormat based upon the  
                                // File type selected in the dialog box.  
                                // NOTE that the FilterIndex property is one-based.  

                                switch (saveFileDialog1.FilterIndex)
                                {
                                    case 1:
                                        File.Copy(networkPath, saveFileDialog1.FileName + "." + System.Drawing.Imaging.ImageFormat.Jpeg, true);
                                        System.Windows.Forms.MessageBox.Show("Image downloaded successfully", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                        break;


                                    case 2:
                                        File.Copy(networkPath, saveFileDialog1.FileName + "." + System.Drawing.Imaging.ImageFormat.Bmp, true);
                                        System.Windows.Forms.MessageBox.Show("Image downloaded successfully", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                        break;

                                    case 3:
                                        File.Copy(networkPath, saveFileDialog1.FileName + "." + System.Drawing.Imaging.ImageFormat.Png, true);
                                        System.Windows.Forms.MessageBox.Show("Image downloaded successfully", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                        break;
                                }
                            }
                            else
                            {
                                File.Copy(networkPath, saveFileDialog1.FileName);
                                System.Windows.Forms.MessageBox.Show("Pdf file downloaded successfully", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            if (keyData == (Keys.Escape))
            {
                this.Close();
            }



            return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion

        private void lnkNext_Click(object sender, EventArgs e)
        {
            try
            {
                int count = multipleImage.Count();
                Fileuploadpos = Fileuploadpos + 1;
                if (btnPatternNext.Enabled)
                {
                    if (multipleImage.Count >= Fileuploadpos)
                    {
                        String extData = Path.GetExtension(multipleImage[Fileuploadpos].Split(',')[0]);
                        if (multipleImage[Fileuploadpos].Split(',')[0].EndsWith(".pdf") == true || multipleImage[Fileuploadpos].Split(',')[0].EndsWith(".PDF") == true)
                        {
                            PatternPictureBox.Hide();
                            axUploadPatternPDF.Show();
                            axUploadPatternPDF.LoadFile(multipleImage[Fileuploadpos].Split(',')[0]);
                            lblPatternImageName.Text = multipleImage[Fileuploadpos].Split(',')[0].Substring(multipleImage[Fileuploadpos].Split(',')[0].LastIndexOf("\\") + 1);
                        }
                        else
                        {
                            axUploadPatternPDF.Hide();
                            PatternPictureBox.Show();
                            PatternPictureBox.Image = Bitmap.FromFile(multipleImage[Fileuploadpos].Split(',')[0]);
                            PatternPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            lblPatternImageName.Text = multipleImage[Fileuploadpos].Split(',')[0].Substring(multipleImage[Fileuploadpos].Split(',')[0].LastIndexOf("\\") + 1);
                        }
                    }
                }
                if (Fileuploadpos == count - 1)
                {
                    btnPatternNext.Visible = false;
                    btnPatternPrev.Visible = true;
                }
                if (Fileuploadpos >= 0)
                {
                    btnPatternPrev.Visible = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPatternPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int count = multipleImage.Count();
                if (Fileuploadpos > 0)
                {
                    Fileuploadpos = Fileuploadpos - 1;
                    if (multipleImage.Count >= Fileuploadpos)
                    {
                        String extData = Path.GetExtension(multipleImage[Fileuploadpos].Split(',')[0]);

                        if (multipleImage[Fileuploadpos].Split(',')[0].EndsWith(".pdf") == true || multipleImage[Fileuploadpos].Split(',')[0].EndsWith(".PDF") == true)
                        {
                            PatternPictureBox.Hide();
                            axUploadPatternPDF.Show();
                            axUploadPatternPDF.LoadFile(multipleImage[Fileuploadpos].Split(',')[0]);
                            lblPatternImageName.Text = multipleImage[Fileuploadpos].Split(',')[0].Substring(multipleImage[Fileuploadpos].Split(',')[0].LastIndexOf("\\") + 1);
                        }
                        else
                        {
                            axUploadPatternPDF.Hide();
                            PatternPictureBox.Show();
                            PatternPictureBox.Image = Bitmap.FromFile(multipleImage[Fileuploadpos].Split(',')[0]);
                            PatternPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            lblPatternImageName.Text = multipleImage[Fileuploadpos].Split(',')[0].Substring(multipleImage[Fileuploadpos].Split(',')[0].LastIndexOf("\\") + 1);
                        }

                        if (Fileuploadpos == count - 2)
                        {
                            btnPatternNext.Visible = true;
                        }
                    }
                }
                if (Fileuploadpos == 0)
                {
                    btnPatternPrev.Visible = false;
                    btnPatternNext.Visible = true;
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
