using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ancestry.Common.Dtos;
using Ancestry.Common.Models;
using Ancestry.Common.Services;
using Ancestry.Common.Store;
using Microsoft.Extensions.Options;

namespace Ancestry.Common.Repo
{
    public class PersonRepo : IPersonRepo
    {
        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResult<Person> Search(PersonSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPersonRepo
    {
        Person Get(int id);
        SearchResult<Person> Search(PersonSearchCriteria searchCriteria);
    }
}
