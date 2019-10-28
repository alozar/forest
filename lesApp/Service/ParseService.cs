using lesApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesApp.Service
{
    public class ParseService
    {
        public List<Forest> Open(string filename)
        {
            List<Forest> forests = new List<Forest>();
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
            return forests;
        }
    }
}
