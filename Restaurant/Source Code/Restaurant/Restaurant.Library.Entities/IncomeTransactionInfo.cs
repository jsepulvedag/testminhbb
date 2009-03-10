using System;

namespace Restaurant.Library.Entities
{
    public class IncomeTransactionInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _transactionID;
        public int TransactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }
        private string _numberTransaction;
        public string NumberTransaction
        {
            get { return _numberTransaction; }
            set { _numberTransaction = value; }
        }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
