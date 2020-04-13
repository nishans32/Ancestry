using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Dtos;
using Ancestry.Common.Models;
using Ancestry.Tests.Models;

namespace Ancestry.Tests.Services
{
    public static class TestDataProvider
    {
        public static IEnumerable<object[]> GetPersonRepoSearchTestData()
        {
            yield return new object[]
            {
                new PeopleRepoSearchTestData
                {
                    EnforcedResult = new List<Person>
                    {
                        new Person
                        {
                            Id = 1,
                            Name = "Harry Potter",
                            Gender = "M"
                        },
                        new Person()
                        {
                            Id = 2,
                            Name = "Harriett Scott",
                            Gender = "F"
                        },
                        new Person()
                        {
                            Id = 3,
                            Name = "Hermione Jean Granger",
                            Gender = "F"
                        }
                    },
                    ExpectedResult = new SearchResult<Person>
                    {
                        Results = new List<Person>
                        {
                            new Person
                            {
                                Id = 1,
                                Name = "Harry",
                                Gender = "M"
                            },
                            new Person()
                            {
                                Id = 2,
                                Name = "Harriett",
                                Gender = "F"
                            }
                        },
                        Count = 2
                    },
                    SearchCriteria = new PersonSearchCriteria
                    {
                        Name = "Harr",
                        Gender = "",
                        Index = 0,
                        Count = 1
                    }
                }
            };
            yield return new object[]
            {
                new PeopleRepoSearchTestData
                {
                    EnforcedResult = new List<Person>
                    {
                        new Person
                        {
                            Id = 1,
                            Name = "Harry Potter",
                            Gender = "M"
                        },
                        new Person()
                        {
                            Id = 2,
                            Name = "Harriett Scott",
                            Gender = "F"
                        },
                        new Person()
                        {
                            Id = 3,
                            Name = "Harry Puthra",
                            Gender = "M"
                        }
                    },
                    ExpectedResult = new SearchResult<Person>
                    {
                        Results = new List<Person>
                        {
                            new Person
                            {
                                Id = 1,
                                Name = "Harry Potter",
                                Gender = "M"
                            },
                            new Person()
                            {
                                Id = 3,
                                Name = "Harry Puthra",
                                Gender = "M"
                            }
                        },
                        Count = 2
                    },
                    SearchCriteria = new PersonSearchCriteria
                    {
                        Name = "Harr",
                        Gender = "M",
                        Index = 0,
                        Count = 5
                    }
                }
            };

        }

        public static IEnumerable<object[]> GetPersonServiceSearchTestData()
        {
            yield return new object[]
            {
                new PeopleServiceSearchTestData
                {
                    ExpectedResult = new SearchResult<PersonDto>
                    {
                        Count = 2,
                        Results = new List<PersonDto>
                        {
                            new PersonDto()
                            {
                                Name = "Harry Potter",
                                Id = 3,
                                Father = new PersonDto
                                {
                                    Name = "James Potter",
                                    Id = 1
                                },
                                Mother = new PersonDto
                                {
                                    Name = "Lily Potter",
                                    Id = 2
                                },
                                Place = new PlaceDto
                                {
                                    Name = "Hogwarths",
                                    Id = 1
                                }
                            },
                            new PersonDto()
                            {
                                Name = "Harriet Scott",
                                Id = 6,
                                Father = new PersonDto
                                {
                                    Name = "Timothy Scott",
                                    Id = 4
                                },
                                Mother = new PersonDto
                                {
                                    Name = "Margeret Scott",
                                    Id = 5
                                },
                                Place = new PlaceDto
                                {
                                    Name = "Wandsworth",
                                    Id = 2
                                }
                            }

                        }
                    },
                    EnforcedResult = new SearchResult<Person>
                    {
                        Count = 2,
                        Results = new List<Person>
                        {
                            new Person
                            {
                                Name = "Harry Potter",
                                Id = 3,
                                FatherId = 1,
                                MotherId = 2
                            },
                            new Person
                            {
                                Name = "Harriet Scott",
                                Id = 6,
                                FatherId = 4,
                                MotherId = 5
                            },
                        }
                    },
                    SearchCriteria = new PersonSearchCriteria
                    {
                        Name = "Harr",
                        Gender = "m"
                    },
                    EnforcedParentResults = new List<Person>
                    {
                        new Person
                        {
                            Name = "James Potter",
                            Id = 1,
                        },
                        new Person
                        {
                            Name = "Lily Potter",
                            Id = 2,
                        },
                        new Person
                        {
                            Name = "Timothy Scott",
                            Id = 4
                        },
                        new Person
                        {
                            Name = "Margeret Scott",
                            Id = 5
                        }

                    }
                }

            };
        }
    }
}
