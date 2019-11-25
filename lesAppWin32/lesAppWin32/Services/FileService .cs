using lesAppWin32.Model.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace lesAppWin32.Services
{
    public class FileService
    {
        public void Save(string filename, List<Quarter> quarters)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Quarter>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, quarters);
            }
        }

        public List<Quarter> Open(string filename)
        {
            var quarters = new List<Quarter>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Quarter>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                quarters = jsonFormatter.ReadObject(fs) as List<Quarter>;
            }
            return quarters;
        }
    }
}
