using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestingSystems
{
    public static class ValidationHelper
    {
        //public enum ControlTypes
        //{
        //    TextBox,
        //    ComboBox
        //}

        public static class ValidationMessages
        {
            public const String EmptyValidationMessage = "";

            public const String RequiredFieldMessage = "This field is required";

            public const String CharactersOnlyMessage = "Only characters are allowed";

            public const String NumbersOnlyMessage = "Only numbers are allowed";

            public const String EmailValidationMessage = "Provide valid E-mail";

            public const String FilterMessage = "Select and than press Enter";
        }

        private static class RegulerExpressions
        {
            public const String StringOnly = "^[a-zA-Z]*$";

            public const String Alphanumeric = "^[a-zA-Z0-9]*$";

            public const String NumbersOnly = "^[0-9]*$";

            public const String Email = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        }

        #region Required Field
        public static void RequiredFieldValidation(TextBox textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (String.IsNullOrEmpty(textBox.Text.Trim())) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.RequiredFieldMessage);
                textBox.Focus();
                
            }
        }
        public static void RequiredFieldValidation(NumericUpDown textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (String.IsNullOrEmpty(textBox.Value.ToString().Trim()) ) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.RequiredFieldMessage);
                textBox.Focus();

            }
        }
        public static void RequiredFieldValidationGreaterThanZero(NumericUpDown textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (String.IsNullOrEmpty(textBox.Value.ToString().Trim()) || textBox.Value<=0) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.RequiredFieldMessage);
                textBox.Focus();

            }
        }
        public static void RequiredFieldValidation(ComboBox comboBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (String.IsNullOrEmpty(comboBox.Text.Trim()))
            {
                result = false;
            }
            else if (comboBox.Text.Trim().Equals(Constants.DropDownDefaultItems.Select))
            {
                result = false;
            }

            if (result)
            {
                errorProvider.SetError(comboBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(comboBox, ValidationMessages.RequiredFieldMessage);
                comboBox.Focus();
               
            }
        }
        #endregion

        public static void CharacterOnlyValidation(TextBox textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (IsEmptyTextBox(textBox, errorProvider)) return;

            Regex regex = new Regex(RegulerExpressions.StringOnly);

            if (!regex.IsMatch(textBox.Text.Trim())) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.CharactersOnlyMessage);
                textBox.Focus();
            }
        }

        public static void NumbersOnlyValidation(TextBox textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (IsEmptyTextBox(textBox, errorProvider)) return;

            Regex regex = new Regex(RegulerExpressions.NumbersOnly);

            if (!regex.IsMatch(textBox.Text.Trim())) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.NumbersOnlyMessage);
                textBox.Focus();
            }
        }

        public static void EmailValidation(TextBox textBox, ErrorProvider errorProvider)
        {
            bool result = true;

            if (IsEmptyTextBox(textBox, errorProvider)) return;

            Regex regex = new Regex(RegulerExpressions.Email);

            if (!regex.IsMatch(textBox.Text.Trim())) result = false;

            if (result)
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
            }
            else
            {
                errorProvider.SetError(textBox, ValidationMessages.EmailValidationMessage);
                textBox.Focus();
            }
        }

        private static bool IsEmptyTextBox(TextBox textBox, ErrorProvider errorProvider)
        {
            bool result = false;

            if (String.IsNullOrEmpty(textBox.Text.Trim()))
            {
                errorProvider.SetError(textBox, ValidationMessages.EmptyValidationMessage);
                result = true;
            }

            return result;
        }

        #region Old Code
        //public static bool RequiredFieldValidation(String stringToValidate, ControlTypes currentControlType)
        //{
        //    bool result = true;

        //    switch (currentControlType)
        //    {
        //        case ControlTypes.TextBox:

        //            if (String.IsNullOrEmpty(stringToValidate)) result = false;

        //            break;

        //        case ControlTypes.ComboBox:

        //            if (String.IsNullOrEmpty(stringToValidate))
        //            {
        //                result = false;
        //            }
        //            else if (stringToValidate.Equals(Constants.DropDownDefaultItems.Select))
        //            {
        //                result = false;
        //            }

        //            break;
        //    }

        //    return result;
        //}
        #endregion
    }
}
