using Xamarin.Forms;
using System;
using Xamarin.Forms.Xaml;
using AutoClean.ViewModels;

namespace AutoClean.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        CRUDViewModels crudHelper = new CRUDViewModels();
        public OrderPage()
        {
            InitializeComponent();
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await crudHelper.AddPerson(Convert.ToInt32(txtPersonId.Text), txtName.Text, txtJenis.Text, Convert.ToInt32(txtHarga.Text));
            txtPersonId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtJenis.Text = string.Empty;
            txtHarga.Text = string.Empty;
            await DisplayAlert("Success", "Data Ditambahkan", "OK");
        }
    }
}