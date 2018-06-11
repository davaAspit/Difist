using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DirFileStats.Business
{
    public abstract class BaseStats
    {
        private string name;

        private string path;

        protected BaseStats(string name, string path)
        {
            Path = path;
            Name = name;
        }

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
    }
}
