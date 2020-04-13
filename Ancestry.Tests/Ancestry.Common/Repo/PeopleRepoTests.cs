using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Models;
using Ancestry.Common.Repo;
using Ancestry.Common.Services;
using Ancestry.Common.Store;
using Ancestry.Tests.Models;
using Ancestry.Tests.Services;
using Castle.Components.DictionaryAdapter;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.Routing.Handlers;
using Xunit;
using Xunit.Sdk;


namespace Ancestry.Tests.Common.Repo
{
    public class PeopleRepoTests
    {
        private IPeopleRepo _peopleRepo;
        private readonly IPeopleStore _peopleStore;
        private readonly IFileService _fileService;
        private readonly IJsonService _jsonService;

        public PeopleRepoTests()
        {
            _peopleStore = Substitute.For<IPeopleStore>();
            _fileService = Substitute.For<IFileService>();
            _jsonService = Substitute.For<IJsonService>();

            _peopleRepo = new PeopleRepo(_peopleStore, _fileService, _jsonService, Options.Create(new DataFileSettings()));
        }
        [Fact]
        public void GetPerson_IncorrectInput_ReturnsNull()
        {
            //Arrange
            _peopleStore.Data.Returns(new EditableList<Person>
            {
                new Person
                {
                    Id = 2
                }
            });

            //Act
            var result = _peopleRepo.Get(1);

            //Assert
            Assert.True(result==null);
        }

        [Fact]
        public void GetPerson_CorrectInput_ReturnsValidobject()
        {
            //Arrange
            _peopleStore.Data.Returns(new EditableList<Person>
            {
                new Person()
                {
                    Id = 1
                }
            });

            //Act
            var result = _peopleRepo.Get(1);

            //Assert
            Assert.True(result!= null);
            Assert.True(result?.Id == 1);
        }

        [Fact]
        public void SearchPerson_IncorrectName_returnsNull()
        {
            //Arrange
            SearchResult<Person> expectedResult = null;

            _peopleStore.Data.Returns(new EditableList<Person>
            {
                new Person
                {
                    Name = "Test Person Name"
                }
            });

            //Act
            var result = _peopleRepo.Search(new PersonSearchCriteria
            {
                Name = "Test Name"
            });

            //Assert
            Assert.True(result==expectedResult);
        }

        [Theory]
        [MemberData(nameof(GetPersonSearchTestData))]
        public void SearchPerson_Parameters_FilterCorrectly(PeopleRepoSearchTestData testData)
        {
            //Arrange
            var expectedResult = testData.ExpectedResult;

            _peopleStore.Data.Returns(testData.EnforcedResult);

            //Act
            var result = _peopleRepo.Search(testData.SearchCriteria);
            
            //Assert
            Assert.True(expectedResult.Count == result.Count);

        }

        public static IEnumerable<object[]> GetPersonSearchTestData()
        {
            return TestDataProvider.GetPersonRepoSearchTestData();
        }




    }
}
