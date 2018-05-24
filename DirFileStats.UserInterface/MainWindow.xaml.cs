using Microsoft.WindowsAPICodePack.Dialogs;
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
namespace DirFileStats.UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog()
            {
                Title = "Vælg en mappe eller fil",
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

                // TODO:
                // Use the fileInfo to create a FileStats object and show the relevant data for the user
                FileStats fileStats = StatsCreator.CreateFileStats(fileInfo);
                lblName.Content = fileStats.Name;
                lblFileSize.Content = fileStats.FileSize;
                lblFileExtension.Content = fileStats.FileExtension;
                
            }


        }

        private void btnChooseDir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog()
            {
                Title = "Vælg en mappe eller fil",
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

                DirectoryInfo dirInfo = new DirectoryInfo(dlg.FileName);

                // TODO:
                // Use the dirInfo to create a DirectoryStats object and show the relevant data for the user
            }


        }
    }
}
