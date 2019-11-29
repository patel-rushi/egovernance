using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems
{
    public class Enums
    {
        public enum FormMode
        {
            Insert=0,
            Edit=1
        }

        public enum XmlInputType
        {
            XmlString,
            XmlFile
        }

        public enum SerializatioDeSerializationMethod
        {
            Normal,
            Encrypted
        }

        public enum SeriesType
        {
            jobwork=0,
            Invoice=1,
            PO=2,
            Inward =3,
            OA =4,
            GatePass=5,
            Issue=6,
            MaterialInspection = 7,
            Inquiry = 8,
            Quotation = 9
        }
    }
}
