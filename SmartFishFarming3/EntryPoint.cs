using SmartFishFarming3;
using System;

namespace SmartFishFarming3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {


            //SensorIO sio = new SensorIO();//constructor - method with same name as the class
            //SensorIOArr sio = new SensorIOArr();
            io.ParentSensorIOAbstract sio = null;
            Console.WriteLine("Please enter the type of IO class you want to use:");
            String whatioclass = Console.ReadLine();
            if(whatioclass.Equals("NOARR"))
            {
                sio = new io.SensorIO();
            }
            else if (whatioclass.Equals("ARR"))
            {
                sio = new io.SensorIOArr();
            }
            
            else
            {
                Console.WriteLine("create no logic io");
                sio = new io.SensorIONoLogic();
            }

            sio.beginOperation();
          
           
        }
    }
}


