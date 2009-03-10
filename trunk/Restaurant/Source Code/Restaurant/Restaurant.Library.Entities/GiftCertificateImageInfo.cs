using System;

namespace Restaurant.Library.Entities
{
    public class GiftCertificateImageInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _giftTypeID;
        public int GiftTypeID
        {
            get { return _giftTypeID; }
            set { _giftTypeID = value; }
        }
        private string _imageSmallURL;
        public string ImageSmallURL
        {
            get { return _imageSmallURL; }
            set { _imageSmallURL = value; }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _imageLargeURL;
        public string ImageLargeURL
        {
            get { return _imageLargeURL; }
            set { _imageLargeURL = value; }
        }
        private int _toX;
        public int ToX
        {
            get { return _toX; }
            set { _toX = value; }
        }
        private int _toY;
        public int ToY
        {
            get { return _toY; }
            set { _toY = value; }
        }
        private int _fromX;
        public int FromX
        {
            get { return _fromX; }
            set { _fromX = value; }
        }
        private int _fromY;
        public int FromY
        {
            get { return _fromY; }
            set { _fromY = value; }
        }
        private int _msgX;
        public int MsgX
        {
            get { return _msgX; }
            set { _msgX = value; }
        }
        private int _msgY;
        public int MsgY
        {
            get { return _msgY; }
            set { _msgY = value; }
        }
        private int _restaurantX;
        public int RestaurantX
        {
            get { return _restaurantX; }
            set { _restaurantX = value; }
        }
        private int _restaurantY;
        public int RestaurantY
        {
            get { return _restaurantY; }
            set { _restaurantY = value; }
        }
        private int _signatureX;
        public int SignatureX
        {
            get { return _signatureX; }
            set { _signatureX = value; }
        }
        private int _signatureY;
        public int SignatureY
        {
            get { return _signatureY; }
            set { _signatureY = value; }
        }
        private int _priceX;
        public int PriceX
        {
            get { return _priceX; }
            set { _priceX = value; }
        }
        private int _priceY;
        public int PriceY
        {
            get { return _priceY; }
            set { _priceY = value; }
        }
        private int _addressX;
        public int AddressX
        {
            get { return _addressX; }
            set { _addressX = value; }
        }
        private int _addressY;
        public int AddressY
        {
            get { return _addressY; }
            set { _addressY = value; }
        }
        private int _expiredDateX;
        public int ExpiredDateX
        {
            get { return _expiredDateX; }
            set { _expiredDateX = value; }
        }
        private int _expiredDateY;
        public int ExpiredDateY
        {
            get { return _expiredDateY; }
            set { _expiredDateY = value; }
        }
        private string _colorText;
        public string ColorText
        {
            get { return _colorText; }
            set { _colorText = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}
