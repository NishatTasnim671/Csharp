using System;

namespace SmartFishFarming2
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Hello  dear smart farmer!");
            Console.WriteLine("Welcome to the Pond Monitoring System");
            Console.WriteLine("--------------------------------------");
            SensorIO sio = new SensorIO();
            sio.beginOperations();

        }
    }
}


