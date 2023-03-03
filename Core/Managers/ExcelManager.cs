using ClosedXML.Excel;
using Common.Enumerations;
using Common.Helper;
using Common.Models;
using Core.Contracts;

namespace Core.Managers
{
    public class ExcelManager : IExcelManager
    {
        public ManagerResult<string> CompararExcels(Stream fileStream, string fileName, string ruta)
        {
            try
            {
                Dictionary<string, List<string[]>> infoExcel = ExcelHelper.LoadFile(fileStream, fileName);
                string hojaSithec = "SITHEC", hojaASC = "ASC Correcto";
                if (!infoExcel.ContainsKey(hojaASC))
                {
                    return ManagerResult<string>.FromErrorMessage($"No se encontro la hoja con nombre {hojaASC}");
                }
                if (!infoExcel.ContainsKey(hojaSithec))
                {
                    return ManagerResult<string>.FromErrorMessage($"No se encontro la hoja con nombre {hojaSithec}");
                }
                var workbook = new XLWorkbook();
                workbook.AddWorksheet("Empleados Crear");
                IXLWorksheet ws = workbook.Worksheet("Empleados Crear"); 
                int row = 1;
                ws.Cell("A" + row.ToString()).Value = "Llave";
                ws.Cell("B" + row.ToString()).Value = "TipoError";
                ws.Cell("C" + row.ToString()).Value = "SITHEC";
                ws.Cell("D" + row.ToString()).Value = "ASC";
                row++;
                //Recorrer hojas 2 veceses
                Dictionary<string, ExcelModel> DiccSithec = new Dictionary<string, ExcelModel>();
                Dictionary<string, int> DiccSithecDuplicatedKeys = new Dictionary<string, int>();
                Dictionary<string, ExcelModel> DiccASC = new Dictionary<string, ExcelModel>();
                Dictionary<string, int> DiccASCDuplicatedKeys = new Dictionary<string, int>();
                Dictionary<string, string> DiccKeysComnparadas = new Dictionary<string, string>();

                //" diccionarios una de repetidos y otra de llave modelo
                var resp = LLENAR(infoExcel[hojaSithec], DiccSithec, DiccSithecDuplicatedKeys, ws, row);
                DiccSithec = resp.dicExcel;
                DiccSithecDuplicatedKeys = resp.dicRepetidas;

                resp = LLENAR(infoExcel[hojaASC], DiccSithec, DiccSithecDuplicatedKeys, ws, row, true);
                DiccASC = resp.dicExcel;
                DiccASCDuplicatedKeys = resp.dicRepetidas;
                ws = resp.ws;
                row = resp.row;

                foreach(var dicSithec in DiccSithec)
                {
                    string key = dicSithec.Key;
                    if (!DiccKeysComnparadas.ContainsKey(key))
                    {
                        if (DiccSithecDuplicatedKeys.ContainsKey(key))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.LlavesDuplicadas.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithecDuplicatedKeys[key];
                            ws.Cell("D" + row.ToString()).Value = DiccASCDuplicatedKeys.ContainsKey(key) ? DiccASCDuplicatedKeys[key] : 0;
                            row++;
                        }
                        else
                        {
                            if (!DiccASC.ContainsKey(key))
                            {
                                ws.Cell("A" + row.ToString()).Value = key;
                                ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.LlavesNoEncontrada.ToString();
                                ws.Cell("C" + row.ToString()).Value = key;
                                ws.Cell("D" + row.ToString()).Value = "";
                                row++;
                            }
                        }
                        DiccKeysComnparadas.Add(key, key);
                    }
                }

                foreach (var dicASC in DiccASC)
                {
                    string key = dicASC.Key;
                    if (!DiccKeysComnparadas.ContainsKey(key))
                    {
                        if (DiccASCDuplicatedKeys.ContainsKey(key))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.LlavesDuplicadas.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithecDuplicatedKeys.ContainsKey(key) ? DiccSithecDuplicatedKeys[key] : 0;
                            ws.Cell("D" + row.ToString()).Value = DiccASCDuplicatedKeys[key];
                            row++;
                        }
                        else
                        {
                            if (!DiccASC.ContainsKey(key))
                            {
                                ws.Cell("A" + row.ToString()).Value = key;
                                ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.LlavesNoEncontrada.ToString();
                                ws.Cell("C" + row.ToString()).Value = "";
                                ws.Cell("D" + row.ToString()).Value = key;
                                row++;
                            }
                        }
                        DiccKeysComnparadas.Add(key, key);
                    }
                }

                //Comparar dic Hoja una con Hoja 2 y viceverza
                string excelName = $"{Guid.NewGuid()}.xlsx";
                string fileSave = Path.Combine(ruta, excelName);
                workbook.SaveAs(fileSave);
                return ManagerResult<string>.FromSuccess(excelName);
            }
            catch (Exception e)
            {
                return ManagerResult<string>.FromErrorMessage(e.ToString());
            }
        }

        private (Dictionary<string, ExcelModel> dicExcel, Dictionary<string, int> dicRepetidas, IXLWorksheet ws, int row) LLENAR(List<string[]> strings, Dictionary<string, ExcelModel> DiccSithec, Dictionary<string, int> DiccSithecDuplicatedKeys, IXLWorksheet ws, int row, bool comparar = false)
        {
            Dictionary<string, ExcelModel> dicExcel = new Dictionary<string, ExcelModel>();
            Dictionary<string, int> dicRepetidas = new Dictionary<string, int>();
            for (int i = 1; i < strings.Count; i++)
            {
                var values = strings.ElementAt(i);

                string cuenta = values[0].Trim();
                string nombre = values[1].Trim();
                string fecha = values[2].Trim();
                string tipo = values[3].Trim();
                string empty = values[4].Trim();
                string numero = values[5].Trim();
                string concepto = values[6].Trim();
                string referencia = values[7].Trim();
                string carga = values[8].Trim();
                string abono = values[9].Trim();
                string saldo = values[10].Trim();

                string key = $"{cuenta}|{empty}|{concepto}|{carga}|{abono}";

                if (!dicExcel.ContainsKey(key))
                {
                    dicExcel.Add(key, new ExcelModel
                    {
                        Fecha = fecha,
                        Nombre = nombre,
                        Numero = numero,
                        Referencia = referencia,
                        Tipo = tipo,
                    });
                }
                else
                {
                    if (!dicRepetidas.ContainsKey(key))
                    {
                        dicRepetidas.Add(key, 2);
                    }
                    else
                    {
                        dicRepetidas[key] += 1;
                    }
                }

                if(comparar == true)
                {
                    if (DiccSithec.ContainsKey(key) && !DiccSithecDuplicatedKeys.ContainsKey(key))
                    {
                        if (!string.Equals(DiccSithec[key].Fecha, fecha))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.FechaDiferente.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithec[key].Fecha;
                            ws.Cell("D" + row.ToString()).Value = fecha;
                            row++;
                        }
                        if (!string.Equals(DiccSithec[key].Nombre, nombre))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.NombreDiferente.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithec[key].Nombre;
                            ws.Cell("D" + row.ToString()).Value = nombre;
                            row++;
                        }
                        if (!string.Equals(DiccSithec[key].Numero, numero))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.NumeroDiferente.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithec[key].Numero;
                            ws.Cell("D" + row.ToString()).Value = numero;
                            row++;
                        }
                        if (!string.Equals(DiccSithec[key].Referencia, referencia))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.ReferenciaDiferente.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithec[key].Referencia;
                            ws.Cell("D" + row.ToString()).Value = referencia;
                            row++;
                        }
                        if (!string.Equals(DiccSithec[key].Tipo, tipo))
                        {
                            ws.Cell("A" + row.ToString()).Value = key;
                            ws.Cell("B" + row.ToString()).Value = ErrorExcelEnum.TipoDiferente.ToString();
                            ws.Cell("C" + row.ToString()).Value = DiccSithec[key].Tipo;
                            ws.Cell("D" + row.ToString()).Value = tipo;
                            row++;
                        }
                    }
                }
            }

            return (dicExcel, dicRepetidas, ws, row);
        }
    }
}
