using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Utils
{
    public static class ExcelUtility
    {
        public static void ExportExcelFile(DataTable dtTable, string fileName)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtTable,"OTS");
                wb.SaveAs(fileName);
            }
        }
    }
}
