using System;
using Microsoft.SPOT;

namespace GPS_Shield_v1._1
{
    class Location
    {
        int satellitesInView;
        public Location(string response)
        {

        }

        protected bool CheckSum(string response)
        {
            int checkSum = 0;

            for (int i = 1; i < response.Length - 1; i++)
            {
                checkSum ^= Convert.ToByte(response[i].ToString());
            }
            return false;
        }
    }
}
