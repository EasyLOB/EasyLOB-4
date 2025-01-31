using Syncfusion.XlsIO;
using System;

namespace EasyLOB
{
    public static class SyncfusionExcelExtensions
    {
        public static void AutoAlign(this IWorksheet worksheet, int startColumn, int columns)
        {
            //for (int column = startColumn; column <= startColumn + columns - 1; column++)
            //{
            //    worksheet.AutofitColumn(column);
            //}
        }

        public static void ClearDateTime(this IRange range, DateTime? value)
        {
            if (value == new DateTime(1, 1, 1))
            {
                range.Clear();
            }
            else
            {
                range.Value2 = value;
            }
        }

        public static double GetDouble(this IRange range)
        {
            double result = range.Number;

            return double.IsNaN(result) ? 0 : result;
        }

        public static string GetString(this IRange range)
        {
            string result = range.Value;

            return string.IsNullOrEmpty(result) ? result : result.Trim();
        }
    }
}