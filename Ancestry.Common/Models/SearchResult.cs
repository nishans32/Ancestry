using System;
using System.Collections.Generic;
using System.Text;

namespace Ancestry.Common.Models
{
    public class SearchResult<T>
    {
        public List<T> Results { get; set; }
        public int Count { get; set; }
    }
}
