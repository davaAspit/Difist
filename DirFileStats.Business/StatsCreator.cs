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
            string fileExtension = fileInfo.Extension;
            string fileName = fileInfo.Name;
            long fileSize = fileInfo.Length;

            FileStats fileStats = new FileStats(fileName, fileSize, fileExtension);
            return fileStats;
        }

        public static DirectoryStats CreateDirectoryStats(System.IO.DirectoryInfo directoryInfo, bool checkAllSubFolders= false)
        {
            string directoryName = directoryInfo.Name;
            var directoryFiles = directoryInfo.EnumerateFiles();

            if (checkAllSubFolders)
            {
                string[] files = System.IO.Directory.GetFiles(directoryName, "*", System.IO.SearchOption.AllDirectories);
                int numberOfFiles = files.Count();
                DirectoryStats allFiles = new DirectoryStats(directoryName, numberOfFiles);
                return allFiles;
            }
            directoryFiles.Count();
            DirectoryStats directoryStats = new DirectoryStats(directoryName, directoryFiles.Count());
            return directoryStats;
        }
    }
}
