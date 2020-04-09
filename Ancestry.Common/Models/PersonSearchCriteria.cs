using System;
using System.Collections.Generic;
using System.Text;

namespace Ancestry.Common.Models
{
    public class PersonSearchCriteria: SeachCriteria
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
