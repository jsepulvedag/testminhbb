using System;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class IncomeTransactionBLL
    {
        public static int Insert(IncomeTransactionInfo incomeTransactionInfo)
        {
            return IncomeTransactionDAL.Insert(incomeTransactionInfo);
        }
        public static void Update(IncomeTransactionInfo incomeTransactionInfo)
        {
            IncomeTransactionDAL.Update(incomeTransactionInfo);
        }
    }
}
