using System.Collections.Generic;
using lesApp.Model;

namespace lesApp.Service
{
    public interface IFileService
    {
        List<Forest> Open(string filename);
        void Save(string filename, List<Forest> forestList);
    }
}
