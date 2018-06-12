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

            FileStats fileStats = new FileStats(fileName, filePath, fileSize, fileExtension);
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

            long directorySize = 0;
            foreach (FileInfo fileInfo in directoryFiles)
            {
                directorySize += fileInfo.Length;
            }

            if (checkAllSubFolders)
            {
                string[] filesAndDirectories = Directory.GetFileSystemEntries(directoryPath, @"*", SearchOption.AllDirectories);
                int numberOfFiles = filesAndDirectories.Count();
                var files = RemoveDirectoriesFrom(filesAndDirectories);
                (long fileSize, int errors) = GetSizeOfFiles(files);
                directorySize += fileSize;
                DirectoryStats allFiles = new DirectoryStats(directoryName, directoryPath, numberOfFiles, directorySize);
                return allFiles;
            }
            directoryFiles.Count();
            DirectoryStats directoryStats = new DirectoryStats(directoryName, directoryPath, directoryFiles.Count(), directorySize);
            return directoryStats;
        }
        private static (long fileSize, int errors) GetSizeOfFiles(string[] files)
        {
            int errors = 0;
            long fileSize = 0;
            foreach (var file in files)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    fileSize += fileInfo.Length;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.FileName);
                    errors++;
                }
            }
            return (fileSize, errors);
        }
        private static string[] RemoveDirectoriesFrom(string[] filesAndDirectories)
        {
            List<string> files = new List<string>();

            foreach (var file in filesAndDirectories)
            {
                string[] splitFile = file.Split('\\');
                if (splitFile.Last().Contains(".") && splitFile.Last()[0] != '.')
                {
                    files.Add(file); 
                }
                else
                {

                }
            }
            return files.ToArray();
        }

    }
}
