using System;

using Xamarin.Forms;

namespace Foosball
{
    public class NewGame : ContentPage
    {
        public NewGame()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

