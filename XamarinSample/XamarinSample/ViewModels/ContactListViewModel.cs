using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinSample.Models;
using XamarinSample.MVVMTools;
using XamarinSample.Services;

namespace XamarinSample.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        private Contact _selectedContact;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                SetValue(ref _selectedContact, value);
                if(SelectedContact != null) App.Current.MainPage.Navigation.PushModalAsync(new Profil(SelectedContact));
            }
        }

        public ObservableCollection<Contact> Liste { get; set; }

        public ContactListViewModel()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            _selectedContact = new Contact();
            Liste = new ObservableCollection<Contact>();

            foreach (Contact item in DependencyService.Get<ContactService>().GetAll())
            {
                Liste.Add(item);
            }
        }
    }
}
