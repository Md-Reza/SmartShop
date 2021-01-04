using DevExpress.Export;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using System;
using System.IO;

namespace SmartShop.Repository
{
   public class FileControl
    {
        public static void ExportGrid(GridView gridView, string filePath)
        {
            XlsxExportOptionsEx xlsxExportOptions = new XlsxExportOptionsEx();
            xlsxExportOptions.ExportType = ExportType.WYSIWYG;
            xlsxExportOptions.ExportMode = XlsxExportMode.SingleFile;
            gridView.ExportToXlsx(filePath + ".xlsx", xlsxExportOptions);
        }
        public static void RestoreGridLayout(GridView gridView, string layoutName = null)
        {
            if (layoutName == null)
                return;
            string layoutPath = Path.Combine(LocalStorage(), layoutName);
            if (File.Exists(layoutPath))
                gridView.RestoreLayoutFromXml(layoutPath);
        }
        public static string LocalStorage()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dir, "LocalStorage");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public static string SaveGridLayout(GridView gridView)
        {
            var guid = Guid.NewGuid();
            string fileName = Path.Combine(LocalStorage(), guid.ToString());
            gridView.SaveLayoutToXml(fileName);
            return guid.ToString();
        }

    }
}
