using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tournament : ContentPage
    {
        public Tournament()
        {
            InitializeComponent();

        }


        void OnCreateNewClicked(object sender, EventArgs args)
        {
                Navigation.PushAsync(new CreateNewT());
        }

        void OnStandingsClicked(object sender, EventArgs args)
        {
                Navigation.PushAsync(new Standings());
        }
    }
}