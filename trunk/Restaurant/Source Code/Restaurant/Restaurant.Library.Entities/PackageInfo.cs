using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class PackageInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private bool _allowOnlineOrder;
        public bool AllowOnlineOrder
        {
            get { return _allowOnlineOrder; }
            set { _allowOnlineOrder = value; }
        }
        private bool _allowGiftCertificate;
        public bool AllowGiftCertificate
        {
            get { return _allowGiftCertificate; }
            set { _allowGiftCertificate = value; }
        }
        private bool _allowReservation;
        public bool AllowReservation
        {
            get { return _allowReservation; }
            set { _allowReservation = value; }
        }
        private bool _allowMap;
        public bool AllowMap
        {
            get { return _allowMap; }
            set { _allowMap = value; }
        }
        private bool _allowVideo;
        public bool AllowVideo
        {
            get { return _allowVideo; }
            set { _allowVideo = value; }
        }
        private bool _allowPhoto;
        public bool AllowPhoto
        {
            get { return _allowPhoto; }
            set { _allowPhoto = value; }
        }
        private bool _allowEvent;
        public bool AllowEvent
        {
            get { return _allowEvent; }
            set { _allowEvent = value; }
        }
        private bool _allowJobPortal;
        public bool AllowJobPortal
        {
            get { return _allowJobPortal; }
            set { _allowJobPortal = value; }
        }
        private bool _allowMenu;
        public bool AllowMenu
        {
            get { return _allowMenu; }
            set { _allowMenu = value; }
        }
        private bool _allowSponsored;
        public bool AllowSponsored
        {
            get { return _allowSponsored; }
            set { _allowSponsored = value; }
        }
        private Int16 _priority;
        public Int16 Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}
