using ClosedXML.Excel;
using System.Data;

namespace OTS.Ticketing.Win.Utils
{
    public static class ExcelUtility
    {
        public static void ExportExcelFile(DataTable dtTable, string fileName)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtTable, "OTS");
                wb.SaveAs(fileName);
            }
        }
    }
}
