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

        public DirectoryStats(string name, int numberOfFiles) : base(name)
        {
            NumberOfFiles = numberOfFiles;
        }

        public int NumberOfFiles { get => numberOfFiles; set => numberOfFiles = value; }
    }
}
