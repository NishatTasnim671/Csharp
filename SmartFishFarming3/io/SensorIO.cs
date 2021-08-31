using System;
using System.ComponentModel;
using SmartFishFarming3;
using SmartFishFarming3.alldata;
using SmartFishFarming3.io;


namespace SmartFishFarming3.io
{
    /// <summary>
    /// This is the class to collect and display alll sensor data
    /// </summary>
    class SensorIO : ParentSensorIOAbstract, ISensorIO //ParentSensorIO
    {
        //create two structs for temp data and ph data
        //BUT WHAT IF WE HAVE A LOT SENSORS???  SHOULD USE AN ARRAY
        Sensor tempsensor1, tempsensor2, phsensor1, phsensor2;

        /// <summary>
        /// This method is for collecting temparature data from sensor.
        /// It does not need any parameters
        /// </summary>
        protected override void  collectTempData()
        {
            //make this more flexible by taking data input from users
            //read first temp - but it may cause exception if non-numeric input is given
            //handle exception
            try
            {
                Console.WriteLine("Please enter sensor1 id - ");
                tempsensor1.sensor_id = Byte.Parse(Console.ReadLine());
                //the following should be changed, we already know the
                //type to be temp.  so we can set it ourselves, instead
                //of accepting user input
                //Console.WriteLine("Please enter sensor1 type - ");
                tempsensor1.sensor_type = sensortypes.TEMP;//Console.ReadLine();
                Console.WriteLine("Please enter first date and time for data - ");
                tempsensor1.date_time = Console.ReadLine();
                Console.WriteLine("Please enter sensor1 temp - ");
                tempsensor1.data_value = double.Parse(Console.ReadLine());//in future - try-catch
                //but the following line should be checked as well and date_time_temp2
                //should be a Datetime type/object
                //now the second sensro data
                Console.WriteLine("Please enter sensor2 id - ");
                tempsensor2.sensor_id = Byte.Parse(Console.ReadLine());
                //Console.WriteLine("Please enter sensor2 type - ");
                tempsensor2.sensor_type = sensortypes.TEMP;//Console.ReadLine();
                Console.WriteLine("Please enter sensor1 date and time for data - ");
                tempsensor2.date_time = Console.ReadLine();
                Console.WriteLine("Please enter sensor2 temp - ");
                tempsensor2.data_value = double.Parse(Console.ReadLine());//in future - try-catch

            }
            catch (Exception e)
            {
                //when wroking with large programs, you must write all the details of the 
                //exception in a log file
                //Console.WriteLine(e.StackTrace);//this line is too ugly for regular users, put it in log file
                Console.WriteLine(e.Message);
            }

        }

        protected override void collectPhData()
        {
            try
            {
                Console.WriteLine("Please enter sensor1 id - ");
                phsensor1.sensor_id = Byte.Parse(Console.ReadLine());
                //the following should be changed, we already know the
                //type to be temp.  so we can set it ourselves, instead
                //of accepting user input
                //Console.WriteLine("Please enter sensor1 type - ");
                phsensor1.sensor_type = sensortypes.PH;//Console.ReadLine();
                Console.WriteLine("Please enter first date and time for data - ");
                phsensor1.date_time = Console.ReadLine();
                Console.WriteLine("Please enter sensor1 ph - ");
                phsensor1.data_value = double.Parse(Console.ReadLine());//in future - try-catch
                //but the following line should be checked as well and date_time_temp2
                //should be a Datetime type/object
                //now the second sensro data
                Console.WriteLine("Please enter sensor2 id - ");
                phsensor2.sensor_id = Byte.Parse(Console.ReadLine());
                //Console.WriteLine("Please enter sensor2 type - ");
                phsensor2.sensor_type = sensortypes.PH;//Console.ReadLine();
                Console.WriteLine("Please enter sensor1 date and time for data - ");
                phsensor2.date_time = Console.ReadLine();
                Console.WriteLine("Please enter sensor2 ph - ");
                phsensor2.data_value = double.Parse(Console.ReadLine());//in future - try-catch

            }
            catch (Exception e2)
            {
                //when wroking with large programs, you must write all the details of the 
                //exception in a log file
                //Console.WriteLine(e.StackTrace);//this line is too ugly for regular users, put it in log file
                Console.WriteLine(e2.Message);
            }
        }
        public override void beginOperation()
        {
            base.beginOperation();
            //call method to collect temparature data
            collectTempData();
            //call method to collect Ph data
            collectPhData();
            //now display the data
            Console.WriteLine("Temp data 1 " + tempsensor1.sensor_id + "-" + tempsensor1.sensor_type
                            + " Date & time=" + tempsensor1.date_time + " Temp=" + tempsensor1.data_value);
            Console.WriteLine("Temp data 2 " + tempsensor2.sensor_id + "-" + tempsensor2.sensor_type
                            + " Date & time=" + tempsensor2.date_time + " Temp=" + tempsensor2.data_value);
            Console.WriteLine("Ph data 1 " + phsensor1.sensor_id + "-" + phsensor1.sensor_type
                           + " Date & time=" + phsensor1.date_time + " Ph=" + phsensor1.data_value);
            Console.WriteLine("Ph data 2 " + phsensor2.sensor_id + "-" + phsensor2.sensor_type
                            + " Date & time=" + phsensor2.date_time + " Ph=" + phsensor2.data_value);
            
            Console.ReadKey();
        }
        public void showError(string err)
        {
            throw new NotImplementedException();
        }

        public void showMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
