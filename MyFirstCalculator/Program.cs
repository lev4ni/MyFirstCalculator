using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyFirstCalculator.Model;

namespace MyFirstCalculator
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fileName = @"..\..\..\MyFirstCalculator\stocks-ITX.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = ";" // The delimiter is a comma.
            };

            List<StocksITX> data = new List<StocksITX>();
            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    data = csv.GetRecords<StocksITX>().ToList();

                }
            }

            List<StocksITX> listaJueves = new List<StocksITX>();
            DateTime result;
            string format = "dd-MMM-yyyy";
            foreach (var stock in data)
            {
                CultureInfo culture = new CultureInfo("es-ES");
                culture.DateTimeFormat.AbbreviatedMonthNames = new string[] { "ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic", ""};


                if (DateTime.TryParseExact(stock.Fecha, format, culture, DateTimeStyles.None, out result))
                {
                    int year = result.Year;
                    int month = result.Month;
                    int lastDayOfMonth = DateTime.DaysInMonth(year, month);
                    DateTime lastDay = new DateTime(year, month, lastDayOfMonth);

                    while (lastDay.DayOfWeek != DayOfWeek.Thursday)
                    {
                        lastDay = lastDay.AddDays(-1);
                    }

                    if (result == lastDay)
                    {
                        listaJueves.Add(stock);
                    }
                }
                
            }

            float total = 0;
            float cantidadLimpia = 50 - (50 * 0.02f); //broker 
            foreach (var item in listaJueves)
            {
                total = item.Cierre * cantidadLimpia + total;
            }

            


        
        }
    }
}
