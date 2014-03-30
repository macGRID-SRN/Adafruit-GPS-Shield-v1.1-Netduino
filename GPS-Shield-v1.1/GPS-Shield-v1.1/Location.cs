using System;
using System.Text;
using Toolbox.NETMF;
using Microsoft.SPOT;

namespace GPS_Shield_v1._1
{
    class Location
    {
        int satellitesInView;
        public Location(string response)
        {
            CheckSum(response);
            byte check = expectedCheckSum(response);
        }

        protected bool CheckSum(string response)
        {
            response = response.TrimStart(new char[] { '$' });
            int checkSum = 0;
            for (int i = 0; i < response.Length - 1; i++)
            {
                checkSum ^= (byte)response[i];
            }
            return false;
        }

        /// <summary>
        /// takes a NMEA sentence and retrieves the expected checkSum
        /// </summary>
        /// <param name="response">the incoming string from the NMEA device</param>
        /// <returns>the expected checksum</returns>
        protected byte expectedCheckSum(string response)
        {
            int starPosition = response.Length - 1;
            for (int i = starPosition; i > 0; i--)
            {
                if (response[starPosition] == '*')

                    return (byte)Tools.Hex2Dec(response.Substring(starPosition + 1, 2));
                else
                    starPosition--;
            }
            return 0;
        }
    }
}
