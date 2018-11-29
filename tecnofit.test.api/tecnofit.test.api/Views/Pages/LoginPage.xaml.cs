using FFImageLoading.Forms;
using System;
using Xamarin.Forms;

namespace tecnofit.test.api.Views.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await (sender as Label).ScaleTo(.9, 100);
            await (sender as Label).ScaleTo(1, 100);
        }

        private async  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
                await (sender as CachedImage).TranslateTo(0, (sender as CachedImage).HeightRequest, 200);
                await (sender as CachedImage).TranslateTo(0, 0, 200);
        }
    }
}
