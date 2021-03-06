﻿using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using DirFileStats.Business;
using System.Drawing;

namespace DirFileStats.UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DirectoryInfo dirInfo;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog()
            {
                Title = "Vælg en fil",
                IsFolderPicker = false,
                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // TODO:
                // Show the path (found in dlg.FileName) in the correct textbox so the user can see what was chosen
                tbxFilePath.Text = dlg.FileName;
                FileInfo fileInfo = new FileInfo(dlg.FileName);
                cbxAdvSearch.IsEnabled = false;
                cbxModUTC.IsEnabled = true;

                // TODO:
                // Use the fileInfo to create a FileStats object and show the relevant data for the user
                FileStats fileStats = StatsCreator.CreateFileStats(fileInfo);
                lblName.Content = fileStats.Name;
                lblType.Content = "File";

                CalculateSize(fileStats.FileSize);

                lblCreationTime.Content = fileStats.FileCreated;
                lblLastModified.Content = fileStats.LastModified;
                
                lblFileExtension.Content = fileStats.FileExtension;


                wpFileCount.Visibility = Visibility.Collapsed;
                wpFileExtension.Visibility = Visibility.Visible;
                cbxAdvSearch.IsChecked = false;
                wpLastModified.Visibility = Visibility.Visible;
                wpCreationTime.Visibility = Visibility.Visible;
                

                imgIcon.Source = BitmapToImageSource(fileStats.GetBitmap());   
            }
        }
        private double CalculateSize(double size)
        {
            const long kb = 1024;
            const long mb = 1048576;
            const long gb = 1073741824;

            if (size < kb)
            {
                lblFileSize.Content = size;
                lblDataSize.Content = "Byte";
            }
            else if (size < mb)
            {
                size = size / kb;
                lblFileSize.Content = size.ToString("N2");
                lblDataSize.Content = "KBs";
            }
            else if (size < gb)
            {
                size = size / mb;
                lblFileSize.Content = size.ToString("N");
                lblDataSize.Content = "MBs";
            }
            else
            {
                size = size / gb;
                lblFileSize.Content = size.ToString("N");
                lblDataSize.Content = "GBs";
            }
            return size;
        }
        private void btnChooseDir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog()
            {
                Title = "Vælg en mappe",
                IsFolderPicker = true,
                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // TODO:
                // Show the path (found in dlg.FileName) in the correct textbox so the user can see what was chosen
                tbxDirPath.Text = dlg.FileName;
                cbxAdvSearch.IsEnabled = true;
                cbxModUTC.IsEnabled = false;

                dirInfo = new DirectoryInfo(dlg.FileName);

                // TODO:
                // Use the dirInfo to create a DirectoryStats object and show the relevant data for the user
                DirectoryStats directoryStats = StatsCreator.CreateDirectoryStats(dirInfo, cbxAdvSearch.IsChecked.Value);

                lblName.Content = directoryStats.Name;
                lblType.Content = "Directory";

                CalculateSize(directoryStats.DirectorySize); //TODO: Needs to be fixed

                lblFileExtension.Content = "n/a";
                imgIcon.Source = new BitmapImage(new Uri("Images/folder.png", UriKind.Relative));
                wpFileCount.Visibility = Visibility.Visible;
                wpFileExtension.Visibility = Visibility.Collapsed;
                wpCreationTime.Visibility = Visibility.Collapsed;
                wpLastModified.Visibility = Visibility.Collapsed;
                cbxModUTC.IsChecked = false;

            }
        }
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void cbxAdvSearch_Click(object sender, RoutedEventArgs e)
        {
            //lblFileCount.Content = "Number of folders and files in Directory";
            
            DirectoryStats directoryStats = StatsCreator.CreateDirectoryStats(dirInfo, cbxAdvSearch.IsChecked.Value);
            CalculateSize(directoryStats.DirectorySize);
            lblNumberOfFiles.Content = directoryStats.NumberOfFiles;
        }

        private void cbxModUTC_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(tbxFilePath.Text);
            FileStats directoryStats = StatsCreator.CreateFileStats(fileInfo);
            if (cbxModUTC.IsChecked == true)
            {
                lblLastModified.Content = directoryStats.LastModifiedUTC;
                lblCreationTime.Content = directoryStats.FileCreatedUTC;
            }
            else if(cbxModUTC.IsChecked == false)
            {
                lblLastModified.Content = directoryStats.LastModified;
                lblCreationTime.Content = directoryStats.FileCreated;
            }
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            Options optionsWindow = new Options();
            optionsWindow.Show();
        }
    }
}
