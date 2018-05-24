using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirFileStats.Business
{
    public static class StatsCreator
    {
        public static FileStats CreateFileStats(System.IO.FileInfo fileInfo)
        {
            //TODO: Extract the relevant info from the parameter and create a FileStats object 
            string fileExtension = fileInfo.Extension;
            string fileName = fileInfo.Name;
            long fileSize = fileInfo.Length;

            FileStats fileStats = new FileStats(fileName, fileSize, fileExtension);
            return fileStats;     
        }

        public static DirectoryStats CreateDirectoryStats(System.IO.DirectoryInfo directoryInfo)
        {
            //TODO: Extract the relevant info from the parameter and create a DirectoryStats object
            throw new NotImplementedException();
        }
    }
}
