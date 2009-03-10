using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class GiftCertificateInfo
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
        private int _giftCertificateImageID;
        public int GiftCertificateImageID
        {
            get { return _giftCertificateImageID; }
            set { _giftCertificateImageID = value; }
        }
        private string _giftImageURL;
        public string GiftImageURL
        {
            get { return _giftImageURL; }
            set { _giftImageURL = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private DateTime _expiredDate;
        public DateTime ExpiredDate
        {
            get { return _expiredDate; }
            set { _expiredDate = value; }
        }
        private string _signatureMsg;
        public string SignatureMsg
        {
            get { return _signatureMsg; }
            set { _signatureMsg = value; }
        }
        private string _toMsg;
        public string ToMsg
        {
            get { return _toMsg; }
            set { _toMsg = value; }
        }
        private string _fromMsg;
        public string FromMsg
        {
            get { return _fromMsg; }
            set { _fromMsg = value; }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _sendGift;
        public string SendGift
        {
            get { return _sendGift; }
            set { _sendGift = value; }
        }
    }
}
