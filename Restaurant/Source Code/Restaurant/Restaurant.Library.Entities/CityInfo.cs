using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
   public class CityInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _StateID;
        public int StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
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
        private int _priority;
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}
