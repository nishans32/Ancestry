using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Models;

namespace Ancestry.Common.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int FatherId { get; set; }
        public PersonDto Father { get; set; }
        public int MotherId { get; set; }
        public PersonDto Mother { get; set; }
        public int PlaceId { get; set; }
        public PlaceDto Place { get; set; }
        public int Level { get; set; }



    }
}
