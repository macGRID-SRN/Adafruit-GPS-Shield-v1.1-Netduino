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
            
        }

        /// <summary>
        /// Checks if a NMEA sentence is a valid.
        /// </summary>
        /// <param name="response">The NMEA sentence to be checked.</param>
        /// <returns>Whether or not the reponse is a valid NMEA sentence.</returns>
        protected bool CheckSum(string response)
        {
            response = response.TrimStart(new char[] { '$' });
            byte expectedChkSm = expectedCheckSum(response, ref response);
            byte actualChkSm = 0;
            foreach (char myChar in response)
            {
                actualChkSm ^= (byte)myChar;
            }
            return expectedChkSm == actualChkSm;
        }

        /// <summary>
        /// takes a NMEA sentence and retrieves the expected checkSum.
        /// </summary>
        /// <param name="response">the incoming string from the NMEA device.</param>
        /// <returns>the expected checksum.</returns>
        protected byte expectedCheckSum(string response, ref string checkSumRemoved)
        {
            int starPosition = response.Length - 1;
            for (int i = starPosition; i > 0; i--)
            {
                if (response[starPosition] == '*')
                {
                    checkSumRemoved = response.Substring(0, starPosition);
                    return (byte)Tools.Hex2Dec(response.Substring(starPosition + 1, 2));
                }
                else
                    starPosition--;
            }
            return 0;
        }
    }
}
