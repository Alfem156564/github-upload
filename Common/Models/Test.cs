using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    internal class Test
    {
    }

    public class ExcelData
    {
        public string name { get; set; }
        public string value { get; set; }

    }

    public enum ExcelDataEnum
    {
        nombre,
        valor

    }

    public class prueba
    {
        Dictionary<string,bool> automotrizValidationDic = new Dictionary<string, bool>
        {
            { "Saldo de Caja (Bancos)", false },
            { "Inventarios Nuevos", false },
            { "Inventarios Seminuevos", false },
            { "Refacciones", false },
            { "Cuentas por Cobrar", false },
            { "Otros", false },
            { "Activos LP", false },
            { "Inmuebles", false },
            { "Activo Fijo", false },
            { "Activo Fijo", false }
        };

        public void Excel()
        {
            List<ExcelData> listaDatosExcel = new List<ExcelData>();
            ExcelDataEnum estadoExcel = ExcelDataEnum.nombre;
            string excelValues = null;
            string name = "";

            if (automotrizValidationDic.ContainsKey(name.Trim()))
            {
                automotrizValidationDic[name] = true;
            }

            if (!string.IsNullOrWhiteSpace(excelValues))
            {
                if(estadoExcel == ExcelDataEnum.nombre)
                {
                    name = excelValues;
                    estadoExcel = ExcelDataEnum.valor;
                }
                else
                {
                    listaDatosExcel.Add(new ExcelData { name = name, value = excelValues });

                    estadoExcel = ExcelDataEnum.nombre;
                }
            }

            foreach(var datoExcel in listaDatosExcel)
            {

            }

            foreach(string dickeys in automotrizValidationDic.Keys)
            {
                if (!automotrizValidationDic[dickeys])
                {
                    string error;
                }
            }
        }
    }
}
