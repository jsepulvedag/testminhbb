using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantMusicList
    {
        private List<RestaurantMusicInfo> _listRestaurantMusic;
        public List<RestaurantMusicInfo> ListRestaurantMusic
        {
            get { return _listRestaurantMusic; }
            set { _listRestaurantMusic = value; }
        }
        public RestaurantMusicList()
        {
            _listRestaurantMusic = new List<RestaurantMusicInfo>();
        }
        public void Add(RestaurantMusicInfo item)
        {
            _listRestaurantMusic.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        { 
            foreach(RestaurantMusicInfo item in _listRestaurantMusic)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantMusicInfo item)
        {
            _listRestaurantMusic.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantMusicInfo obj in _listRestaurantMusic)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringMusicID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantMusicInfo obj in _listRestaurantMusic)
                {
                    retVal += obj.MusicID + ";";
                }
                return retVal;
            }
        }
    }
}
