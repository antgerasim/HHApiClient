﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiJsonHeadhunterClient
{

   [DataContract]
   public class ResultsPerPage
   {

      [DataMember]
      public object clusters { get; set; }

      [DataMember]
      public List<Item> items { get; set; }

      [DataMember]
      public int found { get; set; }

      [DataMember]
      public int per_page { get; set; }

      [DataMember]
      public string alternate_url { get; set; }

      [DataMember]
      public int page { get; set; }

      [DataMember]
      public int pages { get; set; }

      public class Salary
      {

         public int? to { get; set; }

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

         public string original { get; set; }

         public string __invalid_name__240 { get; set; }

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

      public class Metro
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

         public List<object> metro_stations { get; set; }

         public string raw { get; set; }

         public string street { get; set; }

         public double? lat { get; set; }

         public double? lng { get; set; }

         public string id { get; set; }

      }

      public class Type
      {

         public string id { get; set; }

         public string name { get; set; }

      }

      public class Item
      {

         public Salary salary { get; set; }

         public bool archived { get; set; }

         public bool premium { get; set; }

         public string name { get; set; }

         public Area area { get; set; }

         public string url { get; set; }

         public string created_at { get; set; }

         public List<object> relations { get; set; }

         public Employer employer { get; set; }

         public bool response_letter_required { get; set; }

         public string published_at { get; set; }

         public Address address { get; set; }

         public string alternate_url { get; set; }

         public Type type { get; set; }

         public string id { get; set; }

      }

   }

}