using Xamarin.Forms;
using System;
using Xamarin.Forms.Xaml;
using AutoClean.ViewModels;


namespace AutoClean.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        CRUDViewModels crudHelper = new CRUDViewModels();
        public InfoPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await crudHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
    }
}