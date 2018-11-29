using System;
namespace tecnofit.test.api.ViewModels.Services
{
    public interface IMessageService
    {
        System.Threading.Tasks.Task ShowAsync(string message);
    }
}
