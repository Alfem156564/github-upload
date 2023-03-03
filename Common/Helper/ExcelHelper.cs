namespace Common.Helper
{
    using ExcelDataReader;
    using System.Data;

    public static class ExcelHelper
    {
        public static Dictionary<string, List<string[]>> LoadFile(Stream fileStream = null, string fileName = "", string path = "")
        {
            IExcelDataReader excelDataReader = null;
            Dictionary<string, List<string[]>> list = new Dictionary<string, List<string[]>>();
            bool flag = true;
            if (!string.IsNullOrEmpty(path))
            {
                string[] array = path.Split(new char[] { '.' });
                flag = false;
                if (array.Count<string>() > 0 && array[array.Count<string>() - 1].Equals("xlsx", StringComparison.InvariantCultureIgnoreCase))
                {
                    flag = true;
                }
                try
                {
                    fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                }
                catch (Exception ex)
                {
                }
            }
            else if (fileStream != null)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                }
                else
                {
                    if (!fileName.EndsWith(".xlsx"))
                    {
                        flag = false;
                    }
                }
                DataSet dataSet = null;
                try
                {
                    if (flag)
                    {
                        excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                    }
                    else
                    {
                        excelDataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                    }

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    dataSet = excelDataReader.AsDataSet(conf);
                    List<string[]> curList;
                    foreach (DataTable dataTable in dataSet.Tables)
                    {
                        if (dataTable != null)
                        {
                            curList = new List<string[]>();
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                int num = 0;
                                bool flag2 = false;
                                string[] array2 = new string[dataRow.ItemArray.Count<object>()];
                                object[] itemArray = dataRow.ItemArray;
                                for (int i = 0; i < itemArray.Length; i++)
                                {
                                    object obj = itemArray[i];
                                    array2[num] = obj.ToString().Trim();
                                    flag2 |= !string.IsNullOrEmpty(array2[num]);
                                    num++;
                                }
                                if (flag2)
                                {
                                    curList.Add(array2);
                                }
                            }
                            list.Add(dataTable.TableName, curList);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (excelDataReader != null)
                    {
                        excelDataReader.Close();
                    }
                    if (dataSet != null)
                    {
                        dataSet.Dispose();
                    }
                }
            }
            else
            {
            }
            return list;
        }

        public static Dictionary<int, string> getRowsExcelDictionary(int num)
        {
            char valorInicial = '0';
            Dictionary<int, string> arreglo = new Dictionary<int, string>();
            for (int i = 0; i < num; i++)
            {
                if (i > 0 && i % 26 == 0)
                {
                    valorInicial = valorInicial == '0' ? (char)65 : valorInicial = (char)((int)valorInicial + 1);
                }
                arreglo.Add(i + 1, valorInicial == '0' ? (char)(i + 65) + "" : (valorInicial + "") + (char)(i % 26 + 65) + "");
            }
            return arreglo;
        }
    }
}
