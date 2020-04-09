using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Ancestry.Common.Services
{
    public class JsonService : IJsonService
    {
        public T Parse<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public string SerializeObject<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }

    public interface IJsonService
    {
        T Parse<T>(string jsonfileLoc);
        string SerializeObject<T>(T input);
    }
}