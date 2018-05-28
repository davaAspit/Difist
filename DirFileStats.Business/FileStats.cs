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

        private DateTime lastModified;
        private DateTime fileCreated;

        public FileStats(string name, long fileSize, string fileExtension, DateTime lastModfied, DateTime fileCreate) : base(name)
        {
            FileSize = fileSize;
            FileExtension = fileExtension;
            lastModfied = LastModified;
            fileCreate = FileCreated;
        }

        public string FileExtension { get => fileExtension; set => fileExtension = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
        public DateTime LastModified { get => lastModified; set => lastModified = value; }
        public DateTime FileCreated { get => fileCreated; set => fileCreated = value; }
    }
}
