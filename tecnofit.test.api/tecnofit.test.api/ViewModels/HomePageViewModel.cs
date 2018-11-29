using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using tecnofit.test.api.ViewModels.Services;

namespace tecnofit.test.api.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public HomePageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService, restService)
		{
			Title = "Home";
		}
	}
}
