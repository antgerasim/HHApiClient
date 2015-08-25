using System;
using System.Text.RegularExpressions;
using ApiJsonHeadhunterClient.Mapping;

namespace ApiJsonHeadhunterClient.Helpers
{
    internal static class Helper
    {
        private static int _page;
        private static int _pages;
        private static int _perPage;
        private static int _found;
        private static int _totalCounter;

        public static int TotalCounter
        {
            get { return _totalCounter; }
            set { _totalCounter = value; }
        }

        internal static void DisplayVacancies(ResultsPerPage pageResults)
        {
            if (pageResults != null)
            {
                //_found = vacanciesData.found;
                //_page = vacanciesData.page;
                //_pages = vacanciesData.pages;
                //_perPage = vacanciesData.per_page;
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Page number: " + pageResults.page);
                //Console.WriteLine("Header.TotalVacancies: " + _found);
                Console.WriteLine("Header.TotalVacancies: " + pageResults.found);
                //Console.WriteLine("Header.currentPage: " + _page);
                //Console.WriteLine("Header.currentPage: " + pageResults.page);
                //Console.WriteLine("Header.pagesTotal: " + _pages);
                //Console.WriteLine("Header.itemsPerPage:" + _perPage);
                Console.WriteLine("Header.itemsPerPage:" + pageResults.per_page);
                Console.WriteLine("Header.alternate_url: " + pageResults.alternate_url);
                Console.WriteLine("Header.clusters: " + pageResults.clusters);

                Console.WriteLine("Start listing vacancies...:" + Environment.NewLine);
                foreach (ResultsPerPage.Item vacancy in pageResults.items)
                {
                    DisplayVacancyId(vacancy);
                }
                //int counter = 0;
                //foreach (SearchByTextData.Item item in vacanciesData.items)
                //{
                //   DisplayVacancyId(item);
                //   counter++;
                //}
            }
        }

        private static void DisplayVacancyId(ResultsPerPage.Item vacancy)
        {
            if (vacancy != null)
            {
                Console.WriteLine("vacancy.id: " + vacancy.id);
                Console.WriteLine("_totalCounter: " + _totalCounter++);
                Console.WriteLine("END-------------------------");
            }
        }

        internal static void DisplayVacancyId(ResultsPerId vacancy)
        {
            if (vacancy != null)
            {
                Console.WriteLine("vacancy.id: " + vacancy.id);
                Console.WriteLine("_totalCounter: " + _totalCounter++);
                Console.WriteLine("END-------------------------");
            }
        }

        internal static void DisplayVacanciesJson(ResultsPerPage vacanciesData)
        {
            if (vacanciesData != null)
            {
                _found = vacanciesData.found;
                _page = vacanciesData.page;
                _pages = vacanciesData.pages;
                _perPage = vacanciesData.per_page;
                Console.WriteLine("List Header:");
                Console.WriteLine("Header.found: " + _found);
                Console.WriteLine("Header.currentPage: " + _page);
                Console.WriteLine("Header.pagesTotal: " + _pages);
                Console.WriteLine("Header.itemsPerPage:" + _perPage);
                Console.WriteLine("Header.alternate_url: " + vacanciesData.alternate_url);
                Console.WriteLine("Header.clusters: " + vacanciesData.clusters);

                //Console.WriteLine("vacanciesData.pages: " + vacanciesData.pages);
                //Console.WriteLine("vacanciesData.per_page: " + vacanciesData.per_page);
                Console.WriteLine("Start listing vacancies...:" + Environment.NewLine);

                int counter = 0;
                foreach (var item in vacanciesData.items)
                {
                    Console.WriteLine("Vacancy #: " + counter);

                    Console.WriteLine("item.id: " + item.id);
                    Console.WriteLine("item.name: " + item.name);
                    Console.WriteLine("item.employer: " + item.employer.id);
                    Console.WriteLine("item.employer: " + item.employer.name);
                    if (item.address != null)
                    {
                        Console.WriteLine("item.address.id: " + item.address.id); //null exception?
                        Console.WriteLine("item.address.city: " + item.address.city);
                    }

                    Console.WriteLine("item.area.id: " + item.area.id);
                    Console.WriteLine("item.area.name: " + item.area.name);
                    if (item.salary != null)
                    {
                        Console.WriteLine("item.salary.from" + item.salary.from);
                        Console.WriteLine("item.salary.from" + item.salary.to);
                        Console.WriteLine("item.salary.from" + item.salary.currency);
                    }
                    Console.WriteLine("item.type.id " + item.type.id);
                    Console.WriteLine("item.type.name: " + item.type.name);

                    Console.WriteLine("item.created_at: " + item.created_at);
                    Console.WriteLine("item.published_at: " + item.published_at);
                    Console.WriteLine("item.url: " + item.url);
                    Console.WriteLine("item.url: " + item.alternate_url);
                    Console.WriteLine("------------------------------------");
                    counter++;
                }
            }
        }

        internal static void DisplayVacanciesJson(ResultsPerId vacancyJson)
        {
            Console.WriteLine("vacanciesData.id: " + vacancyJson.id);
            //Console.WriteLine("vacanciesData.type.id: " + vacanciesData.type.id);
            Console.WriteLine("vacanciesData.type.name: " + vacancyJson.type.name);
            Console.WriteLine("vacanciesData.name: " + vacancyJson.name);
            Console.WriteLine("vacanciesData.description: " + vacancyJson.description);
            Console.WriteLine("vacanciesData.employer.name: " + vacancyJson.employer.name);
            Console.WriteLine("vacanciesData.employment: " + vacancyJson.employment.name);
            Console.WriteLine("vacanciesData.department: " + vacancyJson.department);
            Console.WriteLine("vacanciesData.hidden: " + vacancyJson.hidden);
            Console.WriteLine("vacanciesData.code: " + vacancyJson.code);
            Console.WriteLine("vacanciesData.contacts: " + vacancyJson.contacts);
            Console.WriteLine("vacanciesData.created_at: " + vacancyJson.created_at);
            Console.WriteLine("vacanciesData.published_at: " + vacancyJson.published_at);
            Console.WriteLine("vacanciesData.relations: " + vacancyJson.relations);
            Console.WriteLine("vacanciesData.response_letter_required: "
                + vacancyJson.response_letter_required);
            Console.WriteLine("vacanciesData.response_url: " + vacancyJson.response_url);
            Console.WriteLine("vacanciesData.salary.currency: " + vacancyJson.salary.currency);
            Console.WriteLine("vacanciesData.salary.from: " + vacancyJson.salary.from);
            Console.WriteLine("vacanciesData.salary.to: " + vacancyJson.salary.to);

            Console.WriteLine("vacanciesData.schedule.name: " + vacancyJson.schedule.name);
            Console.WriteLine("vacanciesData.site.name: " + vacancyJson.site.name);
            //for (int i = 0; i < vacanciesData.specializations.Count; i++) {
            //   Console.WriteLine("vacanciesData.specialization: " + specialization);
            //}
            foreach (var specialization in vacancyJson.specializations)
            {
                Console.WriteLine("vacanciesData.specialization.id: " + specialization.id);
                Console.WriteLine("vacanciesData.specialization.name: " + specialization.name);
                Console.WriteLine("vacanciesData.specialization.profarea_id: "
                    + specialization.profarea_id);
                Console.WriteLine("vacanciesData.specialization.profarea_name: "
                    + specialization.profarea_name);
                Console.WriteLine("End of specialization....");
            }
            //Console.WriteLine("vacanciesData.specializations" + vacanciesData.specializations);
            Console.WriteLine("vacanciesData.suitable_resumes_url: "
                + vacancyJson.suitable_resumes_url);
            Console.WriteLine("vacanciesData.test: " + vacancyJson.test);
            Console.WriteLine("vacanciesData.accept_handicapped: " + vacancyJson.accept_handicapped);
            Console.WriteLine("vacanciesData.address.building: " + vacancyJson.address.building);
            Console.WriteLine("vacanciesData.address.city: " + vacancyJson.address.city);
            Console.WriteLine("vacanciesData.address.description: "
                + vacancyJson.address.description);
            Console.WriteLine("vacanciesData.address.lat: " + vacancyJson.address.lat);
            Console.WriteLine("vacanciesData.address.lng: " + vacancyJson.address.lng);
            Console.WriteLine("vacanciesData.address.metro: " + vacancyJson.address.metro);
            Console.WriteLine("vacanciesData.address.raw: " + vacancyJson.address.raw);
            Console.WriteLine("vacanciesData.address.street: " + vacancyJson.address.street);

            Console.WriteLine("vacanciesData.allow_messages: " + vacancyJson.allow_messages);
            Console.WriteLine("vacanciesData.alternate_url: " + vacancyJson.alternate_url);
            Console.WriteLine("vacanciesData.apply_alternate_url: "
                + vacancyJson.apply_alternate_url);
            Console.WriteLine("vacanciesData.archived: " + vacancyJson.archived);
            Console.WriteLine("vacanciesData.area.id: " + vacancyJson.area.id);
            Console.WriteLine("vacanciesData.area.name: " + vacancyJson.area.name);
            Console.WriteLine("vacanciesData.area.url: " + vacancyJson.area.url);

            Console.WriteLine("vacanciesData.billing_type.id: " + vacancyJson.billing_type.id);
            Console.WriteLine("vacanciesData.billing_type.name: " + vacancyJson.billing_type.name);

            Console.WriteLine("vacanciesData.branded_description: "
                + vacancyJson.branded_description);
            Console.WriteLine("vacanciesData.experience.id: " + vacancyJson.experience.id);
            Console.WriteLine("vacanciesData.experience.name: " + vacancyJson.experience.name);

            //
            foreach (var key_skill in vacancyJson.key_skills)
            {
                //Console.WriteLine("vacanciesData.key_skill: " + key_skill.name);
                //e.g подбор персонала
                Console.WriteLine("End of key_skill....");
            }

            Console.WriteLine("vacanciesData.negotiations_url" + vacancyJson.negotiations_url);
            Console.WriteLine("vacanciesData.premium" + vacancyJson.premium);
        }

        internal static String FilterString(string str)
        {
            Regex re = new Regex("[;\\\\/:*?\"<>|&'-]");
            string outputString = re.Replace(str, " ");
            return outputString;
        }
    }
}