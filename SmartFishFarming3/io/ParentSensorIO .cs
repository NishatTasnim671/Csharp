using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFishFarming3.io
{
    class ParentSensorIO
    {
        protected virtual void collectTempData()
        {
            Console.WriteLine("Starting Temparature sensor data collectiom");
        }
        protected virtual void collectPhData()
        {
            Console.WriteLine("Starting ph sensor data collectiom");
        }
        public virtual void beginOperation()
        {
            showWelcomeMessage();
            Console.WriteLine("Begining operation");
        }
        protected void showWelcomeMessage()
        {
            Console.WriteLine("welcome to sensor program.");
            Console.WriteLine("Welcome to the pond monitoring system");
            Console.WriteLine("-------------------------------------");
        }
    }
}
