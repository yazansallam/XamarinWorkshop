using search.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace search.Views
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