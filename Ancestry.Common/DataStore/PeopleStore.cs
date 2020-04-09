using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Models;
using Ancestry.Common.Services;



namespace Ancestry.Common.Store
{
    public class PeopleStore : IPeopleStore
    {
        public List<Person> Data { get; set; }
    }

    public interface IPeopleStore
    {
        List<Person> Data { get; set; }
    }
}
