﻿using System;
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
    public class PeopleRepo : IPeopleRepo
    {
        private readonly IPeopleStore _peopleStore;

        public PeopleRepo(IPeopleStore peopleStore, IFileService fileService, IJsonService jsonService, IOptions<DataFileSettings> options)
        {
            _peopleStore = peopleStore;

            if (_peopleStore.Data == null)
            {
                var jsonText = fileService.GetFileContents(options.Value.PeopleJsonFilename);
                _peopleStore.Data = jsonService.Parse<List<Person>>(jsonText);
            }
        }

        public Person Get(int id)
        {
            return _peopleStore.Data.FirstOrDefault(p => p.Id == id);
        }

        public SearchResult<Person> Search(PersonSearchCriteria searchCriteria)
        {
            var result = searchCriteria.Gender == null
                ? _peopleStore.Data.Where(p => p.Name == searchCriteria.Name).ToList()
                : _peopleStore.Data.Where(p =>
                    p.Name == searchCriteria.Name
                    && p.Gender == searchCriteria.Gender).ToList();

            return new SearchResult<Person>
            {
                Count = result.Count,
                Results = result.GetRange(searchCriteria.Index, searchCriteria.Count)
            };
        }
    }

    public interface IPeopleRepo
    {
        Person Get(int id);
        SearchResult<Person> Search(PersonSearchCriteria searchCriteria);
    }
}
