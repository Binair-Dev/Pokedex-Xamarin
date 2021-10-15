using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSample.ViewModels;

namespace XamarinSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokedexListView : ContentPage
    {
        public PokedexListView()
        {
            BindingContext = new PokemonListViewModel();
            InitializeComponent();
        }

        private void ResetSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Liste.SelectedItem = null;
        }
    }
}