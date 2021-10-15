using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSample.Services;

namespace XamarinSample
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<ContactService>(new ContactService());
            DependencyService.RegisterSingleton<PokemonService>(new PokemonService());

            InitializeComponent();

            MainPage = new TabbedPage1();
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
