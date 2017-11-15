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

            test();

            

        }
        // Temporary button to erase leaderboards
        public static async Task test()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder dataFolder = await rootFolder.CreateFolderAsync("Data", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);
            IFile leaderboardsFile = await dataFolder.CreateFileAsync("Leaderboards.txt", CreationCollisionOption.ReplaceExisting);
        }
    }
}
