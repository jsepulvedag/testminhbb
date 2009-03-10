using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Utilities.InterFaxAPI
{
    public class FaxOnlinePackageInfo
    {
        private string _faxNumber;
        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = value; }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _fileType;
        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        public byte[] GetBytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(_body.ToCharArray());
            }
        }
    }
}
