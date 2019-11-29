using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems
{
    public static class Constants
    {
        public static class Messages
        {
            public const String RecordSaved = "Record(s) Saved";
            public const String RecordUpdated = "Record(s) Updated";
            public const String RecordDeleted = "Record(s) Deleted";

            public const String RecordSavedError = "Error! Can not save record(s)";
            public const String RecordUpdatedError = "Error! Can not update record(s)";
            public const String RecordDeletedError = "Error! Can not delete record(s)";

            public const String DatabaseError = "Database Error Occurred";
        }

        public static class MessageBoxContent
        {
            public const String Caption = "iCast-Mini";

            public const String DoYouWantToSave = "Do you want to save?";

            public const String DoYouWantToDelete = "Do you want to delete?";

            public const String DoYouWantToCancel = "Do you want to cancel?";
        }

        public static class PartyType
        {
            public const String Customer = "C";

            public const String Supplier = "S";
        }

        public static class DropDownDefaultItems
        {
            public const String Select = "--SELECT--";

            public const String New = "New";
        }

        public const String XMLRootName = "DocumentElement";

        public static string UserAssignId = "";
    }
}
