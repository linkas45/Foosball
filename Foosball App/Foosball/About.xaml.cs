using PCLStorage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foosball
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();

            Test();

        }

        public async void Test()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync("Data", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync("Leaderboards.txt", CreationCollisionOption.ReplaceExisting);
            IFile historyFile = await dataFolder.CreateFileAsync("History.txt", CreationCollisionOption.ReplaceExisting);

        }
    }
}
