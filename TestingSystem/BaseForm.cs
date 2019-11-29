using TestingSystems.BusyIndicator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystems
{
    public partial class BaseForm : Form
    {
        #region Private members

        private const int _SRCCOPY = 0x00CC0020;

        private BusyIndicatorPanel _BusyIndicatorPanel;

        private bool _IsBusy;

        #endregion

        #region Constructors

        public BaseForm()
        {
            InitializeBusyIndicator();
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnLoad();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            OnShown();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateBusyIndicatorOnSizeChanged();
            base.OnSizeChanged(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                Save();
                return true;
            }
            else if (Convert.ToString(keyData) == clsValues.Instance.ShortcutKey)
            {
                OpenRegister();
                return true;
            }
            else if (keyData == (Keys.F5))
            {
                RefreshForm();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Do process using busy indicator
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="workAction">Work action</param>
        /// <param name="workCompletedAction">Work completed action</param>
        public void UsingBusyIndicator(string caption, Action workAction, Action workCompletedAction = null)
        {
            this.SetCaption(caption);
            UsingBusyIndicator(workAction, workCompletedAction);
        }

        /// <summary>
        /// Do process using busy indicator
        /// </summary>
        /// <param name="workAction">Work action</param>
        /// <param name="workCompletedAction">Work completed action</param>
        public void UsingBusyIndicator(Action workAction, Action workCompletedAction = null)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        this.ShowBusyIndicator();
                        workAction();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.LogException(ex);
                    }

                }).ContinueWith(task =>
                {
                    if (workCompletedAction != null)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            workCompletedAction();
                        }));
                    }
                }).ContinueWith(task =>
                {
                    this.HideBusyIndicator();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
        }

        public virtual void OnLoad()
        {
        }

        public virtual void OnShown()
        {

        }

        public virtual void RefreshForm()
        {
        }

        public virtual void Save()
        {
        }

        public virtual void OpenRegister()
        {
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initialize busy indicator
        /// </summary>
        private void InitializeBusyIndicator()
        {
            _BusyIndicatorPanel = new BusyIndicatorPanel()
            {
                Opacity = 15,
                Color = System.Drawing.Color.Orange
            };
        }

        /// <summary>
        /// Set caption
        /// </summary>
        /// <param name="caption"></param>
        private void SetCaption(string caption)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (_BusyIndicatorPanel != null)
                    _BusyIndicatorPanel.SetCaption(caption);
            }));
        }

        /// <summary>
        /// Show busy indicator
        /// </summary>
        private void ShowBusyIndicator()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (_BusyIndicatorPanel != null)
                {
                    this.UseWaitCursor = true;
                    this.Controls.Add(_BusyIndicatorPanel);

                    _BusyIndicatorPanel.SetBackgroundImage(CaptureSnapShot());
                    _BusyIndicatorPanel.Visible = true;
                    _BusyIndicatorPanel.BringToFront();

                    _IsBusy = true;
                }
            }));
        }

        /// <summary>
        /// Hide busy indicator
        /// </summary>
        private void HideBusyIndicator()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (_BusyIndicatorPanel != null)
                {
                    _BusyIndicatorPanel.Visible = false;
                    _BusyIndicatorPanel.DisposeBackgroundImage();
                    _BusyIndicatorPanel.SendToBack();

                    this.UseWaitCursor = false;
                    this.Controls.Remove(_BusyIndicatorPanel);

                    _IsBusy = false;
                }
            }));
        }

        /// <summary>
        /// Update busy indicator on size changed
        /// </summary>
        private void UpdateBusyIndicatorOnSizeChanged()
        {
            if (!_IsBusy)
                return;

            HideBusyIndicator();
            this.Refresh();
            ShowBusyIndicator();
        }

        /// <summary>
        /// Capture snap shot of form
        /// </summary>
        /// <returns></returns>
        private Bitmap CaptureSnapShot()
        {
            if (!base.IsHandleCreated)
                return null;

            if (this.ClientRectangle.IsEmpty)
                return null;

            if (this.ClientRectangle.Height == 0 ||
                this.ClientRectangle.Width == 0)
                return null;

            var dc = GetDC(this.Handle);
            var bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                // Copy image of form into bitmap
                var bmpDc = graphics.GetHdc();

                BitBlt(bmpDc, 0, 0, bitmap.Width, bitmap.Height, dc, 0, 0, _SRCCOPY);

                // Release resources
                ReleaseDC(this.Handle, dc);
                graphics.ReleaseHdc(bmpDc);

                // Apply transperancy
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(_BusyIndicatorPanel.Opacity * 255 / 100, _BusyIndicatorPanel.Color)), 0, 0, bitmap.Width, bitmap.Height);
            }

            return bitmap;
        }

        #endregion

        #region Extern methods

        [DllImport("user32.dll")]
        private extern static IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt
        (
            // Handle to destination DC 
            IntPtr hDcDest,

            // X-coord of destination upper-left corner 
            int xDest,

            // Y-coord of destination upper-left corner 
            int yDest,

            // Width of destination rectangle 
            int width,

            // Height of destination rectangle 
            int height,

            // Handle to source DC 
            IntPtr dcSrc,

            // X-coordinate of source upper-left corner 
            int xSrc,

            // Y-coordinate of source upper-left corner 
            int ySrc,

            // Raster operation code 
            Int32 dwRop
        );

        #endregion
    }
}
