using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiJsonHeadhunterClient.Mapping
{
    [DataContract]
    public class ResultsPerId
    {
        [DataMember]
        public string alternate_url { get; set; }

        [DataMember]
        public object code { get; set; }

        [DataMember]
        public bool premium { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public Schedule schedule { get; set; }

        [DataMember]
        public object suitable_resumes_url { get; set; }

        [DataMember]
        public Site site { get; set; }

        [DataMember]
        public BillingType billing_type { get; set; }

        [DataMember]
        public string published_at { get; set; }

        [DataMember]
        public object test { get; set; }

        [DataMember]
        public bool accept_handicapped { get; set; }

        [DataMember]
        public Experience experience { get; set; }

        [DataMember]
        public Address address { get; set; }

        [DataMember]
        public List<object> key_skills { get; set; }

        [DataMember]
        public bool allow_messages { get; set; }

        [DataMember]
        public Employment employment { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public object response_url { get; set; }

        [DataMember]
        public Salary salary { get; set; }

        [DataMember]
        public bool archived { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public object contacts { get; set; }

        [DataMember]
        public string created_at { get; set; }

        [DataMember]
        public Area area { get; set; }

        [DataMember]
        public List<object> relations { get; set; }

        [DataMember]
        public Employer employer { get; set; }

        [DataMember]
        public bool response_letter_required { get; set; }

        [DataMember]
        public string apply_alternate_url { get; set; }

        [DataMember]
        public object negotiations_url { get; set; }

        [DataMember]
        public object department { get; set; }

        [DataMember]
        public object branded_description { get; set; }

        [DataMember]
        public bool hidden { get; set; }

        [DataMember]
        public Type type { get; set; }

        [DataMember]
        public List<Specialization> specializations { get; set; }

        public class Schedule
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Site
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class BillingType
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Experience
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Metro
        {
            public string line_name { get; set; }

            public string station_id { get; set; }

            public string line_id { get; set; }

            public double lat { get; set; }

            public string station_name { get; set; }

            public double lng { get; set; }
        }

        public class MetroStation
        {
            public string line_name { get; set; }

            public string station_id { get; set; }

            public string line_id { get; set; }

            public double lat { get; set; }

            public string station_name { get; set; }

            public double lng { get; set; }
        }

        public class Address
        {
            public string building { get; set; }

            public string city { get; set; }

            public object description { get; set; }

            public Metro metro { get; set; }

            public List<MetroStation> metro_stations { get; set; }

            public object raw { get; set; }

            public string street { get; set; }

            public double lat { get; set; }

            public double lng { get; set; }
        }

        public class Employment
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Salary
        {
            public object to { get; set; }

            public int from { get; set; }

            public string currency { get; set; }
        }

        public class Area
        {
            public string url { get; set; }

            public string id { get; set; }

            public string name { get; set; }
        }

        public class LogoUrls
        {
            public string __invalid_name__90 { get; set; }

            public string __invalid_name__240 { get; set; }

            public string original { get; set; }
        }

        public class Employer
        {
            public LogoUrls logo_urls { get; set; }

            public string vacancies_url { get; set; }

            public string name { get; set; }

            public string url { get; set; }

            public string alternate_url { get; set; }

            public string id { get; set; }
        }

        public class Type
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Specialization
        {
            public string profarea_id { get; set; }

            public string profarea_name { get; set; }

            public string id { get; set; }

            public string name { get; set; }
        }
    }
}