using System;

namespace Restaurant.Library.Entities
{
    public class AccountPaymentInfo
    {
        private string _creditCardNumber = string.Empty;
        public string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { _creditCardNumber = value; }
        }

        private string _cardSercurityCode = string.Empty;
        public string CardSercurityCode
        {
            get { return _cardSercurityCode; }
            set { _cardSercurityCode = value; }
        }

        private string _typeOfCreditCard = string.Empty;
        public string TypeOfCreditCard
        {
            get { return _typeOfCreditCard; }
            set { _typeOfCreditCard = value; }
        }

        private int _expiredMonth;
        public int ExpiredMonth
        {
            get { return _expiredMonth; }
            set { _expiredMonth = value; }
        }

        private int _expiredYear;
        public int ExpiredYear
        {
            get { return _expiredYear; }
            set { _expiredYear = value; }
        }

        private string _nameOnCreditCard = string.Empty;
        public string NameOnCreditCard
        {
            get { return _nameOnCreditCard; }
            set { _nameOnCreditCard = value; }
        }
    }
}
