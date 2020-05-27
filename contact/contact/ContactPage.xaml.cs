using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace contact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Contact contact = (Contact)BindingContext;
            if (!string.IsNullOrEmpty(contact.Name))
            {
                try
                {
                    App.Repository.SaveContact(contact);
                    Navigation.PopAsync();
                }
                catch (SQLiteException ex)
                {
                    if (ex.Message.Contains("Contact.Name"))
                    {
                        DisplayAlert("Ошибка!", "Такой контакт уже есть", "ОК");
                    }
                }
            }
            else
            {
                DisplayAlert("Ошибка!", "Имя контакта не должно быть пустым", "Ок");
            }

        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            Contact contact = (Contact)BindingContext;
            App.Repository.DeleteContact(contact.Id);
            Navigation.PopAsync();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}