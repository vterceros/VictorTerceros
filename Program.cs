using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorTerceros.DBModel;
using VictorTerceros.Logic;

namespace VictorTerceros
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetCountries = new List<string>() { "United States", "Canada" , "United Kingdom"  };
            var targetRoles = new List<string>() { "president", "founder", "chair", "director", "manager", "supervisor", "chief", "ceo", "cto", "human", "tech", "board" };
            var keyRoles = new List<string>() { "tech", "information", "human", "recrui", "service" };
            var excludedRoles = new List<string>() { "technician", "delivery" };
            var targetIndustries = new List<string>() { "" };
            var currentClients = new List<int>();
            var result = FilterLogic.GetPeople(targetCountries, targetRoles, keyRoles,excludedRoles, targetIndustries, currentClients, 0, 0);
            WriteFile(result);
            foreach (var item in result)
            {
                Console.WriteLine("{0} | {1} | {2}", item.Country, item.Industry, item.CurrentRole);
            }
            Console.WriteLine("{0}", result.Count);
            Console.ReadKey();
        }

        private static void WriteFile(List<People> content)
        {
            string fileName = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "people.out");

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach (var line in content)
                    {
                        sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", line.PersonId,line.Name,line.LastName,line.CurrentRole,line.Country,line.Industry,line.NumberOfRecommendations,line.NumberOfConnections);
                    }

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
