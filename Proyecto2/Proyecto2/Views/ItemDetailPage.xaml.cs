using Proyecto2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Proyecto2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}