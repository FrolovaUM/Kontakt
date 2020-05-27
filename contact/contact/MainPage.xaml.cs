using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace contact
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            BindingContext = App.Repository.GetContacts();
            base.OnAppearing();
        }
        async void ShowContactPageAsync(Contact contact)
        {
            ContactPage cp = new ContactPage();
            cp.BindingContext = contact;
            await Navigation.PushAsync(cp);
        }
        void AddContact_Clicked(object sender, EventArgs e)
        {
            ShowContactPageAsync(new Contact());
        }
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ShowContactPageAsync((Contact)e.SelectedItem);
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorPage());
        }
    }
}
