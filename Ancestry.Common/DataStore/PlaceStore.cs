using System;
using System.Collections.Generic;
using System.Text;
using Ancestry.Common.Models;

namespace Ancestry.Common.Store
{
    //todo - Possible duplication with People store. Use generics to unify them
    public class PlaceStore: IPlaceStore
    {
        public List<Place> Data { get; set; }
    }

    public interface IPlaceStore
    {
        List<Place> Data { get; set; }
    }
}
