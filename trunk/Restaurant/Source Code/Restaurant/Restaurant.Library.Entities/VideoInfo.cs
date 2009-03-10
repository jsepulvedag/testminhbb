using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class VideoInfo
    {
        private int _iD;
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        }
        private int _restaurantID;
        public int RestaurantID
        {
            get
            {
                return _restaurantID;
            }
            set
            {
                _restaurantID = value;
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        private string _picture;
        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }
        private string _videoPath;
        public string VideoPath
        {
            get
            {
                return _videoPath;
            }
            set
            {
                _videoPath = value;
            }
        }
        private int _views;
        public int Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
            }
        }
       
        private DateTime _uploadedDate;
        public DateTime UploadedDate
        {
            get
            {
                return _uploadedDate;
            }
            set
            {
                _uploadedDate = value;
            }
        }
        
    }

}
