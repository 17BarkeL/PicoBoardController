using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoBoardController
{
    class Program
    {
        static void Main(string[] args)
        {
            PicoBoard picoBoard = new PicoBoard();
            picoBoard.Connect("COM9");

            bool running = true;

            while (running)
            {
                int button = picoBoard.ReadSensor(PicoBoard.Sensor.Button);
                Console.WriteLine($"Button: {button}");
                if (Console.ReadLine() == "quit")
                {
                    running = false;
                }
            }

            picoBoard.Disconnect();
        }
    }
}
