using Xamarin.Forms;
using System;
using Xamarin.Forms.Xaml;
using AutoClean.ViewModels;

namespace AutoClean.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        CRUDViewModels crudHelper = new CRUDViewModels();
        public UpdatePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await crudHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await crudHelper.UpdatePerson(Convert.ToInt32(txtPersonId.Text), txtName.Text, txtJenis.Text, Convert.ToInt32(txtHarga.Text));
            txtPersonId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtJenis.Text = string.Empty;
            txtHarga.Text = string.Empty;
            await DisplayAlert("Success", "Order Updated Successfully", "OK");
            var allPersons = await crudHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await crudHelper.DeletePerson(Convert.ToInt32(txtPersonId.Text));
            await DisplayAlert("Success", "Order Deleted Successfully", "OK");
            var allPersons = await crudHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
    }
}