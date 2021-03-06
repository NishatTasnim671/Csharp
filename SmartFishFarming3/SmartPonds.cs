using System;
using System.Xml.Serialization;
using SmartFishFarming3.alldata;

namespace SmartFishFarming3
{
    /// <summary>
    /// the ponds class
    /// it will contain all sensors
    /// it will have specific size
    /// The number of sensors will depend on pond size
    /// </summary>
    class SmartPonds: ParentSmartPondsAbstract
    {
        const int BIGPONDSENSORS = 10;
        const int MEDIUMPONDSENSORS = 6;
        const int SMALLPONDSENSORS = 4;
        PondSize mysize;
        int current_index = 0;
        int totalTempData;
        int totalPhData;

        //declare the array to hold the sensor data array
        Sensor[] sensor_data;


        //create a constructor that will accept the size of the pond so that the array size can be determined
        public SmartPonds(PondSize sz)
        {
            this.mysize = sz;
            //BIG will have sensor data array with 10 elements
            //MEDIUM  will have sensor data array with 6 elements
            //SMALL  will have sensor data array with 4 element
            if (this.mysize == PondSize.BIG)
            {
                sensor_data = new Sensor[BIGPONDSENSORS];
                this.totalTempData = 5;
                this.totalPhData = 5;

            }
            else if (this.mysize == PondSize.MEDIUM)
            {
                sensor_data = new Sensor[MEDIUMPONDSENSORS];
                this.totalTempData = 3;
                this.totalPhData = 3;
            }
            else
            {
                sensor_data = new Sensor[SMALLPONDSENSORS];
                this.totalTempData = 2;
                this.totalPhData = 2;
            }
        }

        public override int getTotalTempData()
        {
            return this.totalTempData;
        }

        public override void saveSensorData(Sensor sensordata)
        {
            //THERE WILL BE SUBTLE ERROR WITH ARRAY INDEX BEING OUT OF BOUNDS - YOU NEED TO ACCOUNT FOR IT
            sensor_data[current_index] = sensordata;
            current_index++;
        }

        public override double getTempAverage()
        {
            //use for loop to print temp data and get temp average
            //please do remember - temp data may not be sequential
            double data_total = 0.0;
            for (int i = 0; i < sensor_data.Length; i++)
            {
                if (sensor_data[i].sensor_type == sensortypes.TEMP)
                {
                    Console.WriteLine("Temp data-> id:" + sensor_data[i].sensor_id + "-" + sensor_data[i].sensor_type
                                    + " Date & time=" + sensor_data[i].date_time + " Temp=" + sensor_data[i].data_value);
                    data_total += sensor_data[i].data_value;
                }
            }
            return data_total / totalTempData;
        }

        public int getTotalPHData()
        {
            return this.totalPhData;
        }
        public override double getPHAverage()
        {
            //use for loop to print ph data and get ph average
            //please do remember - ph data may not be sequential
            double data_total = 0.0;
            for (int i = 0; i <sensor_data.Length; i++)
            {
                if (sensor_data[i].sensor_type == sensortypes.PH)
                {
                    Console.WriteLine("Ph data-> id:" + sensor_data[i].sensor_id + "-" + sensor_data[i].sensor_type
                                    + " Date & time=" + sensor_data[i].date_time + " Ph=" + sensor_data[i].data_value);
                    data_total += sensor_data[i].data_value;
                }
            }
            return data_total / totalPhData;
        }
        public void showAll()
        {
            for (int i = 0; i < sensor_data.Length; i++)
            {
                Console.WriteLine("Showing All the Data:");
                Console.WriteLine("Temp data-> id:" + sensor_data[i].sensor_id + "-" + sensor_data[i].sensor_type
                                    + " Date & time=" + sensor_data[i].date_time + " Temp=" + sensor_data[i].data_value +
                                    "Ph data-> id:" + sensor_data[i].sensor_id + "-" + sensor_data[i].sensor_type
                                    + " Date & time=" + sensor_data[i].date_time + " Ph=" + sensor_data[i].data_value);
            }
           
        }
    }
}
