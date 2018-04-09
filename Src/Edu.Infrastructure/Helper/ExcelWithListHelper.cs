using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Edu.Infrastructure.Attrs;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Edu.Infrastructure.Helper
{
    public class ExcelWithListHelper
    {
        public static async Task<List<T>> HandlerExcleList<T>(Stream fileStream, string filename, int index = 0)
            where T : class
        {
            return await Task.Run<List<T>>(() =>
                {
                    List<T> result = new List<T>();
                    IWorkbook workbook = null; //文档
                    int rowIndex = 0;
                    int fieldNumber = 0;
                    ISheet sheet = null;
                    try
                    {
                        if (filename.IndexOf(".xlsx", StringComparison.Ordinal) > 0)
                        {
                            workbook = new XSSFWorkbook(fileStream); //2007版本以上
                        }
                        else if (filename.IndexOf(".xls", StringComparison.Ordinal) > 0)
                        {
                            workbook = new HSSFWorkbook(fileStream); //2007版本以下
                        }

                        T model = null;
                        if (workbook == null)
                        {
                            return result;
                        }
                        int firstRow = 1;
                        sheet = workbook.GetSheetAt(index);
                        while (true)
                        {
                            model = Activator.CreateInstance<T>();
                            var row = sheet.GetRow(firstRow);
                            if (row == null)
                            {
                                break;
                            }
                            if (row.GetCell(0) == null || string.IsNullOrEmpty(row.GetCell(0).ToString()))
                            {
                                break;
                            }
                            //获取sheet
                            //sheet = workbook.GetSheetAt(index);
                            var props = model.GetType().GetProperties();
                            foreach (var prop in props)
                            {
                                var columnInfos = prop.GetCustomAttributes(typeof(ColumnNumberAttribute), true);
                                if (columnInfos.Length > 0)
                                {
                                    var column = columnInfos.First() as ColumnNumberAttribute;
                                    if (column != null)
                                    {
                                        var cell = row.GetCell(column.ColumnIndex - 1);
                                        rowIndex = row.RowNum;
                                        fieldNumber = column.ColumnIndex;
                                        if (prop.CanWrite && cell != null)
                                        {
                                            var type = prop.PropertyType;
                                            if (type == typeof(string))
                                            {
                                                prop.SetValue(model, cell.ToString(), null);
                                            }
                                            if (!string.IsNullOrEmpty(cell.ToString()))
                                            {
                                                if (type == typeof(bool))
                                                {
                                                    prop.SetValue(model, bool.Parse(cell.ToString()), null);
                                                }
                                                if (type == typeof(int) || type == typeof(int?))
                                                {
                                                    if (cell.ToString() != "")
                                                    {
                                                        prop.SetValue(model, int.Parse(cell.ToString()), null);
                                                    }
                                                }
                                                if (type == typeof(double) || type == typeof(double?))
                                                {
                                                    if (cell.ToString() != "")
                                                    {
                                                        if (cell.CellType == CellType.Numeric ||
                                                            cell.CellType == CellType.Formula)
                                                            prop.SetValue(model, cell.NumericCellValue, null);
                                                        else
                                                            prop.SetValue(model, double.Parse(cell.ToString()), null);
                                                    }
                                                }
                                                if (type == typeof(DateTime) || type == typeof(DateTime?))
                                                {
                                                    if (cell.ToString()!="")
                                                    {
                                                        if (cell.CellType == CellType.String)
                                                        {
                                                            DateTime date;
                                                            if (DateTime.TryParse(cell.ToString(), out date))
                                                                prop.SetValue(model, date, null);
                                                        }
                                                        else
                                                        {
                                                            prop.SetValue(model, cell.DateCellValue, null);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            result.Add(model);
                            firstRow++;
                        }
                        workbook.Close();
                        return result;
                    }
                    catch (Exception e)
                    {
                        LogHelper.Error(typeof(ExcelWithListHelper),"Excel处理失败,文件名：" + filename + ",错误行:" + rowIndex + ",错误列:" + fieldNumber, e);
                        if (workbook != null) workbook.Close();
                        return result;
                    }
                })
                ;
        }


    }
}
