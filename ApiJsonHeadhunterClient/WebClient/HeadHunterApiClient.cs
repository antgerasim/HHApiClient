using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using ApiJsonHeadhunterClient.Helpers;
using ApiJsonHeadhunterClient.Mapping;

namespace ApiJsonHeadhunterClient.WebClient
{
    public class HeadHunterApiClient
    {
        private int _allVacancies;
        private IList<string> _vacanciesIdList;
        private const string BaseUrlId = "https://api.hh.ru/vacancies/{0}";
        //private const string BaseUrlText = "https://api.hh.ru/vacancies/?text={0}";
        private const string BaseUrl = "https://api.hh.ru/vacancies/{0}={1}";

        public IList<string> GetAllVacanciesByName(string searchParam, string searchfield,
            string pageParam, int page, string perPageParam, int perPage)
        {
            _allVacancies = 0;
            int currentPage = page;
            int pages = 0;
            string url = GetUrl(searchParam, searchfield, pageParam, page, perPageParam, perPage);
            _vacanciesIdList = new List<string>();
            do
            {
                try
                {
                    var contentString = ConsumeJson(url);
                    ResultsPerPage pageResults = SerializeToObject2(contentString);

                    if (pageResults != null)
                    {
                        AddVacancyIdToList(pageResults, _vacanciesIdList);

                        Helper.DisplayVacancies(pageResults);
                        _allVacancies = pageResults.found;
                        pages = pageResults.pages;
                    }
                    else
                    {
                        Console.WriteLine("failed to serialize page: " + currentPage);
                    }
                }
                catch (WebException wex)
                {
                    HandleWebException(wex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    currentPage++;
                    Console.WriteLine("{0} of {1} vacancies processed: ", Helper.TotalCounter,
                        _allVacancies);
                }
            }
            while (currentPage < pages);
            return _vacanciesIdList;
        }

        public ResultsPerId GetVacById(int id)
        {
            string url = string.Format(BaseUrlId, id);

            ResultsPerId vacancyJson = null;
            try
            {
                var contentString = ConsumeJson(url);

                // Create the Json serializer and parse the response
                vacancyJson = SerializeToObject(contentString);
                Helper.DisplayVacancyId(vacancyJson);
            }
            catch (WebException wex)
            {
                HandleWebException(wex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return vacancyJson;
        }

        private static void AddVacancyIdToList(ResultsPerPage resultsByPage,
            IList<string> vacanciesIdList)
        {
            foreach (ResultsPerPage.Item item in resultsByPage.items)
            {
                vacanciesIdList.Add(item.id);
            }
        }

        private String GetUrl(string searchParam, string searchfield, string pageParam, int page,
            string perPageParam, int perPage)
        {
            string baseUrl = "https://api.hh.ru/vacancies/{0}{1}&page={2}&per_page={3}";
            //string baseUrl = "https://api.hh.ru/vacancies/{0}{1}(2}{3}{4}{5}";
            string url = string.Format(baseUrl, searchParam, searchfield, page, perPage);
            //string url = string.Format(baseUrl, searchParam, searchfield, pageParam, page, perPageParam,perPage );
            return url;
        }

        private ResultsPerId SerializeToObject(string contentString)
        {
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof (ResultsPerId));
            ResultsPerId vacancyJson = null;
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(contentString)))
            {
                try
                {
                    vacancyJson = (ResultsPerId) serializer.ReadObject(ms);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("SerializationException on: ");
                    //Todo - filter vacany id out of contentString and include to message
                }
                catch (Exception)
                {
                }
            }
            return vacancyJson;
        }

        private ResultsPerPage SerializeToObject2(string contentString)
        {
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof (ResultsPerPage));
            ResultsPerPage vacanciesData = null;
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(contentString)))
            {
                try
                {
                    // deserialize the JSON object using the WeatherData type.
                    vacanciesData = (ResultsPerPage) serializer.ReadObject(ms);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("SerializationException on: ");
                    //Todo - filter vacany id out of contentString
                }
                catch (Exception ex)
                {
                }
            }
            return vacanciesData;
        }

        private string ConsumeJson(string url)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            //add user agent header
            webClient.Headers.Add("user-agent", "AntgerasimApp/1.0 (antgerasim@yandex.ru)");
            webClient.Encoding = Encoding.UTF8; //!
            var content = webClient.DownloadString(url); //DownloadString = HTTP GET
            return content;
        }

        private void HandleWebException(WebException wex)
        {
            string msg = "The server did not like your request.";
            HttpWebResponse hwr = wex.Response as HttpWebResponse;
            if (hwr != null)
            {
                msg += string.Format("\r\nThe status code is {0}, the status message: {1}.",
                    (int) hwr.StatusCode, hwr.StatusDescription);
                using (StreamReader sreader = new StreamReader(hwr.GetResponseStream()))
                {
                    string errorMessage = sreader.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        msg += "\r\n\r\nThe further data sent from the server are:\r\n"
                            + errorMessage;
                    }
                }
            }
            Console.WriteLine(msg);
        }
    }
}

//https://github.com/hhru/api/blob/master/docs/vacancies.md
//При указании параметров пэйджинга (page, per_page) работает ограничение: глубина возвращаемых результатов не может быть больше 2000.