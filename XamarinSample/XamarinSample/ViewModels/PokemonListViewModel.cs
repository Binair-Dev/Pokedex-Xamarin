using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinSample.Models;
using XamarinSample.MVVMTools;
using XamarinSample.Services;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinSample.ViewModels
{
    public class PokemonListViewModel : ViewModelBase
    {
        private Pokemon _selectedContact;

        public Pokemon SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                SetValue(ref _selectedContact, value);
                if(SelectedContact != null) App.Current.MainPage.Navigation.PushModalAsync(new PokemonProfil(SelectedContact));
            }
        }

        public ObservableCollection<Pokemon> PokemonListe { get; set; }

        public PokemonListViewModel()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            _selectedContact = new Pokemon();
            PokemonListe = new ObservableCollection<Pokemon>();
            foreach (Pokemon item in DependencyService.Get<PokemonService>().GetAll("https://pokeapi.co/api/v2/pokemon/"))
            {
                PokemonListe.Add(item);
            }
        }

        private void LoadAndRefreshItems(string url)
        {
            int i = 0;
            foreach (Pokemon item in DependencyService.Get<PokemonService>().GetAll(url))
            {
                if (PokemonListe.Count >= i)
                {
                    PokemonListe[i] = item;
                    i++;
                }
                else
                {
                    PokemonListe.Add(item);
                    i++;
                }
            }
        }


        private Command _nextCommand;
        public Command NextCommand
        {
            get { return _nextCommand = _nextCommand ?? new Command(Next); }
        }

        private void Next()
        {
            string next = DependencyService.Get<PokemonService>().PPage.next;
            string previous = DependencyService.Get<PokemonService>().PPage.previous;
            LoadAndRefreshItems(next = next ?? previous);
        }

        private Command _previousCommand;
        public Command PreviousCommand
        {
            get { return _previousCommand = _previousCommand ?? new Command(Previous); }
        }

        private void Previous()
        {
            string previous = DependencyService.Get<PokemonService>().PPage.previous;
            LoadAndRefreshItems(previous = previous ?? "https://pokeapi.co/api/v2/pokemon/");
        }
    }
}
