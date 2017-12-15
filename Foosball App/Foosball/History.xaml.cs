using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Foosball_dll.Utils;
using Foosball_dll.Interfaces;
using Foosball_dll;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        private IWriteReadData _data = new WriteReadData();
        public History()
        {
            this.Title = "History";
            GetMatches();
        }

        public History(Team team)
        {
            this.Title = team.TeamName + " History";
            GetPlayerMatches(team);
        }

        public void Layouts(List<MatchInfo> Matches)
        {


            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = Matches,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    var standingLabel = new Label { VerticalTextAlignment = TextAlignment.Center };
                    var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center };
                    var scoreLabel = new Label { VerticalTextAlignment = TextAlignment.Center };

                    standingLabel.SetBinding(Label.TextProperty, "Team1Name");
                    nameLabel.SetBinding(Label.TextProperty, "Team2Name");
                    scoreLabel.SetBinding(Label.TextProperty, "Score");

                    grid.Children.Add(standingLabel);
                    grid.Children.Add(nameLabel, 1, 0);
                    grid.Children.Add(scoreLabel, 2, 0);

                    return new ViewCell { View = grid };

                })
            };

            //Header template

            Grid header = new Grid();

            var team1NameHeader = new Label { Text = "Team1", FontAttributes = FontAttributes.Bold };
            var team2NameHeader = new Label { Text = "Team2", FontAttributes = FontAttributes.Bold };
            var scoreHeader = new Label { Text = "Score", FontAttributes = FontAttributes.Bold };

            header.Children.Add(team1NameHeader);
            header.Children.Add(team2NameHeader, 1, 0);
            header.Children.Add(scoreHeader, 2, 0);


            // Build the page.
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    header,
                    listView
                }
            };
        }

        public async void GetMatches()
        {
            List<MatchInfo> matches = new List<MatchInfo>();
            matches = await _data.ReadMatchesDataFromFileAsync();
            Layouts(matches);

        }

        public async void GetPlayerMatches(Team team)
        {
            List<MatchInfo> matches = new List<MatchInfo>();
            List<MatchInfo> teamMatches = new List<MatchInfo>();
            matches = await _data.ReadMatchesDataFromFileAsync();

            foreach (MatchInfo match in matches)
            {
                if (match.Team1Name.Equals(team.TeamName) || match.Team2Name.Equals(team.TeamName))
                {
                    teamMatches.Add(match);
                }
            }
            Layouts(teamMatches);
        }
    }
}