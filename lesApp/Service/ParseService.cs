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
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
            }
            return forests;
        }
    }
}
