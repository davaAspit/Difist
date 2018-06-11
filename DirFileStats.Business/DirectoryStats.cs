using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirFileStats.Business
{
    public class DirectoryStats : BaseStats
    {
        private int numberOfFiles;
        private long directorySize;

        public DirectoryStats(string name, string path, int numberOfFiles, long directroySize) : base(name, path)
        {
            DirectorySize = directorySize;
            NumberOfFiles = numberOfFiles;
        }

        public int NumberOfFiles { get => numberOfFiles; set => numberOfFiles = value; }
        public long DirectorySize { get => directorySize; set => directorySize = value; }
    }
}
