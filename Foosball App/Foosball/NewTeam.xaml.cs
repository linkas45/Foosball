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
    public partial class NewTeam : ContentPage
    {
        public NewTeam()
        {
            InitializeComponent();
        }

        public void Squad(string[] args)
        {
            string[] Team = new string[4];

            var layout1 = new StackLayout { Padding = new Thickness(5, 10) };
            var label1 = new Label { Text = "Chose your goalkeeper" };
            layout1.Children.Add(label1);
            var goalkeeper = new System.Text;

            var layout2 = new StackLayout { Padding = new Thickness(5, 10) };
            var label2 = new Label { Text = "Chose your defense" };
            layout2.Children.Add(label2);
            var defense = new System.Text;

            var layout3 = new StackLayout { Padding = new Thickness(5, 10) };
            var label3 = new Label { Text = "Chose your midfield" };
            layout3.Children.Add(label3);
            var midfield = new System.Text;

            var layout4 = new StackLayout { Padding = new Thickness(5, 10) };
            var label4 = new Label { Text = "Chose your attack" };
            layout4.Children.Add(label4);
            var attack = new System.Text;
        }
    }
}