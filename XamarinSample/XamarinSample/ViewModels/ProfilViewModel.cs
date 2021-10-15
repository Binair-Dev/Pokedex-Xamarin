using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinSample.Models;
using XamarinSample.MVVMTools;

namespace XamarinSample.ViewModels
{
        #region Properties
    public class ProfilViewModel : ViewModelBase
    {
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { SetValue(ref _nom, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }

        private string _info;

        public string Info
        {
            get { return _info; }
            set { SetValue(ref _info, value); }
        }

        private string _tel;

        public string Tel
        {
            get { return _tel; }
            set { SetValue(ref _tel, value); }
        }

        private string _gsm;

        public string Gsm
        {
            get { return _gsm; }
            set { SetValue(ref _gsm, value); }
        }
        #endregion
        public ProfilViewModel(Contact contact)
        {
            Nom = contact.Nom;
            Gsm = contact.Gsm;
            Tel = contact.Tel;
            Email = contact.Email;
            Info = contact.Info;
        }

        private Command _changeValueCommand;

        public Command changeValueCommand
        {
            get { return _changeValueCommand = _changeValueCommand ?? new Command(ChangeValue); }
        }

        private void ChangeValue()
        {
            Nom = "Steve Laurent";
            Email = "laurent.steve@gmail.com";
            Info = "Roi des pauses";
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
