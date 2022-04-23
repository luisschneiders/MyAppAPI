using System;
namespace LabelLibrary
{
    public class ZPLCommand : IZPLCommand
    {

        public string StartFormat { get; set; }
        public string EndFormat { get; set; }
        public string FieldOrigin { get; set; }
        public string FieldSeparator { get; set; }
        public string FieldData { get; set; }
        public string Code128Barcode { get; set; }
        public string SerializedData { get; set; }
        public string ChangeDefaultFont { get; set; }
        public string Comment { get; set; }
        public string BarcodeFieldDefaults { get; set; }
        public string GraphicBox { get; set; }

        public ZPLCommand()
        {
            StartFormat = "^XA";
            FieldOrigin = "^FO";
            FieldSeparator = "^FS";
            FieldData = "^FD";
            Code128Barcode = "^BC";
            SerializedData = "^SN";
            ChangeDefaultFont = "^CF";
            Comment = "^FX";
            BarcodeFieldDefaults = "^BY";
            GraphicBox = "^GB";
            EndFormat = "^XZ";
        }

    }
}
