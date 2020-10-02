using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1(BindingContext ));           
        }
    }
}
