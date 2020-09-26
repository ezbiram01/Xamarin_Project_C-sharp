/*
 Programmeur : Ziad Biram
 date:          7 mai 2020
 Bute:          Projet1 Morocco app

 solution: MoroccoApp.sln
 Projet : MoroccoApp.csproj
 classe:  PagePrincipaleContentPage.xaml.cs
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
    public partial class PagePrincipaleContentPage : ContentPage
    {
        #region variable
        string nom;
        Label labelEntet, labelMember;
        Button buttonNotification, buttonRepas, buttonEvenement, buttonVilles;
        #endregion

        public PagePrincipaleContentPage()
        {
            #region Controllers
            InitializeComponent();

            labelEntet = new Label
            {
                Text = "Bienvenue au Maroc",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red
                
            };

            buttonNotification = new Button
            {
                ImageSource = "image/drapeaux-maroc.jpg",
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 20),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                HeightRequest = 200
            };

            buttonRepas = new Button
            {
                ImageSource = "image/Repas.jpg",
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 20),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                HeightRequest = 200
            };

            buttonEvenement = new Button
            {
                ImageSource = "image/Evenement.jpg",
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 20),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                HeightRequest = 200
            };

            buttonVilles = new Button
            {
                ImageSource = "image/Villes.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                HeightRequest = 200
            };

            labelMember = new Label
            {
                Text = "Ziad Biram",
                TextColor = Color.Green,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red
            };
            #endregion

            #region Evenement Click partagé

            buttonNotification.Clicked += OnClick;
            buttonRepas.Clicked += OnClick;
            buttonEvenement.Clicked += OnClick;
            buttonVilles.Clicked += OnClick;

            #endregion

            #region StackLayout oScrollView

            StackLayout oStackLayout = new StackLayout
            {
                Children =
                {
                    labelEntet,
                    buttonNotification,
                    buttonRepas,
                    buttonEvenement,
                    buttonVilles,
                    labelMember
                },
            };

            ScrollView oScrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = oStackLayout
            };

            this.Content = oScrollView;

            #endregion
        }

        #region Evenement Click
        async void OnClick(object sender, EventArgs e)
        {
            try
            {
                nom = labelMember.Text;

                Button nButton = sender as Button;
                if (nButton == buttonNotification)
                {
                    await Navigation.PushAsync(new NotificationAppContentPage(nom));
                }
                else if(nButton == buttonRepas)
                {
                    await Navigation.PushAsync(new RepasPrixContentPage(nom));
                }
                else if(nButton == buttonEvenement)
                {
                    await Navigation.PushAsync(new EvenementDateContentPage(nom));
                }
                else
                {
                    await Navigation.PushAsync(new VillesContentPage(nom));
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annulé");
            }
        }
        #endregion
    }
}