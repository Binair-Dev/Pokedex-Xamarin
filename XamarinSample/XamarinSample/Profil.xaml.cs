using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSample.Models;
using XamarinSample.ViewModels;

namespace XamarinSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profil : ContentPage
    {
        public Profil(Contact contact = null)
        {
            BindingContext = new ProfilViewModel(contact);
            InitializeComponent();
        }
    }
}