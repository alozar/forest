using lesApp.Model;
using System.Collections.Generic;
using System.IO;
using lesApp.Model.Entities;
using System.Linq;

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
                    var indQuarter = line.IndexOf("Квартал:");
                    if (indQuarter != -1)
                    {
                        var numberQuarterStr = line.Substring(indQuarter).Split(' ')[1];
                        int numQuarter;
                        if (int.TryParse(numberQuarterStr, out numQuarter) &&
                            !querters.Exists(q => q.Number == numQuarter))
                        {
                            querters.Add(new Quarter(numQuarter));
                        }
                    }
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        forestFlag = true;
                        continue;
                    }
                    if (forestFlag)
                    {
                        forestFlag = false;
                        var sectionArrParam = line.Split(' ');
                        int numSection;
                        if (int.TryParse(sectionArrParam[0], out numSection) &&
                            !querters.Last().Sections.Exists(q => q.Number == numSection))
                        {
                            querters.Last().Sections.Add(GetSection(numSection, sectionArrParam));
                        }
                    }
                }
            }
            return querters;
        }

        private Section GetSection(int numSection, string[] sectionArrParam)
        {
            var section = new Section(numSection);
            
            return section;
        }
    }
}
