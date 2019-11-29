
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestingSystems.App_Data;
using System.Drawing;
using System.Globalization;
using TestingSystems;

public static class GlobleFunctionsHelper
{

    //public static void IntegerRound(this TextBox txtNumericTextBox)
    //{
    //    Double Value;
    //    txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f0") : "");
    //}
    //public static void TwoDecimalPlaceRound(this TextBox txtNumericTextBox)
    //{
    //    Double Value;
    //    txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f2") : "");
    //}
    //public static void ThreeDecimalPlaceRound(this TextBox txtNumericTextBox)
    //{
    //    Double Value;
    //    txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f3") : "");
    //}
    //public static void AllowIntegerOnly(this KeyPressEventArgs e)
    //{
    //    if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true)
    //    {
    //    }
    //    else
    //    {
    //        e.Handled = true;
    //    }
    //}
    //public static void AllowFloatOnly(this KeyPressEventArgs e)
    //{
    //    if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || e.KeyChar == '.')
    //    {
    //    }
    //    else
    //    {
    //        e.Handled = true;
    //    }
    //}

    //public static void SetCustomDateFormat(this DateTimePicker dtp)
    //{
    //    dtp.CustomFormat = "dd MMM yyyy";
    //}
    //public static void SetCustomTimeFormat(this DateTimePicker dtp)
    //{
    //    dtp.CustomFormat = "hh:mm:ss tt";
    //}

    //public static bool SetEmptyDateFormat(this DateTimePicker dtp, PreviewKeyDownEventArgs e)
    //{
    //    if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
    //    {
    //        dtp.CustomFormat = "''";
    //        return true;
    //    }
    //    else
    //        return false;
    //}

    //public static void EntryNoAddPadding(this TextBox txtTextBox, Int32 PaddingLength, char PaddingChar)
    //{
    //    if (txtTextBox.TextLength > PaddingLength)
    //    {
    //        MessageBox.Show("Please Enter No of " + PaddingLength + " Chars", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        txtTextBox.Clear();
    //        return;
    //    }

    //    txtTextBox.Text = txtTextBox.Text.PadLeft(PaddingLength, PaddingChar);
    //}
    // This Function Checks inventory of Casting and gives porper messages and returns fALSE IF not have proper stock



    private static string GetRenderingExtension(Extension extension)
    {
        switch (extension.Name)
        {
            case "PDF":
                return ".pdf";
            case "CSV":
                return ".csv";
            case "EXCEL":
                return ".xls";
            case "MHTML":
                return ".mhtml";
            case "IMAGE":
                return ".tif";
            case "XML":
                return ".xml";
            case "WORD":
                return ".doc";
            case "HTML4.0":
                return ".html";
            case "NULL":
                throw new NotImplementedException("Extension not implemented.");
        }

        throw new NotImplementedException("Extension not implemented.");
    }
    public static void OpenFileWithPrompt(string file)
    {

        Process.Start(file);
    }
    public static void ExportExcel(this ReportViewer reportViewer1, String ReportName)
    {
        try
        {
            ToolStrip myToolStrip = (ToolStrip)(reportViewer1.Controls.Find("toolStrip1", true)[0]);

            Microsoft.Reporting.WinForms.Warning[] warnings;

            String[] streamids;
            String mimeType = "";
            String encoding = "";
            String extension = "";

            byte[] bytes = reportViewer1.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Extension e = new Extension("EXCEL", "EXCEL File", true);
            string extensions = GetRenderingExtension(e);
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save As",
                CheckPathExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                //FileName = Path.GetFileNameWithoutExtension(reportViewer1.LocalReport.ReportPath),
                FileName = Path.GetFileNameWithoutExtension(ReportName),
                Filter = e.LocalizedName + " (*" + extensions + ")|*" + extensions + "|All files(*.*)|*.*",
                FilterIndex = 0
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs;
                fs = new FileStream(saveFileDialog.FileName + extensions, System.IO.FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                fs.Dispose();
                OpenFileWithPrompt(saveFileDialog.FileName + extensions);


                reportViewer1.ReportExport += new ExportEventHandler(ReportViewer1_ReportExport);
            }
        }
        catch (Exception ex)
        {

            ExceptionHandler.LogException(ex);
            MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private static void ReportViewer1_ReportExport(object sender, ReportExportEventArgs e)
    {
        e.Cancel = true;


        // this.reportViewer1.ExportDialog(e.Extension, e.DeviceInfo, saveFileDialog.FileName);

        // Here's where I call my method to prompt user to open the file.

    }

    
}