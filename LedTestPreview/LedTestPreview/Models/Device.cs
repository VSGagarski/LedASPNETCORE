using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;

namespace LedTestPreview.Models
{
    public class Device
    {

        public string Port { get; set; }

        public int Baud { get; set; }

        public  bool IsActive { get { return _port.IsOpen; } }

        private static SerialPort _port;

        public Device()
        {
            _port = new SerialPort();
        }


        public static void Initializing(string port, int baud = 115200)
        {
            _port.PortName = port;
            _port.BaudRate = baud;
        }

        public static void Start()
        {
            _port.Open();
           
        }
        public static void Stop()
        {
            
            _port.Close();
           
        }

        public static List<String> GetPorts()
        {
            return SerialPort.GetPortNames().ToList<String>();
        }

        public static void Send(string symbol)
        {
            if (_port.IsOpen)
            {
                _port.Write(symbol);
            }
           
        }

    }
}
