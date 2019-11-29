using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace TestingSystems.BusyIndicator
{
    public partial class BusyIndicatorContentPanel : UserControl
    {
        #region Private members

        private const int _CornerRadius = 10;

        private Color _Color = Color.Transparent;

        private const string _Caption = ""; // "Please Wait";

        #endregion

        #region Constructors

        public BusyIndicatorContentPanel()
        {
            InitializeComponent();
            ApplyRoundCorners();

            this.BackColor = _Color;
            this.lblCaption.Text = _Caption;
        }

        #endregion        

        #region Public methods

        public void SetCaption(string caption)
        {
            this.lblCaption.Text = caption;
            this.lblCaption.Refresh();
        }

        #endregion

        #region Private methods        

        private void ApplyRoundCorners()
        {
            this.BorderStyle = BorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, _CornerRadius, _CornerRadius));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            // x-coordinate of upper-left corner
            int leftRect,

            // y-coordinate of upper-left corner
            int topRect,

            // x-coordinate of lower-right corner
            int rightRect,

            // y-coordinate of lower-right corner
            int bottomRect,

            // height of ellipse
            int ellipseWidth,

            // width of ellipse
            int ellipseHeight
         );

        #endregion
    }
}
