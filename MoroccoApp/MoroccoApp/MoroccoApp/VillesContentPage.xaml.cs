/*
 Programmeur : Ziad Biram
 date:          7 mai 2020
 Bute:          Projet1 Morocco app

 solution: MoroccoApp.sln
 Projet : MoroccoApp.csproj
 classe:  VillesContentPage.xaml.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoroccoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VillesContentPage : ContentPage
    {
        public VillesContentPage(string nom = "")
        {
            #region Controllers
            InitializeComponent();

            Label titreLabel = new Label
            {
                Text = "Villes Du Maroc",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red
            };

            Label villeQuestionLbl = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                Text = "LA villes de destination est :",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            Label villeReponceLbl = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Choisissez votre ville de destination:",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var options = new List<string> { "Casa Blanca", "Marakesh", "Agadir", "Fes", "Souira","Tanger", "Ifran" };
            foreach (string optionName in options)
            {
                picker.Items.Add(optionName);
            }

            picker.SelectedIndexChanged += (sender, args) =>
            {
                villeReponceLbl.Text = picker.Items[picker.SelectedIndex];
            };

            Button pagePrecedenteButton = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            Label nomLabel = new Label
            {
                BackgroundColor = Color.Red,
                TextColor = Color.Green,
                FontSize = 40,
                Text = "",
                HorizontalOptions = LayoutOptions.Center
            };
            #endregion

            #region stackLayout
            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    villeQuestionLbl,
                    villeReponceLbl,
                    picker,
                    pagePrecedenteButton,
                    nomLabel
                }
            };
            #endregion

        }

        #region Page Precedente
        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}