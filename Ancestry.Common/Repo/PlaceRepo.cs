using System;
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
    public class PlaceRepo : IPlaceRepo
    {
        private readonly IPlaceStore _placeStore;

        public PlaceRepo(IPlaceStore placeStore, IOptions<DataFileSettings> options, IFileService fileService, IJsonService jsonService)
        {
            _placeStore = placeStore;

            var jsonText = fileService.GetFileContents(options.Value.PeopleJsonFilename);
            _placeStore.Data = jsonService.Parse<List<Place>>(jsonText);
        }

        public Place Get(int id)
        {
            return _placeStore.Data.FirstOrDefault(p => p.Id == id);
        }
    }

    public interface IPlaceRepo
    {
        Place Get(int id);
    }
}