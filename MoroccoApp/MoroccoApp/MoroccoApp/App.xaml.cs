
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoroccoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PagePrincipaleContentPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
