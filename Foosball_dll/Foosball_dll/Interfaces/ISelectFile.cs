using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_dll.Interfaces
{
    public interface ISelectFile
    {
        Task<IFile> GetDataWrite();
        Task<IFile> GetDataRead();
        Task<IFile> GetMatchesWrite();
        Task<IFile> GetMatchesRead();
    }
}
