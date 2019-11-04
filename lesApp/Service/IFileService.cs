using System.Collections.Generic;
using lesApp.Model.Entities;

namespace lesApp.Service
{
    public interface IFileService
    {
        List<Quarter> Open(string filename);
        void Save(string filename, List<Quarter> quarters);
    }
}
