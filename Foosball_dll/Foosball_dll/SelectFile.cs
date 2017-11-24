using PCLStorage;
using Foosball_dll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Foosball_dll
{
    class SelectFile : ISelectFile
    {
        
        public static string Folder { get; set; }
        public static string DataFile { get; set; }
        public static string HistoryFile { get; set; }


        public SelectFile()
        {
            Folder = "Data";
            DataFile = "Leaderboards.txt";
            HistoryFile = "History.txt";
        }

        //Get leaderboards file location and name for writing into
        public async Task<IFile> GetDataWrite()
        {

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync(DataFile, CreationCollisionOption.ReplaceExisting);

            return leaderboardsFile;
        }


        //Get leaderboards file location and name for reading from
        public async Task<IFile> GetDataRead()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync(DataFile, CreationCollisionOption.OpenIfExists);

            return leaderboardsFile;
        }


        //Get history file location and name for writing into
        public async Task<IFile> GetMatchesWrite()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile historyFile = await dataFolder.CreateFileAsync(HistoryFile, CreationCollisionOption.ReplaceExisting);

            return historyFile;
        }


        //Get history file location and name for reading from
        public async Task<IFile> GetMatchesRead()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile historyFile = await dataFolder.CreateFileAsync(HistoryFile, CreationCollisionOption.OpenIfExists);

            return historyFile;
        }


    }
}
