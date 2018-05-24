using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirFileStats.Business
{
    abstract class BaseStats
    {
        private string name;

        protected BaseStats(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
