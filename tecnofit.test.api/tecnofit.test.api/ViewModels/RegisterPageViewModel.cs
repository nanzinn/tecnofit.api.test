using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using tecnofit.test.api.ViewModels.Services;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using tecnofit.test.api.Models;
using Xamarin.Forms;

namespace tecnofit.test.api.ViewModels
{
	public class RegisterPageViewModel : ViewModelBase
	{
		private dynamic Pickers;
		
		public ICommand BtConfirmCommand { get; set; }
		
		private IEnumerable<string> _typePayment;
		public IEnumerable<string> TypePayment
		{
			get => _typePayment;
			set => SetProperty(ref(_typePayment),value);
		}
		
		private string _typePaymentSelected ;
		public string TypePaymentSelected
		{
			get => _typePaymentSelected;
			set => SetProperty(ref(_typePaymentSelected),value);
		}
		
		private IEnumerable<string> _accountCategory;
		public IEnumerable<string> AccountCategory
		{
			get => _accountCategory;
			set => SetProperty(ref(_accountCategory),value);
		}
		
		private string _accountCategorySelected ;
		public string AccountCategorySelected
		{
			get => _accountCategorySelected;
			set => SetProperty(ref(_accountCategorySelected),value);
		}
		
		private IEnumerable<string> _responsabilityCenter;
		public IEnumerable<string> ResponsabilityCenter
		{
			get => _responsabilityCenter;
			set => SetProperty(ref(_responsabilityCenter),value);
		}
		
		private string _responsabilityCenterSelected;
		public string ResponsabilityCenterSelected
		{
			get => _responsabilityCenterSelected;
			set => SetProperty(ref(_responsabilityCenterSelected),value);
		}
		
		private IEnumerable<string> _bankAccount;
		public IEnumerable<string> BankAccount
		{
			get => _bankAccount;
			set => SetProperty(ref(_bankAccount),value);
		}
		
		private string _bankAccountSelected;
		public string BankAccountSelected
		{
			get => _bankAccountSelected;
			set => SetProperty(ref(_bankAccountSelected),value);
		}
		
		private decimal _paymentValue;

		public decimal PaymentValue
		{
			get => _paymentValue;
			set
			{
				SetProperty(ref (_paymentValue), value);

				IsPayment = PaymentValue > 0;
			}
		}
		
		private string _accountTitle;

		public string AccountTitle
		{
			get => _accountTitle;
			set => SetProperty(ref (_accountTitle), value);
		}
		
		private decimal _accountValue;

		public decimal AccountValue
		{
			get => _accountValue;
			set => SetProperty(ref (_accountValue), value);
		}
		
		private decimal _disccountValue;

		public decimal DisccountValue
		{
			get => _disccountValue;
			set => SetProperty(ref (_disccountValue), value);
		}
		
		private decimal _fineValue;

		public decimal FineValue
		{
			get => _fineValue;
			set => SetProperty(ref (_fineValue), value);
		}
		
		private bool _isPayment = false;
		public bool IsPayment
		{
			get => _isPayment;
			set => SetProperty(ref(_isPayment),value);
		}
		
		private DateTime _paymentDate = DateTime.Now;

		public DateTime PaymentDate
		{
			get => _paymentDate;
			set
			{
				SetProperty(ref (_paymentDate), value);
			}
		}
		
		private DateTime _maturityDate = DateTime.Now;

		public DateTime MaturityDate
		{
			get => _maturityDate;
			set
			{
				SetProperty(ref (_maturityDate), value);
			}
		}
		
		public RegisterPageViewModel(INavigationService navigationService, IRestService restService, IMessageService messageService) : base(navigationService, restService: restService, messageService: messageService)
		{
			BtConfirmCommand = new Command(BtConfirm);
			GetInfoPickers();
		}

		private async void BtConfirm(object obj)
		{
			if (IsBusy) return;
			IsBusy = true;

			try
			{
				if (await CheckRegister() == false)
				{
					IsBusy = false;
					return;
				}

				var result = await RestService.PostItemAsync(new RegisterModel
				{
					id = null,
					empresaId = 1036,
					tipoConta ="R",
					categoriaContaId = GetId(Pickers.parametros.categoriaConta, AccountCategorySelected),
					centroResponsabilidadeId = GetId(Pickers.parametros.centroResponsabilidade, ResponsabilityCenterSelected),
					formaPagamentoId = GetId(Pickers.parametros.formaCobranca, TypePaymentSelected),
					contaBancoId = GetId(Pickers.parametros.contaBanco, BankAccountSelected),
					formaCobrancaId = null,
					dataVencimento = MaturityDate.ToString("yyyy-MM-dd"),
					dataPagamento = IsPayment? PaymentDate.ToString("yyyy-MM-dd") : null,
					historico = AccountTitle,
					valor = AccountValue,
					valorPago = PaymentValue,
					valorDesconto = DisccountValue,
					valorMulta = FineValue,
					status = 0
					
				},Constants.RegisterRequest, Constants.Token);

				if ((result as string) == null)
				{
					await MessageService.ShowAsync("Conta criada com sucesso!");
					TypePaymentSelected = string.Empty;
					AccountCategorySelected = string.Empty;
					BankAccountSelected = string.Empty;
					ResponsabilityCenterSelected = string.Empty;
					AccountValue = 0;
					DisccountValue = 0;
					FineValue = 0;
					PaymentValue = 0;
					MaturityDate = DateTime.Now;
					PaymentDate = DateTime.Now;
				}
				else 
					await MessageService.ShowAsync($"Erro -- {(result as string)}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			IsBusy = false;
		}

		private async Task<bool> CheckRegister()
		{
			if (string.IsNullOrWhiteSpace(AccountTitle))
			{
				await MessageService.ShowAsync($"Erro -- Escreva um título para sua conta");
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(TypePaymentSelected))
			{
				await MessageService.ShowAsync($"Erro -- Selecione o tipo do pagamento");
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(AccountCategorySelected))
			{
				await MessageService.ShowAsync($"Erro -- Selecione uma categoria para sua conta");
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(ResponsabilityCenterSelected))
			{
				await MessageService.ShowAsync($"Erro -- Selecione um centro de responsabilidade");
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(BankAccountSelected))
			{
				await MessageService.ShowAsync($"Erro -- Selecione uma Conta bancária");
				return false;
			}
			
			return true;
		}

		private async Task GetInfoPickers()
		{
			IsBusy = true;
			
			Pickers = await RestService.GetDataAsync(Constants.PickerRequest,Constants.Token);

			if ((Pickers as string) != null)
			{
				await MessageService.ShowAsync($"Erro -- {(Pickers as string)}");
				return;
			}

			try
			{
				TypePayment = GetArray(Pickers.parametros.formaCobranca);
				AccountCategory = GetArray(Pickers.parametros.categoriaConta);
				ResponsabilityCenter = GetArray(Pickers.parametros.centroResponsabilidade);
				BankAccount = GetArray(Pickers.parametros.contaBanco);
			}
			catch (Exception e)
			{
				await MessageService.ShowAsync($"Erro -- {e.Message}");
			}
			
			IsBusy = false;
		}

		private IEnumerable<string> GetArray(JArray jArray) => jArray.ToObject<IEnumerable<PickerFieldModel>>().Select(jo => jo.Nome).ToArray();
		
		private int GetId(JArray jArray, string name) => Convert.ToInt32(jArray.ToObject<IEnumerable<PickerFieldModel>>().Where(jo=> jo.Nome == name).Select(jo => jo.Id).FirstOrDefault());

	}
}
