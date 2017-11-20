using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foosball_dll;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }

        public async void GetMatches()
        {
            List<string> matches = new List<string>();
            matches = await WriteReadData.ReadMatchesDataFromFileAsync();

            ListViewHistory.ItemsSource = new List<string>(matches);
        }
    }
}