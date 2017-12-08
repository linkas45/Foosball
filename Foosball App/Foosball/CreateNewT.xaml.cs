using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Foosball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNewT : ContentPage
    {
        public CreateNewT()
        {
            InitializeComponent();
        }

        public void Creation(string[] args)
        {
            string[] TeamNames = new string[8];
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            var label = new Label{ Text = "Write down the names of 8 teams" };
            layout.Children.Add(label);
            for (int i = 0; i > 8; i++)
            {

            }

        }
    }
}