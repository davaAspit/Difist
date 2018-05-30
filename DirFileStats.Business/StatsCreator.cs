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
            string filePath = fileInfo.FullName;
            long fileSize = fileInfo.Length;

            DateTime lastModified = File.GetLastWriteTime(filePath);
            DateTime fileCreated = File.GetCreationTime(filePath);

            FileStats fileStats = new FileStats(fileName, filePath, fileSize, fileExtension, lastModified, fileCreated);
            return fileStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="checkAllSubFolders"></param>
        /// <returns>Returns a DirectoryStats object. IF the parameter directoryInfo is null, null will be returned.</returns>
        
        public static DirectoryStats CreateDirectoryStats(DirectoryInfo directoryInfo, bool checkAllSubFolders = false)
        {
            if (directoryInfo == null)
            {
                return null;
            }
            string directoryName = directoryInfo.Name;
            string directoryPath = directoryInfo.FullName;
            var directoryFiles = directoryInfo.EnumerateFiles();

            if (checkAllSubFolders)
            {
                string[] files = Directory.GetFileSystemEntries(directoryPath, @"*", SearchOption.AllDirectories);
                int numberOfFiles = files.Count();
                DirectoryStats allFiles = new DirectoryStats(directoryName, directoryPath, numberOfFiles);
                return allFiles;
            }
            directoryFiles.Count();
            DirectoryStats directoryStats = new DirectoryStats(directoryName, directoryPath, directoryFiles.Count());
            return directoryStats;
        }
    }
}
