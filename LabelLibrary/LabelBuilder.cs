using System;
using System.Text;
using LabelLibrary.Enum;
using LabelLibrary.Models;

namespace LabelLibrary
{
    public class LabelBuilder
    {
        private ZPLCommand _zpl { get; set; } = new();

        public string BuildLabelMop(LabelMop labelMop, int? qtdToPrint)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append($"{_zpl.StartFormat}");
            stringBuilder.Append($"{_zpl.ChangeDefaultFont}B0,{((int)FontSize.Title).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,20{_zpl.FieldData}{labelMop.CompanyName}{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}0,{((int)FontSize.Subtitle).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,60{_zpl.FieldData}DEPARTMENT{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}A0,{((int)FontSize.Data).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,80{_zpl.FieldData}{labelMop.DepartmentId}{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}0,{((int)FontSize.Subtitle).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,120{_zpl.FieldData}LOCATION{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}A0,{((int)FontSize.Data).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,140{_zpl.FieldData}{labelMop.Location}{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}0,{((int)FontSize.Subtitle).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,180{_zpl.FieldData}PICK UP TIME{_zpl.FieldSeparator}");
            stringBuilder.Append($"{_zpl.FieldOrigin}250,180{_zpl.FieldData}RETURN TIME{_zpl.FieldSeparator}");
            stringBuilder.Append($"{_zpl.FieldOrigin}510,180{_zpl.FieldData}QTD{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.ChangeDefaultFont}A0,{((int)FontSize.Data).ToString()}");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,200{_zpl.FieldData}{labelMop.TimeOut.ToString("HH:mm")}{_zpl.FieldSeparator}");
            stringBuilder.Append($"{_zpl.FieldOrigin}250,200{_zpl.FieldData}{labelMop.TimeIn.ToString("HH:mm")}{_zpl.FieldSeparator}");
            stringBuilder.Append($"{_zpl.FieldOrigin}510,200{_zpl.FieldData}{labelMop.Quantity}{_zpl.FieldSeparator}");

            // Square draw with quantity
            stringBuilder.Append($"{_zpl.FieldOrigin}475,150{_zpl.GraphicBox}100,100,3{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.BarcodeFieldDefaults}2,1,110");
            stringBuilder.Append($"{_zpl.FieldOrigin}20,260{_zpl.Code128Barcode}{labelMop.Barcode}{_zpl.FieldData}{labelMop.Barcode}{_zpl.FieldSeparator}");

            stringBuilder.Append($"{_zpl.EndFormat}");

            return stringBuilder.ToString();

        }

        private string BuildHeadersString(string origin, string separator)
        {

            var stringLine = "";

            return stringLine;
        }

        private string BuildContentString(string origin, string separator)
        {

            var stringLine = "";

            return stringLine;
        }

        private string BuildBarcodeString(string origin, string separator)
        {

            var stringLine = "";

            return stringLine;
        }

    }
}
