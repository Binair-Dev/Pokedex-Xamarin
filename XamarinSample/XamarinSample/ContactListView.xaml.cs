using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSample.ViewModels;

namespace XamarinSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListView : ContentPage
    {
        public ContactListView()
        {
            BindingContext = new ContactListViewModel();
            InitializeComponent();
        }

        private void ResetSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Liste.SelectedItem = null;
        }
    }
}