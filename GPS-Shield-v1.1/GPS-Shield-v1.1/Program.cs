using System;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Toolbox.NETMF.Hardware;
using System.IO.Ports;

namespace GPS_Shield_v1._1
{
    public class Program
    {
        public static NmeaGps gpsModule = new NmeaGps();
        public static void Main()
        {
            //low actually turns the thing on, go figure
            OutputPort gpsPower = new OutputPort(Pins.GPIO_PIN_D4, false);
            gpsModule.Start();
            while (true)
            {
                Debug.Print(gpsModule.Satellites.ToString());
                Thread.Sleep(2000);
            }
        }
    }
}
