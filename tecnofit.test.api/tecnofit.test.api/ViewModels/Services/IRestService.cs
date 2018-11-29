using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tecnofit.test.api.ViewModels.Services
{
    public interface IRestService
    {
        Task<dynamic> PostItemAsync(dynamic item, string restRequest, string token );
        Task<dynamic> GetDataAsync(string restRequest,string token);
    }
}
