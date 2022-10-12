using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoBoardController
{
    // https://twiki.cern.ch/twiki/pub/Sandbox/DaqSchoolExercise14/Picoboard_protocol.pdf
   class PicoBoard
    {
        public enum Sensor
        {
            ResistanceD = 0,
            ResistanceC = 1,
            ResistanceB = 2,
            Button = 3,
            ResistanceA = 4,
            Light = 5,
            Sound = 6,
            Slider = 7,
        }
        
        private int[] sensorValues = new int[8];
        private byte[] buffer = new byte[18];
        SerialPort picoBoardPort = new SerialPort();

        public void Connect(string portName)
        {
            picoBoardPort.PortName = portName;
            picoBoardPort.BaudRate = 38400;
            picoBoardPort.ReadTimeout = 10;

            picoBoardPort.Open();
        }

        public void Disconnect()
        {
            picoBoardPort.Close();
        }

        public int ReadSensor(Sensor sensor)
        {
            buffer[0] = 1;
            picoBoardPort.Write(buffer, 0, 1); // Request data packet
            int bytesRead = picoBoardPort.Read(buffer, 0, 18); // Recieve data packet
            Console.WriteLine($"Read {bytesRead} bytes");
            return sensorValues[(int)sensor];
        }
    }
}
