using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Dtos;
using Newtonsoft.Json;

namespace Ancestry.Common.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [JsonProperty("father_id")]
        public int? FatherId { get; set; }
        [JsonProperty("mother_id")]
        public int? MotherId { get; set; }
        [JsonProperty("place_id")]
        public int PlaceId { get; set; }
        public int Level { get; set; }
    }

     public enum Gender
    {
        Male, 
        Female
    }
}
