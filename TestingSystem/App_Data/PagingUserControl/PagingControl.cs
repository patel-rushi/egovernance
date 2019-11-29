using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagingUserControl
{
    public delegate void PagingEventHandler();
    public partial class PagingControl : UserControl
    {
        public event PagingEventHandler Pagingevent;

        #region Properties

        private bool _ShowProgressBar = true;
        private string _ProgressMessage = "Loading...";
        private List<int> _PageSize = new List<int>() { 20, 25, 50, 100 };

        [Description("This message will be displayed at the time of processing data."),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        Bindable(true)]
        public string ProgressMessage
        {
            get { return _ProgressMessage; }
            set { _ProgressMessage = value; }
        }

        [Description("Page size."),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        Bindable(true)]
        public List<int> PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        [Description("Show progress bar"), Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        Bindable(true)]
        public bool ShowProgressBar
        {
            get { return _ShowProgressBar; }
            set { _ShowProgressBar = value; }
        }

        public int CurrentPageIndex = 0;

        private int CurrentPageNumber
        {
            get
            {
                return CurrentPageIndex + 1;
            }
        }

        public int CurrentPageSize { get; set; }

        public int TotalRecords { get; set; }

        private int TotalPages
        {
            get
            {
                return CalculateTotalPages();
            }
        }

        private bool ProcessCompleted = false;

        private bool _Initializing = false;

        #endregion

        #region Constructor

        public PagingControl()
        {
            BeginInitialization();

            InitializeComponent();

            this.lblLoading.Text = string.Empty;

            this.progressBar1.Visible = _ShowProgressBar;
            this.lblLoading.Visible = !_ShowProgressBar;

            this.txtPageNumber.Text = CurrentPageNumber.ToString();

            foreach (var pageSize in _PageSize)
            {
                this.ddlPageSize.Items.Add(pageSize);
            }

            if (this.ddlPageSize.Items != null && this.ddlPageSize.Items.Count > 0) this.ddlPageSize.SelectedIndex = 0;

            EndInitialization();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method will assign BackgroundWorker events
        /// </summary>
        /// <param name="doWorkevent">DoWork event</param>
        /// <param name="progressChangeevent">ProgressChanged event</param>
        /// <param name="runWorkerCompletedEvent">RunWorkerCompleted event</param>
        public void InitializeBackgroundWorker(DoWorkEventHandler doWorkevent, ProgressChangedEventHandler progressChangeevent, RunWorkerCompletedEventHandler runWorkerCompletedEvent)
        {
            try
            {
                this.bwProcessDataRetrieval.DoWork += doWorkevent;
                this.bwProcessDataRetrieval.ProgressChanged += progressChangeevent;
                this.bwProcessDataRetrieval.RunWorkerCompleted += runWorkerCompletedEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This method will set Total Records, Total Pages, Page Number values
        /// </summary>
        public void CommitProcess()
        {
            try
            {
                this.ProcessCompleted = true;
                ChangePagingResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Private Methods

        private void BeginInitialization()
        {
            _Initializing = true;
        }

        private void EndInitialization()
        {
            _Initializing = false;
        }

        private void ApplyPaging()
        {
            if (!bwPaging.IsBusy)
            {
                TotalRecords = 0;
                bwPaging.RunWorkerAsync();
            }
        }

        private int CalculateTotalPages()
        {
            return (TotalRecords > 0 && CurrentPageSize > 0) ? Convert.ToInt32(Math.Ceiling(Convert.ToDouble(TotalRecords) / Convert.ToDouble(CurrentPageSize))) : 0;
        }

        private delegate void ChangeLoadingStatus_Delegate(string Status);
        private void ChangeLoadingStatus(string loadingStatus)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new ChangeLoadingStatus_Delegate(ChangeLoadingStatus), new object[] { loadingStatus });
                }
                else
                {
                    this.lblLoading.Text = loadingStatus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void ChangePagingResult_Delegate();
        private void ChangePagingResult()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new ChangePagingResult_Delegate(ChangePagingResult));
                }
                else
                {
                    this.txtPageNumber.Text = this.CurrentPageNumber.ToString();
                    this.lblTotalRecordsValue.Text = this.TotalRecords.ToString();
                    this.lblTotalPages.Text = (TotalRecords > 0 && this.CurrentPageSize > 0) ? Convert.ToString(Math.Ceiling(Convert.ToDouble(TotalRecords) / Convert.ToDouble(this.CurrentPageSize))) : this.lblTotalPages.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void ShowMessageBox_Delegate(string Caption, string Message, MessageBoxButtonType ButtonType, MessageBoxIconType IconType);
        private void ShowMessageBox(string Caption, string Message, MessageBoxButtonType ButtonType, MessageBoxIconType IconType)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new ShowMessageBox_Delegate(ShowMessageBox), new object[] { Caption, Message, ButtonType, IconType });
                }
                else
                {
                    #region Assing Message Box Button

                    MessageBoxButtons messageBoxButton = MessageBoxButtons.AbortRetryIgnore;

                    switch (ButtonType)
                    {
                        case MessageBoxButtonType.AbortRetryIgnore:

                            messageBoxButton = MessageBoxButtons.AbortRetryIgnore;

                            break;

                        case MessageBoxButtonType.Ok:

                            messageBoxButton = MessageBoxButtons.OK;

                            break;

                        case MessageBoxButtonType.OkCancel:

                            messageBoxButton = MessageBoxButtons.OKCancel;

                            break;

                        case MessageBoxButtonType.RetryCancel:

                            messageBoxButton = MessageBoxButtons.RetryCancel;

                            break;

                        case MessageBoxButtonType.YesNo:

                            messageBoxButton = MessageBoxButtons.YesNo;

                            break;

                        case MessageBoxButtonType.YesNoCancel:

                            messageBoxButton = MessageBoxButtons.YesNoCancel;

                            break;
                    }

                    #endregion

                    #region Assign Message Box Icon

                    MessageBoxIcon messageBoxIcon = MessageBoxIcon.Asterisk;

                    switch (IconType)
                    {
                        case MessageBoxIconType.Asterisk:

                            messageBoxIcon = MessageBoxIcon.Asterisk;

                            break;

                        case MessageBoxIconType.Error:

                            messageBoxIcon = MessageBoxIcon.Error;

                            break;

                        case MessageBoxIconType.Exclamation:

                            messageBoxIcon = MessageBoxIcon.Exclamation;

                            break;

                        case MessageBoxIconType.Hand:

                            messageBoxIcon = MessageBoxIcon.Hand;

                            break;

                        case MessageBoxIconType.Information:

                            messageBoxIcon = MessageBoxIcon.Information;

                            break;

                        case MessageBoxIconType.None:

                            messageBoxIcon = MessageBoxIcon.None;

                            break;

                        case MessageBoxIconType.Question:

                            messageBoxIcon = MessageBoxIcon.Question;

                            break;

                        case MessageBoxIconType.Stop:

                            messageBoxIcon = MessageBoxIcon.Stop;

                            break;

                        case MessageBoxIconType.Warning:

                            messageBoxIcon = MessageBoxIcon.Warning;

                            break;
                    }

                    #endregion

                    MessageBox.Show(Message, Caption, messageBoxButton, messageBoxIcon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CanApplyPaging()
        {
            return bwPaging.IsBusy ? false : true;
        }

        #endregion

        #region Background Worker Events

        private void bwPaging_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.ProcessCompleted = false;

                if (!this._ShowProgressBar) ChangeLoadingStatus(_ProgressMessage);

                if (this.Pagingevent != null) Pagingevent();

                int counter = 0;
                while (!this.ProcessCompleted)
                {
                    this.bwPaging.ReportProgress(counter);

                    counter = counter + 5;
                    if (counter > 99) counter = 0;

                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwPaging_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwPaging_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!this._ShowProgressBar) ChangeLoadingStatus(string.Empty);

                this.progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Control Events

        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CanApplyPaging()) return;
                if (this.CurrentPageIndex == 0) return;

                this.CurrentPageIndex = 0;
                ApplyPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviousRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CanApplyPaging()) return;

                this.CurrentPageIndex--;

                if (this.CurrentPageIndex < 0)
                {
                    this.CurrentPageIndex = 0;
                    return;
                }

                ApplyPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CanApplyPaging()) return;

                this.CurrentPageIndex++;

                if (this.CurrentPageIndex > TotalPages - 1)
                {
                    this.CurrentPageIndex = TotalPages - 1;
                    return;
                }

                ApplyPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLastRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CanApplyPaging()) return;

                if (this.CurrentPageIndex == (TotalPages - 1)) return;

                this.CurrentPageIndex = (TotalPages > 0) ? (TotalPages - 1) : 0;
                ApplyPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!CanApplyPaging()) return;

                this.CurrentPageSize = ddlPageSize != null && ddlPageSize.Items.Count > 0 ? Convert.ToInt32(ddlPageSize.SelectedItem) : 0;
                if (!_Initializing) ApplyPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (string.IsNullOrEmpty(txtPageNumber.Text.Trim()))
                    {
                        txtPageNumber.Text = this.CurrentPageNumber.ToString();
                        txtPageNumber.Focus();

                        ShowMessageBox(MessageBoxCaptions.Invalid, MessageBoxMessages.InvalidPageNumber, MessageBoxButtonType.Ok, MessageBoxIconType.Information);

                        return;
                    }

                    if (!string.IsNullOrEmpty(txtPageNumber.Text.Trim()) && Convert.ToInt32(txtPageNumber.Text.Trim()) < 1)
                    {
                        txtPageNumber.Text = this.CurrentPageNumber.ToString();
                        txtPageNumber.Focus();

                        ShowMessageBox(MessageBoxCaptions.Invalid, MessageBoxMessages.InvalidPageNumber, MessageBoxButtonType.Ok, MessageBoxIconType.Information);

                        return;
                    }

                    if (!string.IsNullOrEmpty(txtPageNumber.Text.Trim()) && Convert.ToInt32(txtPageNumber.Text.Trim()) > TotalPages)
                    {
                        txtPageNumber.Text = this.CurrentPageNumber.ToString();
                        txtPageNumber.Focus();

                        ShowMessageBox(MessageBoxCaptions.Invalid, MessageBoxMessages.InvalidPageNumber, MessageBoxButtonType.Ok, MessageBoxIconType.Information);

                        return;
                    }

                    if (!CanApplyPaging()) return;

                    this.CurrentPageIndex = Convert.ToInt32(txtPageNumber.Text.Trim()) - 1;
                    if (!_Initializing) ApplyPaging();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

    internal class MessageBoxMessages
    {
        public const string InvalidPageNumber = "Please, enter valid page number";
    }

    internal class MessageBoxCaptions
    {
        public const string Invalid = "Invalid";
    }

    internal enum MessageBoxButtonType
    {
        AbortRetryIgnore = 0,
        Ok = 1,
        OkCancel = 2,
        RetryCancel = 3,
        YesNo = 4,
        YesNoCancel = 5
    }

    internal enum MessageBoxIconType
    {
        Asterisk = 0,
        Error = 1,
        Exclamation = 2,
        Hand = 3,
        Information = 4,
        None = 5,
        Question = 6,
        Stop = 7,
        Warning = 8
    }
}
