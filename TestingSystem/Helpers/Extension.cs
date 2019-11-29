using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TestingSystems.Helpers
{
    internal static class Extensions
    {
        internal static void IntegerRound(this TextBox txtNumericTextBox)
        {
            Double Value;
            txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f0") : "");
        }
        internal static void TwoDecimalPlaceRound(this TextBox txtNumericTextBox)
        {
            Double Value;
            txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f2") : "");
        }
        internal static void ThreeDecimalPlaceRound(this TextBox txtNumericTextBox)
        {
            Double Value;
            txtNumericTextBox.Text = (Double.TryParse(txtNumericTextBox.Text, out Value) ? Value.ToString("f3") : "");
        }
        internal static void AllowIntegerOnly(this KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        internal static void AllowFloatOnly(this KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        internal static void SetCustomDateFormat(this DateTimePicker dtp)
        {
            dtp.CustomFormat = "dd MMM yyyy";
        }
        internal static void SetCustomTimeFormat(this DateTimePicker dtp)
        {
            dtp.CustomFormat = "hh:mm:ss tt";
        }

        internal static bool SetEmptyDateFormat(this DateTimePicker dtp, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtp.CustomFormat = "''";
                return true;
            }
            else
                return false;
        }

        internal static void EntryNoAddPadding(this TextBox txtTextBox, Int32 PaddingLength, char PaddingChar)
        {
            if (txtTextBox.TextLength > PaddingLength)
            {
                MessageBox.Show("Please Enter No of " + PaddingLength + " Chars", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTextBox.Clear();
                return;
            }

            txtTextBox.Text = txtTextBox.Text.PadLeft(PaddingLength, PaddingChar);
        }

        public static void AddSelectRow(this DataTable currentDataTable)
        {
            if (currentDataTable != null && currentDataTable.Rows.Count > 0)
            {
                DataRow newRow = currentDataTable.NewRow();

                if (currentDataTable.Columns.Count < 1)
                {
                    newRow[0] = Constants.DropDownDefaultItems.Select;

                    currentDataTable.Rows.InsertAt(newRow, 0);
                }
                else if (currentDataTable.Columns.Count > 1)
                {
                    if (currentDataTable.Columns[0].DataType == typeof(int))
                    {
                        newRow[0] = 0;
                    }
                    else if (currentDataTable.Columns[0].DataType == typeof(Int64))
                    {
                        newRow[0] = 0;
                    }
                    else if (currentDataTable.Columns[0].DataType == typeof(Guid))
                    {
                        newRow[0] = Guid.Empty;
                    }
                    else
                    {
                        newRow[0] = "0";
                    }
                    newRow[1] = "--SELECT--";

                    currentDataTable.Rows.InsertAt(newRow, 0);
                }
            }
        }

        public static void AddSelectRow(this DataTable currentDataTable, int valueFieldIndex, int displayFieldIndex)
        {
            if (currentDataTable != null && currentDataTable.Rows.Count > 0)
            {
                DataRow newRow = currentDataTable.NewRow();

                if (currentDataTable.Columns[valueFieldIndex].DataType == typeof(int))
                {
                    newRow[valueFieldIndex] = 0;
                }
                else if (currentDataTable.Columns[valueFieldIndex].DataType == typeof(Guid))
                {
                    newRow[valueFieldIndex] = Guid.Empty;
                }
                else if (currentDataTable.Columns[valueFieldIndex].DataType == typeof(double))
                {
                    newRow[valueFieldIndex] = 0;
                }
                else
                {
                    newRow[valueFieldIndex] = "0";
                }

                newRow[displayFieldIndex] = Constants.DropDownDefaultItems.Select;
                // newRow[displayFieldIndex] = "--SELECT--";
                currentDataTable.Rows.InsertAt(newRow, 0);
            }
        }

        public static void AddSelectRowName(this DataTable currentDataTable, int valueFieldIndex, int displayFieldIndex)
        {
            if (currentDataTable != null && currentDataTable.Rows.Count > 0)
            {
                DataRow newRow = currentDataTable.NewRow();

                if (currentDataTable.Columns[valueFieldIndex].DataType == typeof(string))
                {
                    newRow[valueFieldIndex] = 0;
                }
                else if (currentDataTable.Columns[valueFieldIndex].DataType == typeof(string))
                {
                    newRow[valueFieldIndex] = string.Empty;
                }
                else
                {
                    newRow[valueFieldIndex] = "0";
                }

                newRow[displayFieldIndex] = Constants.DropDownDefaultItems.Select;

                currentDataTable.Rows.InsertAt(newRow, 0);
            }
        }

        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The IEnumerable type</typeparam>
        /// <param name="enumerable">The enumerable, which may be null or empty.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// Determines whether the data table is null or contains no rows.
        /// </summary>
        /// <param name="dataTable">Target data table</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this System.Data.DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return true;

            return false;
        }
        /// <summary>
        /// Determine whether combobox is null or empty then assign defult text select.
        /// </summary>
        /// <param name="cmb"></param>
        public static void cmbSelectionChangeCommitted(this ComboBox cmb)
        {
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null && cmb.SelectedValue.ToString() != String.Empty && cmb.SelectedValue.ToString() != Helper.DropdownDefaultText.Select)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }

        /// <summary>
        /// Read value from data row
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="dataRow">Data row</param>
        /// <param name="fieldName">Field name</param>
        /// <returns></returns>
        public static T Read<T>(this DataRow dataRow, string fieldName)
        {
            if (dataRow == null)
                return default(T);

            if (string.IsNullOrEmpty(fieldName))
                return default(T);

            try
            {
                if (dataRow.IsNull(fieldName))
                    return default(T);

                var fieldValue = dataRow[fieldName];
                if (fieldValue is T)
                    return (T)fieldValue;

                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), fieldValue.ToString(), true);

                return (T)Convert.ChangeType(fieldValue, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
