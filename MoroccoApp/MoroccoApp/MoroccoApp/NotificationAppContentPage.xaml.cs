/*
 Programmeur : Ziad Biram
 date:          7 mai 2020
 Bute:          Projet1 Morocco app

 solution: MoroccoApp.sln
 Projet : MoroccoApp.csproj
 classe:  NotificationAppContentPage.xaml.cs
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
    public partial class NotificationAppContentPage : ContentPage
    {
        public NotificationAppContentPage(string nom = "")
        {
            #region controlers
            InitializeComponent();

            Label titreLabel = new Label
            {
                Text = "Notification",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red

            };

            Label lblAfficherNotifQuest = new Label
            {
                BackgroundColor = Color.Gold,
                TextColor = Color.Green,
                Text = "Recevoir des notification?",
                FontSize = 30,
            };

            Switch switcherNotif = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            Label lblAfficherNotifRep = new Label
            {
                BackgroundColor = Color.Gold,
                TextColor = Color.Black,
                FontSize = 30,
                Text = switcherNotif.IsToggled.ToString()
            };

            switcherNotif.Toggled += (sender, e) =>
            {
                lblAfficherNotifRep.Text = switcherNotif.IsToggled.ToString();
            };

            //----------------------Slider-------------------------------------------

            Label lblFrequenceInterval = new Label
            {
                BackgroundColor = Color.Gold,
                TextColor = Color.Green,
                Text = "Frequence des notification (1 a 24 heures):",
                FontSize = 30,
            };



            Slider sliderNotif = new Slider
            {
                Minimum = 0,
                Maximum = 24,
                Value = 12,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 10
            };

            Label lblFrequenceChoix = new Label
            {
                BackgroundColor = Color.Gold,
                TextColor = Color.Black,
                FontSize = 30,
                VerticalOptions = LayoutOptions.Fill,
                Text = "Chaque " + sliderNotif.Value.ToString() + " heur(s)"
            };

            sliderNotif.ValueChanged += (sender, e) =>
            {
                lblFrequenceChoix.Text = String.Format("Chaque {0:F1} heur(s)", e.NewValue);
            };

            //---------------------------------------------------------
            Label nomLabel = new Label
            {
                BackgroundColor = Color.Red,
                TextColor = Color.Green,
                FontSize = 40,
                Text = nom,
                HorizontalOptions = LayoutOptions.Center
            };

            // Bouton revenir à la page précédente
            Button pagePrecedenteButton = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
            #endregion


            #region StackLayout
            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    lblAfficherNotifQuest,
                    lblAfficherNotifRep,
                    switcherNotif,
                    lblFrequenceInterval,
                    lblFrequenceChoix,
                    sliderNotif,
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