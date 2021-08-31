using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFishFarming3.io
{
    abstract class ParentSensorIOAbstract
    {
        protected abstract void collectTempData();

        protected abstract void collectPhData();
       
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
