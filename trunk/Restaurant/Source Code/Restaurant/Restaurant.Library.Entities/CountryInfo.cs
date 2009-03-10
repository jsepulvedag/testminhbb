using System;

namespace Restaurant.Library.Entities
{
    public class CountryInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private bool _isActive;
        public bool isActive
        {
            get { return _isActive; }
            set { _isActive = value; }    
        }
        private int priority;
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

    }
}
