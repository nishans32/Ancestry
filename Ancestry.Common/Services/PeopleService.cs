using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ancestry.Common.Dtos;
using Ancestry.Common.Models;
using Ancestry.Common.Repo;

namespace Ancestry.Common.Services
{
    public class PeopleService: IPersonService
    {
        private readonly IPersonRepo _personRepo;
        private readonly IPlaceRepo _placeRepo;

        public PeopleService(IPersonRepo personRepo, IPlaceRepo placeRepo)
        {
            _personRepo = personRepo;
            _placeRepo = placeRepo;
        }

        public PersonDto Get(int id)
        {
            var person = _personRepo.Get(id);

            var mother = _personRepo.Get(person.MotherId);
            var father = _personRepo.Get(person.FatherId);
            var place = _placeRepo.Get(person.PlaceId);

            //Todo - use a mapper
            return new PersonDto()
            {
                Id = person.Id,
                Gender = person.Gender,
                Father = new PersonDto
                {
                    Name = father?.Name
                },
                Mother = new PersonDto
                {
                    Name = mother?.Name
                },
                Name = person.Name,
                Place = new PlaceDto
                {
                    Name = place?.Name
                },
                Level = person.Level
            };
        }

        public SearchResultDto<PersonDto> Search(string name, string gender, int index, int count)
        {
            //todo - Use a mapper
            var result = _personRepo.Search(new PersonSearchCriteria
            {
                Name = name,
                Gender = gender,
                Index = index,
                Count = count
            });

            return new SearchResultDto<PersonDto>
            {
                Results = result.Results.Select(person =>
                {
                    var mother = _personRepo.Get(person.MotherId);
                    var father = _personRepo.Get(person.FatherId);
                    var place = _placeRepo.Get(person.PlaceId);

                    return new PersonDto
                    {
                        Name = person.Name,
                        Id = person.Id,
                        Gender = person.Gender,
                        Level = person.Level,
                        Place = new PlaceDto
                        {
                            Name = place.Name
                        },
                        Father = new PersonDto
                        {
                            Name = father.Name
                        },
                        Mother = new PersonDto
                        {
                            Name = mother.Name
                        }
                    };
                }).ToList(),
                TotalCount = result.Count
            };
        }
    }

    public interface IPersonService
    {
        PersonDto Get(int id);
        SearchResultDto<PersonDto> Search(string name, string gender, int index, int count);
    }
}
