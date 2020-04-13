using System.Collections.Generic;
using Ancestry.Common.Dtos;
using Ancestry.Common.Models;

namespace Ancestry.Tests.Models
{
    public class PeopleServiceSearchTestData
    {
        public SearchResult<PersonDto> ExpectedResult { get; set; }
        public SearchResult<Person> EnforcedResult { get; set; }
        public List<Person> EnforcedParentResults { get; set; }
        public PersonSearchCriteria SearchCriteria { get; set; }

    }
}