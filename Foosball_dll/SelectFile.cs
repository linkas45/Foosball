using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Foosball_dll
{
    public class SelectFile
    {
        
        public static string Folder { get; set; } = "Data";
        public static string DataFile { get; set; } = "Leaderboards.txt";
        public static string HistoryFile { get; set; } = "History.txt";



        //Get leaderboards file location and name for writing into
        public static async Task<IFile> GetDataWrite()
        {

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync(DataFile, CreationCollisionOption.ReplaceExisting);

            return leaderboardsFile;
        }


        //Get leaderboards file location and name for reading from
        public static async Task<IFile> GetDataRead()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync(DataFile, CreationCollisionOption.OpenIfExists);

            return leaderboardsFile;
        }


        //Get history file location and name for writing into
        public static async Task<IFile> GetMatchesWrite()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile historyFile = await dataFolder.CreateFileAsync(HistoryFile, CreationCollisionOption.ReplaceExisting);

            return historyFile;
        }


        //Get history file location and name for reading from
        public static async Task<IFile> GetMatchesRead()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile historyFile = await dataFolder.CreateFileAsync(HistoryFile, CreationCollisionOption.OpenIfExists);

            return historyFile;
        }


    }
}
