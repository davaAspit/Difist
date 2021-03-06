﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        
        private DateTime lastModifiedUTC;
        private DateTime fileCreatedUTC;

        public FileStats(string name, string path, long fileSize, string fileExtension, DateTime lastModified, DateTime fileCreated, DateTime lastModifiedUTC , DateTime fileCreatedUTC) : base(name, path)
        {
            FileSize = fileSize;
            FileExtension = fileExtension;
            LastModified = lastModified;
            FileCreated = fileCreated;
            LastModifiedUTC = lastModifiedUTC;
            FileCreatedUTC = fileCreatedUTC;
        }
        public Bitmap GetBitmap()
        {
            Icon fileIcon = Icon.ExtractAssociatedIcon(Path);
            Bitmap bitMap = fileIcon.ToBitmap();
            return bitMap;
        }
        public string FileExtension { get => fileExtension; set => fileExtension = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
        public DateTime LastModified { get => lastModified; set => lastModified = value; }
        public DateTime FileCreated { get => fileCreated; set => fileCreated = value; }
        public DateTime LastModifiedUTC { get => lastModifiedUTC; set => lastModifiedUTC = value; }
        public DateTime FileCreatedUTC { get => fileCreatedUTC; set => fileCreatedUTC = value; }
    }
}
