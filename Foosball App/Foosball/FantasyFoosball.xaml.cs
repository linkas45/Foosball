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
    public partial class FantasyFoosball : ContentPage
    {
        public FantasyFoosball()
        {
            InitializeComponent();
        }

        void OnMyTeamClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MyTeam());
        }

        void OnNewTeamClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NewTeam());
        }

        void OnRankingsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Rankings());
        }

        // Points counting

        public void attack()
        {
            //float ptsATK = goalsScored * 3;
        }

        public void midfield()
        {
            //float ptsMID = goalsScored * 4 + (10 - goalConceded) * 1;
        }

        public void defence()
        {
            //float ptsDEF = goalsScored * 4 + (10 - goalConceded) * 2;
        }

        public void goalkeeper()
        {
            //float ptsGOL = goalsScored * 4 + (10 - goalConceded) * 3;
        }

    }
}