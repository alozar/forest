using lesApp.Model;
using System.Collections.Generic;
using System.IO;
using lesApp.Model.Entities;

namespace lesApp.Service
{
    public class ParseService
    {
        public List<Quarter> Open(string filename)
        {
            var querters = new List<Quarter>();
            var lines = new List<string>();
            string line;
            using (StreamReader fs = new StreamReader(filename))
            {
                var forestFlag = false;
                
                while ((line = fs.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        forestFlag = true;
                        continue;
                    }
                    if (forestFlag)
                    {
                        forestFlag = false;
                        var forestArray = line.Split(' ');
                        lines.Add(line.Trim());
                    }
                }
            }
            return querters;
        }
    }
}
