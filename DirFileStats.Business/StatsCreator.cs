using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirFileStats.Business
{
    public static class StatsCreator
    {
        public static FileStats CreateFileStats(FileInfo fileInfo)
        {
            string fileExtension = fileInfo.Extension;
            string fileName = fileInfo.Name;
            long fileSize = fileInfo.Length;

            DateTime lastModified = File.GetLastWriteTime(fileName);
            DateTime fileCreated = File.GetCreationTime(fileName);

            FileStats fileStats = new FileStats(fileName, fileSize, fileExtension, lastModified, fileCreated);
            return fileStats;
        }

        public static DirectoryStats CreateDirectoryStats(DirectoryInfo directoryInfo, bool checkAllSubFolders= false)
        {
            string directoryName = directoryInfo.Name;
            var directoryFiles = directoryInfo.EnumerateFiles();

            if (checkAllSubFolders)
            {
                string[] files = Directory.GetFiles(directoryName, "*", SearchOption.AllDirectories);
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
