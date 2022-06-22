
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmacy
{
    public class BackUp
    {
        
        public void Backup(string path)
        {
            ExportDataSetToExcel(getAllTables(), path);
        }
        private DataSet getAllTables()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
               
                SqlDataAdapter da = new SqlDataAdapter("SP_backup", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        private void ExportDataSetToExcel(DataSet dataset, string excelFilePath)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(excelFilePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                foreach (DataTable table in dataset.Tables)
                {
                    UInt32Value sheetCount = 0;
                    sheetCount++;

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);

                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = sheetCount, Name = table.TableName };
                    sheets.AppendChild(sheet);

                    Row headerRow = new Row();

                    List<string> columns = new List<string>();
                    foreach (System.Data.DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        Row newRow = new Row();
                        foreach (String col in columns)
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(dsrow[col].ToString());
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }



                }
                workbookPart.Workbook.Save();
                MessageBox.Show("Successfully Backed Up");

            }
        }
    }
}
