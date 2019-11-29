using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems.BusyIndicator
{
    public class BusyIndicatorPanel : Panel
    {
        #region Private members

        private int _Opacity = 50;

        private Color _Color = SystemColors.Control;

        private Bitmap _BackgroundImage;

        private BusyIndicatorContentPanel _BusyIndicatorContentPanel;

        #endregion

        #region Public properties

        /// <summary>
        /// Opacity
        /// </summary>
        public int Opacity
        {
            get
            {
                return _Opacity;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    _Opacity = value;
            }
        }

        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }

        #endregion

        #region Constructors

        public BusyIndicatorPanel()
            : base()
        {
            this.Visible = false;
            this.Dock = DockStyle.Fill;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint,
                          true);

            InitializeBusyIndicatorContentPanel();
        }

        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (_BackgroundImage == null)
            {
                using (var brush = new SolidBrush(Color.FromArgb(this.Opacity * 255 / 100, this.Color)))
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            else
                e.Graphics.DrawImageUnscaled(_BackgroundImage, 0, 0, _BackgroundImage.Width, _BackgroundImage.Height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            RelocateBusyIndicatorContentPanel();
            base.OnSizeChanged(e);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Set caption
        /// </summary>
        /// <param name="caption">Caption</param>
        public void SetCaption(string caption)
        {
            if (_BusyIndicatorContentPanel != null)
            {
                _BusyIndicatorContentPanel.SetCaption(caption);
                _BusyIndicatorContentPanel.Refresh();
            }
        }

        /// <summary>
        /// Set background image
        /// </summary>
        /// <param name="backgroundImage">Background image</param>
        public void SetBackgroundImage(Bitmap backgroundImage)
        {
            _BackgroundImage = backgroundImage;
        }

        /// <summary>
        /// Dispose background image
        /// </summary>
        public void DisposeBackgroundImage()
        {
            if (_BackgroundImage == null)
                return;

            _BackgroundImage.Dispose();
            _BackgroundImage = null;
        }

        #endregion

        #region Private methods

        private void InitializeBusyIndicatorContentPanel()
        {
            _BusyIndicatorContentPanel = new BusyIndicatorContentPanel();
            this.Controls.Add(_BusyIndicatorContentPanel);
        }

        /// <summary>
        /// Relocate busy indicator content panel
        /// </summary>
        private void RelocateBusyIndicatorContentPanel()
        {
            if (_BusyIndicatorContentPanel == null)
                return;

            var x = (this.Width / 2) - (_BusyIndicatorContentPanel.Width / 2);
            var y = this.Height / 2 - (_BusyIndicatorContentPanel.Height / 2);

            _BusyIndicatorContentPanel.Location = new Point(x, y);
        }

        #endregion        
    }
}
