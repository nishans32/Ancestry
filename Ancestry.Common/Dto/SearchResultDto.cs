using System;
using System.Collections.Generic;
using System.Text;

namespace Ancestry.Common.Dtos
{
    public class SearchResultDto<T>
    {
        public List<T> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
