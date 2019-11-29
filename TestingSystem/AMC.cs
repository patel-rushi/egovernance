using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems.Helpers;

namespace TestingSystems
{
    public partial class AMC : UserControl
    {
        ClientOrder C1;
         
        //public AMC(ClientOrder c)
        public AMC()
        {
            InitializeComponent();

            ClientOrder.uc_textbox_location1 = textBox1.Location.X;
            ClientOrder.uc_textbox_location2 = textBox2.Location.X;
            ClientOrder.uc_textbox_loaction3 = textBox3.Location.X;
            //C1 = c;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textBox2.Focus();
                if ((textBox2.Text != String.Empty) && (!textBox2.Text.Contains("-")))
                    ClientOrder.AmcNextValue = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //TextBox_TextChangeEvent();

        }

        private void TextBox_TextChangeEvent()
        {
           //C1.ADD_AmcControl();
            try
            {
                if ((textBox2.Text.Contains("-") != true))
                {
                    if (Convert.ToInt32(textBox2.Text.ToString()) <= Convert.ToInt32(textBox1.Text.ToString()))
                    {
                        textBox2.Text = "-";
                        textBox2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message
                    +ex.StackTrace);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.AllowIntegerOnly();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar.ToString() == "-") 
                {
                    textBox2.Focus();
                    textBox2.Text = "";
                }
                else if ((e.KeyChar.ToString() != "-") && (textBox2.Text.Contains("-") == true))
                {
                    textBox2.Text = "";
                    if (char.IsDigit(e.KeyChar) == true|| char.IsControl(e.KeyChar) == true)
                    {
                        //if (Convert.ToInt32(e.KeyChar.ToString()) <= Convert.ToInt32(textBox1.Text.ToString()))
                        //{
                        //    e.Handled = true;
                        //}
                        //else
                        //{
                        //    e.Handled = false;
                        //}
                    }
                    else e.Handled = true;
                  
                }
                if ((e.KeyChar.ToString() != "-") && (textBox2.Text.Contains("-") != true))
                {
                    if (char.IsDigit(e.KeyChar) == true|| char.IsControl(e.KeyChar) == true)
                    {
                        //if (Convert.ToInt32(e.KeyChar.ToString()) <= Convert.ToInt32(textBox1.Text.ToString()))
                        //{
                        //    e.Handled = true;
                        //}
                        //else
                        //{
                        //    e.Handled = false;
                        //}
                    }
                    else e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.AllowFloatOnly();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if ((textBox2.Text != String.Empty))
            {
                TextBox_TextChangeEvent();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (textBox3.Text != ""))
            {
                TextBox_TextChangeEvent();
            }
        }

    }
}
