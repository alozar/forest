using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesApp.Model
{
    public interface IFileService
    {
        List<Forest> Open(string filename);
        void Save(string filename, List<Forest> forestList);
    }
}
