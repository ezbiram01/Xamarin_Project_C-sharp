/*
 Programmeur : Ziad Biram
 date:          7 mai 2020
 Bute:          Projet1 Morocco app

 solution: MoroccoApp.sln
 Projet : MoroccoApp.csproj
 classe:  RepasPrixContentPage.xaml.cs
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
    public partial class RepasPrixContentPage : ContentPage
    {
        public RepasPrixContentPage(string nom = "")
        {
            #region Controllers
            InitializeComponent();

            Label titreLabel = new Label
            {
                Text = "Repas",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red

            };

            Label lblPrixRepas = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                Text = "Prix Repas:",
                FontSize = 30,
            };

            Entry repatEntry = new Entry
            {
                //VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,
                FontSize = 30,
                TextColor = Color.FromHex("000B4F")
            };

            Label lbltaxe = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                Text = "Prix Repas:",
                FontSize = 30,
            };

            Entry taxeEntry = new Entry
            {
                //VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,
                FontSize = 30,
                TextColor = Color.FromHex("000B4F")
            };

            Button calculeButton = new Button
            {
                FontSize = 20,
                Text = "calculer le Prix totale",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            Label resultLabel = new Label
            {
                FontSize = 30,
                TextColor = Color.FromHex("000B4F")
            };

            calculeButton.Clicked += async (sender, args) =>
            {
                double repas;
                double taxe;
                try
                {
                    double.TryParse(repatEntry.Text,out repas);
                    double.TryParse(taxeEntry.Text,out taxe);
                    resultLabel.Text = (repas * taxe).ToString() + "$";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erreur", ex.ToString(), "Annulé");
                }
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
                Text = nom,
                HorizontalOptions = LayoutOptions.Center
            };
            #endregion

            #region StackLayout
            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    lblPrixRepas,
                    repatEntry,
                    lbltaxe,
                    taxeEntry,
                    calculeButton,
                    resultLabel,
                    pagePrecedenteButton,
                    nomLabel
                }
            };
            #endregion
        }

        #region Page Precedente Button
        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}