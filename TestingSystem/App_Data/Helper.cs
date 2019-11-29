using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems
{
    public class Helper
    {
        public class MainGroupBoxProperties
        {
            public static System.Drawing.Font Font = new System.Drawing.Font("Georgia", 10.25F);
            public static System.Drawing.Point Location = new System.Drawing.Point(22, 12);
            public static System.Drawing.Size Size = new System.Drawing.Size(1000, 730);
            public const bool TabStop = false;
        }

        public class SubGroupBoxProperties
        {
            public static System.Drawing.Font Font = new System.Drawing.Font("Georgia", 10.25F);
            public const bool TabStop = false;
        }

        public class TabControlProperties
        {
            public static System.Drawing.Font Font = new System.Drawing.Font("Georgia", 10.25F);
            public const bool TabStop = false;
        }

        public class ButtonCaptions
        {
            public const string Save = "Save";
            public const string Update = "Update";
            public const string Add = "Add";
            public const string Cancel = "Cancel";
            public const string Clear = "Clear";
            public const string View = "Register";
            public const string Close = "Close";

        }

        public class DropdownDefaultText
        {
            public const string Select = "--SELECT--";
        }

        public class MessageBoxMessages
        {
            public const string InvalidPageNumber = "Please enter valid page number";
            public const string Saveconfirm = "Are you sure you want to save?";
            public const string SaveDone = "Data saved successfully";
            public const string Updateconfirm = "Are you sure you want to update?";
            public const string UpdateDone = "Data updated successfully";
            public const string entryerror = "The application has encountered an unknown error.";
            public const string Mandatory = "Required field missing!";
            public const string Mandatory_Reason = "Reason is mandatory!";
            public const string ClearConfirm = "Are you sure you want to clear?";
            public const string SaveError = "Data not saved";
            public const string DeleteError = "Data not deleted";
            public const string Deletedone = "Data deleted successfully";
            public const string DeleteConfirm = "Are you sure you want to delete?";
            public const string UnblockedError = "Data not unblocked";
            public const string Unblockeddone = "Data unblocked successfully";
            public const string MultipleServerFound = "Multiple servers found in a network";
            public const string BlockError = "Data not blocked";
            public const string Blockdone = "Data blocked successfully";
            public const string BlockConfirm = "Are you sure you want to block?";
            public const string ActivekError = "Data not active";
            public const string Activedone = "Data active successfully";
            public const string ActiveConfirm = "Are you sure you want to active?";
            public const string InActivekError = "Data not Inactive";
            public const string InActivedone = "Data Inactive successfully";
            public const string InActiveConfirm = "Are you sure you want to Inactive?";
            public const string JobReturnCheckMessageEdit = "Job return has been taken agains this jobwork no. It can't be edited.";
            public const string JobReturnCheckMessageDelete = "Job return has been taken agains this jobwork no. It can't be deleted";
            public const string DuplicateJONo = "Same jobout no. is already exists";
            public const string DuplicateJRNo = "Same jobreturn no. is already exists";
            private const string AlreadyExistMessage = "#Name# already exist";
            public const string ExportNotEnoughData = "No data available to export";
            public const string BackEntryEdit = "Back Entry can not be edited.";
            public const string BackEntryDelete = "Back Entry can not be deleted.";
            public const string BackEntryShortclose = "Back Entry can not be Shortclose.";
            public const string RefreshConfirm = "Are you sure you want to Refresh the Form?";
            public const string MatchplateinMold = "Matchplate is already entered. One mold can not have 2 different match plate.";
            public const string InvoiceMessage = "One of your GRNDate is greater than Invoice date. So please correct the date.";
            public const string ReminderDateMessage = "Reminder date cannot be less than current date";
            public const string ReminderTimeMessage = "Reminder time cannot be less than current time";
            public const string ChartSave = "Chart save successfilly.";
            public const string SequenceChangeMessage = "This is system generated process. Sequence cannot be change.";
            public const string CastingSelectionMessage = "Select casting name to fetch it's routecard processes.";
            public const string AssemblyInMold = "One assmeble mold can not have 2 different pattern";
            public const string CastingPatternMapping = "Casting is not associated with this pattern so sand consumption can not be calculated. Please map casting with this pattern.";
            public static String AlreadyExist(String Message)
            {
                return AlreadyExistMessage.Replace("#Name#", Message);
            }

        }

        public class MessageBoxCaptions
        {
            public const string Invalid = "Invalid";
            public const string Header = "iCast";
        }

        public class LinkButtonCaptions
        {
            public const string UnBlock = "UNBLOCK";
            public const string Block = "BLOCK";
            public const string DELETE = "DELETE";
            public const string EDIT = "EDIT";
            public const string ADD = "ADD";

            public const string All = "All";
            public const string Active = "Active";
            public const string InActive = "InActive";
           
        }
    }
}
