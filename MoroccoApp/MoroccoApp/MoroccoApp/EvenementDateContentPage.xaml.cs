/*
 Programmeur : Ziad Biram
 date:         7 mai 2020
 Bute:         Projet1 Morocco app

 solution: MoroccoApp.sln
 Projet : MoroccoApp.csproj
 classe:  EvenementDateContentPage.xaml.cs
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
    public partial class EvenementDateContentPage : ContentPage
    {
        #region variable
        string date;
        #endregion
        public EvenementDateContentPage(string nom = "")
        {
            #region controlers
            InitializeComponent();

            Label titreLabel = new Label
            {
                Text = "Évenement",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red

            };

            Label DateEvenementlbl = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                Text = "Date du prochain evennement:",
                FontSize = 30
            };
            Label DateChoisieLbl = new Label
            {
                BackgroundColor = Color.FromHex("EBEBEB"),
                TextColor = Color.FromHex("000B4F"),
                FontSize = 30
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            datePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
            {
                date = datePicker.Date.ToLongDateString();
                DateChoisieLbl.Text = date;
            };

            TimePicker timePicker = new TimePicker
            {
                Format = "T",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            timePicker.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
                {
                    DateChoisieLbl.Text = date +" "+ timePicker.Time.ToString();
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

            #region stacklayout
            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    DateEvenementlbl,
                    DateChoisieLbl,
                    datePicker,
                    timePicker,
                    pagePrecedenteButton,
                    nomLabel
                }
            };
            #endregion
        }

        #region page precedente
        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}