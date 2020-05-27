using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO ;

namespace contact
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();



            MainPage = new NavigationPage(new MainPage());

            
        }
        

        const string DATABASE_NAME = "contacts.db";
        static ContactRepository repository;
        public static ContactRepository Repository
        {
            get
            {
                if (repository == null)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    repository = new ContactRepository(Path.Combine(path, DATABASE_NAME));
                }
                return repository;
            }

        }
    }
}
