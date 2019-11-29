using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems.App_Data
{
    class AutoFitForm
    {
        public static void SetGroupBoxLoction(GroupBox groupBox)
        {
            try
            {
                Screen currentScreen = Screen.PrimaryScreen;

                Int32 newX = ((currentScreen.WorkingArea.Width / 2) - (groupBox.Width / 2));
                // Int32 newY = ((currentScreen.WorkingArea.Height / 2) - (groupBox.Height / 2));
                //Int32 newX = 50;

                Int32 newY = groupBox.Location.Y;

                groupBox.Location = new Point(newX, newY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SetFormToMaximize(Form currentForm)
        {
            currentForm.WindowState = FormWindowState.Maximized;
        }
    }
}
