using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinSample.Models;
using XamarinSample.MVVMTools;

namespace XamarinSample.ViewModels
{
    public class PokemonProfilViewModel : ViewModelBase
    {
        #region Properties
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { SetValue(ref _weight, value); }
        }

        private string _back_default;

        public string Back_default
        {
            get { return _back_default; }
            set { SetValue(ref _back_default, value); }
        }

        private string _front_Default;

        public string Front_Default
        {
            get { return _front_Default; }
            set { SetValue(ref _front_Default, value); }
        }
        #endregion
        public PokemonProfilViewModel(Pokemon p)
        {
            Name = p.name;
            Weight = p.weight;
            Front_Default = p.front_default;
            Back_default = p.back_default;
        }
        private Command _closeCommand;
        public Command CloseCommand
        {
            get { return _closeCommand = _closeCommand ?? new Command(Close); }
        }
        private void Close()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
