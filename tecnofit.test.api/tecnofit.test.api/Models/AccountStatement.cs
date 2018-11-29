using System.Collections.Generic;

namespace tecnofit.test.api.Models
{
    public class AccountStatement
    {
        public List<AccountModel> accounts { get; set; }
        public double previousBalance { get; set; }
        public double currentBalance { get; set; }
        public int accountsReceivable { get; set; }
        public int accountsPayable { get; set; }
    }
}