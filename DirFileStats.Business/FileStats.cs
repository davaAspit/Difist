using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirFileStats.Business
{
    public class FileStats : BaseStats
    {
        private string fileExtension;
        private long fileSize;

        public FileStats(string name, long fileSize, string fileExtension) : base(name)
        {
            FileSize = fileSize;
            FileExtension = fileExtension;
        }

        public string FileExtension { get => fileExtension; set => fileExtension = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
    }
}
