﻿using System;
using System.Collections.Generic;
using Foosball_dll;

using Xamarin.Forms;
using System.Diagnostics;
using Foosball_dll.Utils;

namespace Foosball
{
    public partial class LeaderBoards : ContentPage
    {

        public LeaderBoards()
        {
            this.Title = "Leaderboards"; //Toolbar text
            GetTeams();
        }

        public void Layouts(List<Team> teams) {


            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = teams,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    var standingLabel = new Label { VerticalTextAlignment = TextAlignment.Center };
                    var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center };
                    var scoreLabel = new Label{VerticalTextAlignment = TextAlignment.Center };

                    standingLabel.SetBinding(Label.TextProperty, "Standing");
                    nameLabel.SetBinding(Label.TextProperty, "TeamName");
                    scoreLabel.SetBinding(Label.TextProperty, "GlobalScore");

                    grid.ColumnDefinitions.Add(new ColumnDefinition {Width = 30 });

                    grid.Children.Add(standingLabel);
                    grid.Children.Add(nameLabel, 1, 0);
                    grid.Children.Add(scoreLabel, 2, 0);

                    return new ViewCell { View = grid };

                })
            };

            //Header template

            Grid header = new Grid();

            var standingHeader = new Label { Text = "#" };
            var nameHeader = new Label { Text = "Team name" };
            var scoreHeader = new Label { Text = "Score" };

            header.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });

            header.Children.Add(standingHeader);
            header.Children.Add(nameHeader, 1, 0);
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

        async public void GetTeams()
        {
            List<Team> teams = new List<Team>();
            teams = await WriteReadData.ReadTeamsDataFromFileAsync();


            int i = 1;
            foreach(Team team in teams)
            {
                team.Standing = i;
                i++;
            }
             Layouts(teams);
        }

    }
}
