using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Models;
using Ancestry.Common.Repo;
using Ancestry.Common.Services;
using Ancestry.Common.Store;
using Castle.Components.DictionaryAdapter;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace Ancestry.Tests.Ancestry.Common.Repo
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
            Assert.True(result==null);
        }
    }
}
