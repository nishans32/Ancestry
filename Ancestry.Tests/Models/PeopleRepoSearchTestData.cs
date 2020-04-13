using System.Collections.Generic;
using Ancestry.Common.Models;

namespace Ancestry.Tests.Models
{
    public class PeopleRepoSearchTestData
    {
        public SearchResult<Person> ExpectedResult { get; set; }
        public List<Person> EnforcedResult { get; set; }
        public PersonSearchCriteria SearchCriteria { get; set; }

    }
}