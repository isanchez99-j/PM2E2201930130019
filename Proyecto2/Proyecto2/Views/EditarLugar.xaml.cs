using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarLugar : ContentPage
    {
        private readonly Lugares lugar;

        public EditarLugar(Lugares lugar)
        {
            InitializeComponent();

            this.lugar = lugar;

            Descripcion.Text = lugar.descripcion;
            Latitud.Text = lugar.latitud;
            Longitud.Text = lugar.longitud;
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            lugar.descripcion = Descripcion.Text;
            lugar.latitud = Latitud.Text;
            lugar.longitud= Longitud.Text;

            // Save the changes to the database
            var result = await App.DBase.SitioSave(lugar);

            Debug.WriteLine(result);
         
            await DisplayAlert("Aviso", "Registro Actualizado", "OK");
            await Navigation.PopAsync();
        }

        private void Descripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = Regex.IsMatch(e.NewTextValue, "^.{0,256}$");

            if (!isValid)
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }
}