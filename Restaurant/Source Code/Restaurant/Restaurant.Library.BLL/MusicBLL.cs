using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class MusicBLL
    {
        public static DataTable GetAll()
        {
            try
            {
                return MusicDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
