using lesApp.Model;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace lesApp.Service
{
    public class FileService : IFileService
    {
        public void Save(string filename, List<Forest> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Forest>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }

        public List<Forest> Open(string filename)
        {
            List<Forest> forests = new List<Forest>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Forest>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                forests = jsonFormatter.ReadObject(fs) as List<Forest>;
            }
            return forests;
        }
    }
}
