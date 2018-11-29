using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using tecnofit.test.api.ViewModels.Services;
using Xamarin.Forms;

namespace tecnofit.test.api.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IRestService RestService { get; private set; }
        protected IMessageService MessageService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ViewModelBase(INavigationService navigationService, IRestService restService,IMessageService messageService)
        {
            NavigationService = navigationService;
            RestService = restService;
            MessageService = messageService;
        }

        protected ViewModelBase(INavigationService navigationService, IRestService restService)
        {
            NavigationService = navigationService;
            RestService = restService;
        }
        
        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected async void SaveInfo(string property, object file)
        {
            if (Application.Current.Properties.ContainsKey(property))
                Application.Current.Properties[property] = file;
            else
                Application.Current.Properties.Add(property ,file);

            await Application.Current.SavePropertiesAsync();
        }
        
        protected dynamic LoadInfo(string property)=> Application.Current.Properties.ContainsKey(property) ? Application.Current.Properties[property] : null;

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
