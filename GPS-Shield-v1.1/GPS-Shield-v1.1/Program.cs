using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO.Ports;

namespace GPS_Shield_v1._1
{
    public class Program
    {
        public static void Main()
        {
            SerialPort gpsModule = new SerialPort(SerialPorts.COM2, 4800);

            OutputPort gpsPower = new OutputPort(Pins.GPIO_PIN_D4, false);

            gpsModule.Open();

            while (true)
            {
                getResponse(gpsModule);
                Thread.Sleep(2000);
            }
        }

        private static void getResponse(SerialPort serial)
        {
            String response = "";
            while (serial.BytesToRead > 0)
            {
                byte[] buf = new byte[1];
                serial.Read(buf, 0, 1);
                // Line feed - 0x0A - marks end of data.
                // Append each byte read until end of data.
                if (buf[0] != 0x0A)
                {
                    response += (char)buf[0];
                }
                else
                {
                    Debug.Print(response);
                    break;
                }
            }
        }
    }
}
