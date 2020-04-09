using System.IO;
using Ancestry.Common.Models;

namespace Ancestry.Common.Services
{
    public interface IFileService
    {
        string GetFileContents(string fileLocation);
        void WriteContentsToFile(string fileLocation, string contents);
    }

    public class FileService : IFileService
    {
        public string GetFileContents(string fileLocation)
        {
            return File.ReadAllText(fileLocation);
        }

        public void WriteContentsToFile(string fileLocation, string contents)
        {
            File.WriteAllText(fileLocation, contents);
        }
    }
}