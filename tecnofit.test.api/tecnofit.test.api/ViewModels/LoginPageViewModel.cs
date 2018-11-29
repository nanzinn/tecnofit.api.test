using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using tecnofit.test.api.Models;
using tecnofit.test.api.ViewModels.Services;
using Xamarin.Forms;

namespace tecnofit.test.api.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        INavigationService _navigationService;

        public ICommand BtLoginEnterCommand { get; set; }
        public ICommand BtRegisterCommand { get; set; }

        bool _isLoginReady = false;
        public bool IsLoginReady { get => _isLoginReady; set => SetProperty(ref (_isLoginReady), value); }

        string _email;
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref (_email), value);
                LoginReady();
            }
        }

        string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref (_password), value);
                LoginReady();
            }
        }

	    private void LoginReady() => IsLoginReady = !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) ? true : false;

	    public LoginPageViewModel(INavigationService navigationService, IRestService restService, IMessageService messageService) : base(navigationService, restService, messageService)
	    {
	        _navigationService = navigationService;
	        BtLoginEnterCommand = new Command(BtLoginEnter);
	        BtRegisterCommand = new Command(BtRegister);
	    }

        private async void BtRegister(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            await Task.Delay(200);
            await _navigationService.NavigateAsync("RegisterPage");
            IsBusy = false;
        }

        private async void BtLoginEnter(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;

            if (!IsLoginReady)
            {
                IsBusy = false;
                return;
            }

            await Task.Delay(200);
            
            var token = await RestService.PostItemAsync(new UserModel { email = Email, password = Password },Constants.LoginRequest,string.Empty);

            if (token == null)
            {
                await MessageService.ShowAsync($"Erro -- Verifique seus dados!");
                IsBusy = false;
                return;
            }
            
            if ((token as string) != null)
            {
                await MessageService.ShowAsync($"Erro -- {(token as string)}");
                IsBusy = false;
                return;
            }
            
            try
            {
                SaveInfo("Token", token.token);
                Constants.Token = token.token;
                IsBusy = false;
                await _navigationService.NavigateAsync("HomePage");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Password = string.Empty;
            Email = string.Empty;
            
            IsBusy = false;
        }
    }
}
