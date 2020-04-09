using System;
using System.Collections.Generic;
using System.Text;

namespace Ancestry.Common.Services
{
    public class PeopleService: IPersonService
    {
        public PersonDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResultDto<PersonDto> Search(string name, string gender, int index, int count)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPersonService
    {
        PersonDto Get(int id);
        SearchResultDto<PersonDto> Search(string name, string gender, int index, int count);
    }
}
