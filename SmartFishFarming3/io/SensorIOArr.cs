using System;
using SmartFishFarming3.alldata;


namespace SmartFishFarming3.io
{
    /// <summary>
    /// this is the class to collect and display all sensor data
    /// </summary>
    class SensorIOArr: ParentSensorIOAbstract, ISensorIO//ParentSensorIO
    {
        //so what should we do?Let us see struct
        //create two structs for temp and ph data
        //Sensor tempsensor1, tempsensor2, phsensor1, phsensor2;
        private const int TOTAL_SENSORS = 4;
        private const int TOTAL_TEMP_SENSORS=2;
        private const int TOTAL_PH_SENSORS=2;
        Sensor[] sensor_data_arr = new Sensor[TOTAL_SENSORS];//5 temp and 5 ph 
    
        /// <summary>
        /// This method is for collection Temp Data from sensor
        /// It does not need any parameter
        /// </summary>
        protected override void collectTempData()
        {
      
        //read first temp but it may cause exception if non-neumeric input is given
        //handle exception
        try
        {
                for (int i = 0; i < TOTAL_TEMP_SENSORS; i++)
                {
                    Console.WriteLine("Please enter temp sensor id-");
                    Sensor tempsensor;
                    tempsensor.sensor_id = Byte.Parse(Console.ReadLine());//in future -try-catch
                                                               //but following line should be checked as well as and date_time_temp1 
                                                               //should be Datetime type/object
                                                               //Console.WriteLine("Please enter sensor1 type-");
                    tempsensor.sensor_type = sensortypes.TEMP;// Byte.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter first date and time for data-");
                    tempsensor.date_time = Console.ReadLine();
                    Console.WriteLine("Please enter sensor temp-");
                    tempsensor.data_value = double.Parse(Console.ReadLine());
                    sensor_data_arr[i] = tempsensor;
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
                for (int i = TOTAL_TEMP_SENSORS ; i < TOTAL_SENSORS; i++)
                {
                    Console.WriteLine("Please enter Ph sensor id-");
                    Sensor phsensor;
                    phsensor.sensor_id = Byte.Parse(Console.ReadLine());//in future -try-catch
                                                               //but following line should be checked as well as and date_time_temp1 
                                                               //should be Datetime type/object
                                                               //Console.WriteLine("Please enter sensor1 type-");
                    phsensor.sensor_type = sensortypes.PH;// Byte.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter first date and time for data-");
                    phsensor.date_time = Console.ReadLine();
                    Console.WriteLine("Please enter sensor PH-");
                    phsensor.data_value = double.Parse(Console.ReadLine());
                    sensor_data_arr[i] = phsensor;
                }




            }
            catch (Exception e2)
        {
            //when working with large program, you will write all the details of the
            //exception in a log file
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
            //use for loop to print temp data and get temp average
            //please do remember - temp data may not be sequential
            double data_total1 = 0.0;
            double data_total2 = 0.0;
            for (int i = 0; i < TOTAL_SENSORS; i++)
            {
                //use for loop to print temp data
                if (sensor_data_arr[i].sensor_type == sensortypes.TEMP)
                {
                    Console.WriteLine("Temp data-> id:" + sensor_data_arr[i].sensor_id + "-" + sensor_data_arr[i].sensor_type
                                    + " Date & time=" + sensor_data_arr[i].date_time + " Temp=" + sensor_data_arr[i].data_value);
                    data_total1 += sensor_data_arr[i].data_value;
                }
                else if (sensor_data_arr[i].sensor_type == sensortypes.PH)
                {
                    Console.WriteLine("Ph data-> id:" + sensor_data_arr[i].sensor_id + "-" + sensor_data_arr[i].sensor_type
                                    + " Date & time=" + sensor_data_arr[i].date_time + " PH=" + sensor_data_arr[i].data_value);
                    data_total2 += sensor_data_arr[i].data_value;
                }
               
            }


            Console.WriteLine("Average temp is " + (data_total1 / TOTAL_TEMP_SENSORS));
            Console.WriteLine("Average PH is " + (data_total2 / TOTAL_PH_SENSORS));






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
