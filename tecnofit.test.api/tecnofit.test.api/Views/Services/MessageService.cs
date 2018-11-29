using System;
using Xamarin.Forms;

namespace tecnofit.test.api.Views.Services
{
    public class MessageService : ViewModels.Services.IMessageService
    {
		public async System.Threading.Tasks.Task ShowAsync(string message)
		{
			await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(Constants.AppName, message, "Ok");
		}
    }
}
