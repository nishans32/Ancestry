using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common;
using Ancestry.Common.Dtos;
using Ancestry.Common.Models;
using Ancestry.Common.Repo;
using Ancestry.Common.Services;
using Ancestry.Tests.Models;
using NSubstitute;
using Xunit;

namespace Ancestry.Tests.Services
{
    public class PeopleServiceTests
    {
        private readonly PeopleService _peopleService;
        private readonly IPlaceRepo _placeRepo;
        private readonly IPeopleRepo _peopleRepo;

        public PeopleServiceTests()
        {
            _peopleRepo = Substitute.For<IPeopleRepo>();
            _placeRepo = Substitute.For<IPlaceRepo>();

            _peopleService = new PeopleService(_peopleRepo, _placeRepo);
        }
        [Fact]
        public void GetPerson_ValidId_ReturnsCorrectObject()
        {
            //Arrange
            var expectedResult = new PersonDto
            {
                Name = "Harry Potter",
                Id = 3,
                Father = new PersonDto()
                {
                    Name = "James Potter",
                    Id = 1
                },
                Mother = new PersonDto()
                {
                    Name = "Lily Potter",
                    Id = 2
                },
                Place = new PlaceDto()
                {
                    Name = "Hogwarths",
                    Id = 1
                }
            };

            _peopleRepo.Get(Arg.Is<int>(id => id == 1)).Returns(new Person
            {
                Name = "James Potter",
                Id = 1
            });

            _peopleRepo.Get(Arg.Is<int>(id => id == 2)).Returns(new Person
            {
                Name = "Lily Potter",
                Id = 2
            });

            _peopleRepo.Get(Arg.Is<int>(id => id == 3)).Returns(new Person
            {
                Name = "Harry Potter",
                Id = 3,
                FatherId = 1,
                MotherId = 2,
                PlaceId = 1
            });

            _placeRepo.Get(Arg.Is<int>(id => id == 1)).Returns(new Place
            {
                Name = "Hogwarths",
                Id = 1
            });

            //Act

            var result = _peopleService.Get(expectedResult.Id);

            //Assert

            Assert.True(result?.Name  == expectedResult.Name);
            Assert.True(result?.Id == expectedResult.Id);

            Assert.True(result?.Father?.Name == expectedResult.Father.Name);
            Assert.True(result?.Mother?.Name == expectedResult.Mother.Name);
        }
        [Theory]
        [MemberData(nameof(GetPeopleServiceSearchTestData))]
        public void SearchPerson_ValidParameters_ReturnsCorrectResults(PeopleServiceSearchTestData testData)
        {
            //Arrange
            var expectedResult = testData.ExpectedResult;

            foreach (var person in testData.EnforcedParentResults)
            {
                _peopleRepo.Get(Arg.Is<int>(id => id == person.Id)).Returns(person);
            }

            _peopleRepo.Search(Arg.Is<PersonSearchCriteria>(c => c.Name == testData.SearchCriteria.Name))
                .Returns(testData.EnforcedResult);

            //Act
            var actualResult = _peopleService.Search(testData.SearchCriteria.Name, testData.SearchCriteria.Gender, 0, 10);
            
            //Assert
            Assert.True(expectedResult.Count == actualResult.TotalCount);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.True(expectedResult.Results[i].Name == actualResult?.Results[i]?.Name);
                Assert.True(expectedResult.Results[i].Father.Name == actualResult?.Results[i]?.Father?.Name);
                Assert.True(expectedResult.Results[i].Mother.Name == actualResult?.Results[i]?.Mother?.Name);
            }
        }

        public static IEnumerable<object[]> GetPeopleServiceSearchTestData()
        {
            return TestDataProvider.GetPersonServiceSearchTestData();
        }

    }
}
