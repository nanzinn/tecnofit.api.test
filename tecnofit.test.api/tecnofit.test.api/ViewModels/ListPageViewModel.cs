using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Navigation;
using tecnofit.test.api.Models;
using tecnofit.test.api.ViewModels.Services;

namespace tecnofit.test.api.ViewModels
{
	public class ListPageViewModel : ViewModelBase
	{
		private string actualValue;
		public string ActualValue
		{
			get => actualValue;
			set => SetProperty(ref(actualValue), value);
		}

		private string previousValue;
		public string PreviousValue
		{
			get => previousValue;
			set => SetProperty(ref(previousValue), value);
		}
		
		private string billToPay;
		public string BillToPay
		{
			get => billToPay;
			set => SetProperty(ref(billToPay), value);
		}
		
		private string billToReceive;
		public string BillToReceive
		{
			get => billToReceive;
			set => SetProperty(ref(billToReceive), value);
		}
		
		private DateTime selectedDate = DateTime.Now;

		public DateTime SelectedDate
		{
			get => selectedDate;
			set
			{
				SetProperty(ref (selectedDate), value);
				GetInfo();
			}
		}

		
		public ListPageViewModel(INavigationService navigationService, IRestService restService, IMessageService messageService) : base(navigationService, restService,messageService)
		{
			Title = "Home";

			GetInfo();
		}

		private async Task GetInfo()
		{
			if (IsBusy) return;
			IsBusy = true;
			
			
			try
			{
				var accountStatement = (await RestService.GetDataAsync($"{Constants.ListRequest}{selectedDate:yyyy-MM-dd}",Constants.Token)).accountStatement;
				
				if ((accountStatement as string) != null)
				{
					await MessageService.ShowAsync($"Erro -- {(accountStatement as string)}");
					IsBusy = false;
					return;
				}
				
				ActualValue = $"R${accountStatement.currentBalance}" ;
				PreviousValue = $"R${accountStatement.previousBalance}";
				BillToPay = accountStatement.accountsReceivable;
				BillToReceive = accountStatement.accountsPayable;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			
			IsBusy = false;
		}
	}
}
