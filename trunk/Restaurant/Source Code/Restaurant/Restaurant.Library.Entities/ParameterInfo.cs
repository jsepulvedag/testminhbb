using System;

namespace Restaurant.Library.Entities
{
    public class ParameterInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _groupName;
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
        private string _key;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        private Int16 _unit;
        public Int16 Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public override string ToString()
        {
            return _value;
        }
    }
}
