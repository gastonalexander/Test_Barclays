using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Configuration;

namespace Standard_VAT_Rates_Per_Country
{
    public class ReadJsonData
    {
        public void ReadJson()
        {
            string json;
            List<OutputRates> outputRates = new List<OutputRates>();
                 
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["uri"]);
                request.Method = "GET";

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        json = sr.ReadToEnd();
                    }
                    var jsonData = JsonConvert.DeserializeObject<Rootobject>(json);

                    if (jsonData == null)
                    {
                        Console.WriteLine("No data to process");
                    }

                    foreach (var rates in jsonData.rates)
                    {
                        if (rates.periods != null)
                        {
                            outputRates.Add(new OutputRates()
                            {
                                Country = rates.name.ToString(),
                                Standard = rates.periods.OrderByDescending(s => s.effective_from).FirstOrDefault().rates.standard.ToString(),
                            });
                        }
                    }
                    DisplayInformation(outputRates);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }            
        }

        private static void DisplayInformation(List<OutputRates> outputRates)
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine("         Top 3 Countries with the lowest Standard Rates:");
            Console.WriteLine("=============================================================================");
            Console.WriteLine();
            foreach (var outputRate in outputRates.OrderBy(i => i.Standard).Take(3).Reverse())
            {
                Console.WriteLine(String.Format("{0}\t{1}", outputRate.Country, " - " + outputRate.Standard));
            }
            Console.WriteLine("=============================================================================");
            Console.WriteLine("         Top 3 Countries with the highest Standard Rates:");
            Console.WriteLine("=============================================================================");
            Console.WriteLine();
            foreach (var outputRate in outputRates.OrderByDescending(i => i.Standard).Take(3))
            {
                Console.WriteLine(String.Format("{0}\t{1}", outputRate.Country, " - " + outputRate.Standard));
            }
        }
    }
}
