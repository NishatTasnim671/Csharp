using System;
using SmartFishFarming3.alldata;


namespace SmartFishFarming3.io
{
    /// <summary>
    /// this is the class to collect and display all sensor data
    /// </summary>
    class SensorIONoLogic: ParentSensorIOAbstract, ISensorIO//ParentSensorIO
    {
        //SmartPonds pond = null;
        SmartPondsWithFile pond = null;
        Sensor[] SensorDataArr = new Sensor[10];
        private const int TOTAL_SENSORS = 4;
        private const int Temp_Sensors = 2;
        private const int phSensors = 2;



        /// <summary>
        /// This method is for collection Temp Data from sensor
        /// It does not need any parameter
        /// </summary>
        protected override void collectTempData()
        {
            int tempdata = pond.getTotalTempData();
            //read first temp but it may cause exception if non-neumeric input is given
            //handle exception
            //ask the pond how many data it needs to collect - the array size pond has for sensor data
            //int tempdata = pond.getTotalTempData();
            try
        {
                for (int i = 0; i < pond.getTotalTempData(); i++)
                {
                    Console.WriteLine("Please enter temp sensor id-");
                    Sensor tempsensor;
                    tempsensor.sensor_id = Byte.Parse(Console.ReadLine());//in future -try-catch
                                                               //but following line should be checked as well as and date_time_temp1 
                                                               //should be Datetime type/object
                                                               //Console.WriteLine("Please enter sensor1 type-");
                    tempsensor.sensor_type = sensortypes.TEMP;// Byte.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter date and time for data-");
                    tempsensor.date_time = Console.ReadLine();
                    Console.WriteLine("Please enter sensor temp-");
                    tempsensor.data_value = double.Parse(Console.ReadLine());
                    pond.saveSensorData(tempsensor);
                }



            }

        catch (Exception e1)
        {
            //when working with large program, you will write all the details of the
            //exception in a log file
            Console.WriteLine(e1.Message);
            
        }
    }
        /// <summary>
        /// This method is for collection Ph Data from sensor
        /// It does not need any parameter
        /// </summary>
        protected override void collectPhData()
        {
            //read first temp but it may cause exception if non-neumeric input is given
            //handle exception
            try
            {
                for (int i = 0; i < pond.getTotalPHData(); i++)
                {
                    Console.WriteLine("Please enter Ph sensor id-");
                    Sensor phsensor;
                    phsensor.sensor_id = Byte.Parse(Console.ReadLine());//in future -try-catch
                                                               //but following line should be checked as well as and date_time_temp1 
                                                               //should be Datetime type/object
                                                               //Console.WriteLine("Please enter sensor1 type-");
                    phsensor.sensor_type = sensortypes.PH;// Byte.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter date and time for data-");
                    phsensor.date_time = Console.ReadLine();
                    Console.WriteLine("Please enter sensor PH-");
                    phsensor.data_value = double.Parse(Console.ReadLine());
                    pond.saveSensorData(phsensor);

                }




            }
            catch (Exception e2)
        {
            //when working with large program, you will write all the details of the
            //exception in a log file
            Console.WriteLine(e2.Message);
           
        
        
        }

    }
        double data_total1 = 0, data_total2 = 0;
        private void Display()
        {

            for (int i = 0; i < TOTAL_SENSORS; i++)
            {
                if (SensorDataArr[i].sensor_type.Equals(sensortypes.TEMP))
                {
                    Console.WriteLine("\nSensor Id" + (i + 1) + " : " + SensorDataArr[i].sensor_id);
                    Console.WriteLine("Sensor Type" + (i + 1) + " : " + SensorDataArr[i].sensor_type);
                    Console.WriteLine("Temparature" + (i + 1) + " : " + SensorDataArr[i].data_value + " degree celcius");
                    Console.WriteLine("Date & Time" + (i + 1) + " : " + SensorDataArr[i].date_time);

                    data_total1 += SensorDataArr[i].data_value;
                }

                else if (SensorDataArr[i].sensor_type.Equals(sensortypes.PH))
                {
                    Console.WriteLine("\nSensor Id " + (i + 1) + " : " + SensorDataArr[i].sensor_id);
                    Console.WriteLine("Sensor Type" + (i + 1) + " : " + SensorDataArr[i].sensor_type);
                    Console.WriteLine("Ph" + (i + 1) + " : " + SensorDataArr[i].data_value + " degree celcius");
                    Console.WriteLine("Date & Time" + (i + 1) + " : " + SensorDataArr[i].date_time);

                    data_total2 += SensorDataArr[i].data_value;
                }
            }

            Console.WriteLine("Average Temp is : " + Math.Round((data_total1 / Temp_Sensors), 2));
            Console.WriteLine("Average ph is : " + Math.Round((data_total2 / phSensors), 2));

        }
        public override void beginOperation()
        {
            pond = new SmartPondsWithFile(PondSize.SMALL, this);
            base.beginOperation();
            //call method to collect temparature data
            collectTempData();
            //call method to collect Ph data
            collectPhData();
            //now display the data
            //use for loop to print temp data and get temp average
            //please do remember - temp data may not be sequential
            Console.WriteLine("Average temp is " + pond.getTempAverage());
            Console.WriteLine("Average ph is " + pond.getPHAverage());
            Console.ReadKey();


        }

        public void showError(string err)
        {
            Console.WriteLine("ERROR: " + err);
        }

        public void showMessage(string msg)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(msg);
        }
    }
}
