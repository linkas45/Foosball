using System;
using System.Collections.Generic;
using Foosball.Utils;

using Xamarin.Forms;

namespace Foosball
{
    public partial class History : ContentPage
    {
        public History()
        {
            this.Title = "History"; //Toolbar text
            getTeams();
        }

        public void Layouts(List<String> matches)
        {

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = matches,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    var matchLabel = new Label { VerticalTextAlignment = TextAlignment.Center };

                    //matchLabel.SetBinding(Label.TextProperty, "Standing");

                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });

                    grid.Children.Add(matchLabel);

                    return new ViewCell { View = grid };

                })
            };

            //Header template

            Grid header = new Grid();

            var standingHeader = new Label { Text = "Match" };

            header.ColumnDefinitions.Add(new ColumnDefinition { Width = 60 });
            header.Children.Add(standingHeader);


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

        async public void getTeams()
        {
            List<String> matches = new List<String>();
            matches = await WriteReadData.ReadMatchesDataFromFileAsync();

            Layouts(matches);
        }

    }

}
