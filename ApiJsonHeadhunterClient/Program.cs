using System;
using System.Collections.Generic;
using ApiJsonHeadhunterClient.Helpers;
using ApiJsonHeadhunterClient.Mapping;
using ApiJsonHeadhunterClient.WebClient;

namespace ApiJsonHeadhunterClient
{
    internal class Program
    {
        private static IList<string> _vacancyIds;
        private static IList<ResultsPerId> _terapevts;
        private static IList<ResultsPerId> _chirurgs;
        private static IList<ResultsPerId> _oftalmologs;
        private static IList<ResultsPerId> _stomatologs;
        private static IList<ResultsPerId> _pediators;
        private static IList<ResultsPerId> _notForDoctors;
        private static IList<ResultsPerId> _noSpecializations;

        private static void Main(string[] args)
        {
            //HeadHunterApiClient.GetVacById(14187125);
            //new HeadHunterApiClient().GetVacBySearchField("?text", "Врач", 10);

            HeadHunterApiClient hhApiClient = new HeadHunterApiClient();

            //Get all searchresults by ID
            _vacancyIds = hhApiClient.GetAllVacanciesByName("?text=", "Врач", "&page=", 0,
                "&per_page=", 100);

            Console.WriteLine(Environment.NewLine);
            //Demonstrate (print) all records
            foreach (string vacancyId in _vacancyIds)
            {
                Console.WriteLine("Recorded string.ID: " + vacancyId);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Pop all vacancies over API using collected id's.");
            Console.WriteLine("Reset totalCounter...");
            Helper.TotalCounter = 0;

            _terapevts = new List<ResultsPerId>();
            _chirurgs = new List<ResultsPerId>();
            _oftalmologs = new List<ResultsPerId>();
            _stomatologs = new List<ResultsPerId>();
            _pediators = new List<ResultsPerId>();
            _notForDoctors = new List<ResultsPerId>();
            _noSpecializations = new List<ResultsPerId>();
            //Serialize all Vacancies into files 
            foreach (var vacancyId in _vacancyIds)
            {
                //1.getvacancy by ID as object
                ResultsPerId vacancy = hhApiClient.GetVacById(Int32.Parse(vacancyId));
                _noSpecializations = new List<ResultsPerId>();
                //2.filter by rules into (own collection)?
                //use String Filter
                String vacancyName = Helper.FilterString(vacancy.name.ToLowerInvariant());
                //use to lowerinvariant?
                //Todo: replace by swith, later with strategy
                if (vacancyName.Contains("терапевт"))
                {
                    _terapevts.Add(vacancy);
                }
                if (vacancyName.Contains("хирург"))
                {
                    _chirurgs.Add(vacancy);
                }
                if (vacancyName.Contains("офтальмолог"))
                {
                    _oftalmologs.Add(vacancy);
                }
                if (vacancyName.Contains("стоматолог"))
                {
                    _stomatologs.Add(vacancy);
                }
                if (vacancyName.Contains("педиатр"))
                {
                    _pediators.Add(vacancy);
                }
                if (vacancyName.Contains("фармацевт") | vacancy.name.Contains("Провизор")
                    | vacancy.name.Contains("медсестра") | vacancy.name.Contains("Интерн"))
                {
                    _notForDoctors.Add(vacancy);
                }
                else
                {
                    _noSpecializations.Add(vacancy);
                }
            }

            //3.Take collections, convert back to contentString and Serialize into folders in JSON (.txt?) format.
        }
    }
}