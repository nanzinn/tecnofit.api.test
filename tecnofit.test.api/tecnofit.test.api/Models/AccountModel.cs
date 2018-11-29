using System.Collections.Generic;

namespace tecnofit.test.api.Models
{
    public class AccountModel
    {
        public string origin { get; set; }
        public int id { get; set; }
        public int companyId { get; set; }
        public string dateCredit { get; set; }
        public string expirationDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int grossValue { get; set; }
        public int netValue { get; set; }
        public int penaltyValue { get; set; }
        public int discountValue { get; set; }
        public int installment { get; set; }
        public int installments { get; set; }
        public int status { get; set; }
        public string accountType { get; set; }
        public int bankAccountId { get; set; }
        public string bankAccount { get; set; }
        public int paymentMethodId { get; set; }
        public string paymentMethod { get; set; }
        public int billingMethodId { get; set; }
        public object billingMethod { get; set; }
        public int accountCategoryId { get; set; }
        public string accountCategory { get; set; }
        public int centerResponsibilityId { get; set; }
        public string centerResponsibility { get; set; }
        public bool transference { get; set; }
    }
}