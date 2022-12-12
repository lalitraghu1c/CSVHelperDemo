using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperDemo
{
    public class CSVHandler
    {
        public static void ImplementCSVHandling()
        {
            string importFilePath = @"D:\Projects-Bridgelabz\Learning\CSVHelper\address.csv";
            string exportFilePath = @"D:\Projects-Bridgelabz\Learning\CSVHelper\export.csv";
            //reading CSV File
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from the address csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.Name);
                    Console.WriteLine("\t" + addressData.Email);
                    Console.WriteLine("\t" + addressData.Phone);
                    Console.WriteLine("\t" + addressData.Country);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n *********************** Now Reading from csv file and write to csv file ***********************");
                //writing CSV File
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}