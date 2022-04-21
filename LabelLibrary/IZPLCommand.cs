using System;
namespace LabelLibrary
{
    public interface IZPLCommand
    {
        // ^XA
        public string StartFormat { get; set; }

        // ^XZ 
        public string EndFormat { get; set; }

        // ^FO
        public string FieldOrigin { get; set; }

        // ^FS
        public string FieldSeparator { get; set; }

        // ^FD (data)
        public string FieldData { get; set; }

        // ^BC (orientation, height, line, lineAbove, checkDigit, mode)
        public string Code128Barcode { get; set; }

        // ^SN (start, increment, pad)
        public string SerializedData { get; set; }

        // ^CF (fontName, height, width)
        public string ChangeDefaultFont { get; set; }

        // ^FX (comments)
        public string Comment { get; set; }

        // ^BY (width, widthRatio, height)
        public string BarcodeFieldDefaults { get; set; }

        // ^GB (width, height, thickness, color, rounding)
        public string GraphicBox { get; set; }

    }
}
