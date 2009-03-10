using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Utilities.net.interfax.ws;

namespace Restaurant.Library.Utilities.InterFaxAPI
{
    public class FaxOnlineSender
    {
        FaxOnlinePackageInfo package;
        FaxOnlineAccountInfo account;

        public FaxOnlineSender(FaxOnlinePackageInfo _package, FaxOnlineAccountInfo _faxAccount)
        {
            package = (FaxOnlinePackageInfo)_package;
            account = (FaxOnlineAccountInfo)_faxAccount;
        }

        public long SendFax()
        {
            Restaurant.Library.Utilities.net.interfax.ws.InterFax objFax = new Restaurant.Library.Utilities.net.interfax.ws.InterFax();
            return objFax.Sendfax(account.UserName,account.Password,package.FaxNumber,package.GetBytes,package.FileType);
        }

        public string getStatus(FaxOnlineAccountInfo account, string transactionID)
        {
            const string _break = "<br>";
            int iLastTransactionID;
            int iMaxItems = 10;
            int iTotalCount = 0;
            int iListSize = 0;
            int iResultCode = 0;
            string result = "";
            FaxItem[] structFaxItems;

            iLastTransactionID = Convert.ToInt32(transactionID);

            Restaurant.Library.Utilities.net.interfax.ws.InterFax objIF = new Restaurant.Library.Utilities.net.interfax.ws.InterFax();
            structFaxItems =
                objIF.FaxStatus(account.UserName,account.Password,
                iLastTransactionID, iMaxItems, ref iTotalCount, ref iListSize, ref iResultCode);

            if (iResultCode != 0)
            {
                result = "ERROR Occured. Result code is:" + iResultCode;
            }
            else
            {
                for (int i = 0; i < iListSize; i++)
                {
                    result = result + "=============================" + _break;
                    result = result + "Fax item #" + i + _break;
                    result = result + "TransactionID: " + structFaxItems[i].TransactionID + _break;
                    result = result + "Fax number: " + structFaxItems[i].DestinationFax + _break;
                    result = result + "SubmitTime: " + structFaxItems[i].SubmitTime + _break;
                    result = result + "CompletionTime: " + structFaxItems[i].CompletionTime + _break;
                    result = result + "PagesSent: " + structFaxItems[i].PagesSent + _break;
                    result = result + "Status: " + structFaxItems[i].Status + _break;
                }
            }
            return result;
        }
    }
}
