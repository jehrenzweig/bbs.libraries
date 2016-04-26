using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Contracts
{
    public interface IFileManipulator
    {
        Stream Open(string fullFileName);
        void WriteFile(string fullFileName, byte[] bytes, bool createNewFile = true);
        void WriteFile(string fullFileName, MemoryStream bytes, bool createNewFile = true);
    }
}
