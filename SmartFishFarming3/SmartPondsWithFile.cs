using System;
using System.IO;
using SmartFishFarming3.alldata;

namespace SmartFishFarming3
{
    /// <summary>
    /// the ponds class that saves sensor data in a file
    /// it will contain all sensors
    /// it will have specific size
    /// The number of sensors will depend on pond size
    /// The sensor data will be saved in the following format - 
    /// TEMP~55~2020-10-10:9AM~13.5
    /// PH~22~2020-10-10:10AM~7.5
    /// TEMP.....
    /// </summary>
    class SmartPondsWithFile: ParentSmartPondsAbstract
    {

        const string Sensor_File = @"F:\SmartFishFarming3\sensordata.txt";
        int TotalPhData=0;
        PondSize mysize;
        static int Temp_Sensor_Count = 0, PH_Sensor_Count = 0, Count = 0, count2 = 0;
        int totalTempData = 0;
        static double Temp_data_value = 0, PH_data_value = 0;
        Boolean check = false;
        string Value_From_File;
        //SmartFishFarming3.io.ISensorIO ioobj = null;
        SmartFishFarming3.io.ISensorIO ioobj = null;


        //declare the array to hold the sensor data array
        //create a constructor that will accept the size of the pond so that the array size can be determined
        public SmartPondsWithFile(PondSize sz, SmartFishFarming3.io.ISensorIO io)
        {
            this.mysize = sz;
            this.ioobj = io;
            //BIG will have sensor data array with 10 elements
            //MEDIUM  will have sensor data array with 6 elements
            //SMALL  will have sensor data array with 4 element
            if (this.mysize == PondSize.BIG)
            {
                this.totalTempData = 5;
            }
            else if (this.mysize == PondSize.MEDIUM)
            {
                this.totalTempData = 3;
            }
            else
            {
                this.totalTempData = 2;
            }
            //check if data file exists - if not, then create it
            if (!File.Exists(Sensor_File))
            {
                File.Create(Sensor_File);
            }
        }


        public int getTotalPHData()
        {
            return TotalPhData;
        }
        public override int getTotalTempData()
        {
            return totalTempData;
        }

        public override void saveSensorData(Sensor sensordata)
        {


            StreamWriter sw = new StreamWriter(Sensor_File, true);
            try
            {
                string sensorinfo = sensordata.sensor_type + " ~ "
                                    + sensordata.sensor_id + " ~ "
                                    + sensordata.date_time + " ~ "
                                    + sensordata.data_value;
                sw.WriteLine(sensorinfo);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                sw.Close();
            }


            //THERE WILL BE SUBTLE ERROR WITH ARRAY INDEX BEING OUT OF BOUNDS - YOU NEED TO ACCOUNT FOR IT

        }

        public override double getTempAverage()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("Temp File");
            StreamReader srd = new StreamReader(Sensor_File);

            //use for loop to print temp data and get temp average
            //please do remember - temp data may not be sequential
            string line = "";
            try
            {
                while (true)
                {
                    line = srd.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    //nwo you have to get the data out from each line
                    Count++;
                    string authors = line;
                    
                    // Split authors separated by a comma followed by space  
                    string[] Pick_Data = authors.Split("~");
                    foreach (string Data in Pick_Data)
                    {
                        //count2 is the index of file data reading

                        if (count2 == 4)
                        {
                            count2 = 0;
                        }


                        if (count2 == 0)
                        {
                            string t = Data;
                            if (t.Equals("TEMP "))
                            {
                                count2++;
                                Console.WriteLine("Type:" + t);
                                check = true;
                            }
                        }
                        else if (count2 == 1)
                        {
                            count2++;
                            Console.WriteLine("ID:" + Data);
                        }


                        else if (count2 == 2)
                        {
                            count2++;
                            Console.WriteLine("Date:" + Data);

                        }
                        else if (count2 == 3)
                        {

                            Value_From_File = Data;
                            count2++;
                            Console.WriteLine("Temp Value:" + Value_From_File);
                            if (check == true)
                            {
                                double value = Convert.ToDouble(Value_From_File);
                                Temp_data_value += value;
                                check = false;
                                Temp_Sensor_Count++;
                                Console.WriteLine();

                            }
                        }
                    }


                    //remember each line represent one sensor data (structure)
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);

            }
            Console.WriteLine("Total Temp Sensor reading : " + Temp_Sensor_Count);
            return (Temp_data_value / Temp_Sensor_Count);
        }


        public override double getPHAverage()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("PH File");
            StreamReader srd = new StreamReader(Sensor_File);
            //use for loop to print temp data and get temp average
            //please do remember - temp data may not be sequential
    
            string line = "";


            try
            {
                while (true)
                {
                    line = srd.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    //nwo you have to get the data out from each line
                    Count++;
                    string authors = line;

                    // Split authors separated by a comma followed by space  
                    string[] Pick_Data = authors.Split("~");
                    foreach (string Data in Pick_Data)
                    {

                        if (count2 == 4)
                        {
                            count2 = 0;
                        }


                        if (count2 == 0)
                        {
                            string t = Data;
                            if (t.Equals("PH "))
                            {
                                count2++;
                                Console.WriteLine("Type:" + t);
                                check = true;
                            }
                        }
                        else if (count2 == 1)
                        {
                            count2++;
                            Console.WriteLine("ID:" + Data);
                        }


                        else if (count2 == 2)
                        {
                            count2++;
                            Console.WriteLine("Data:" + Data);

                        }
                        else if (count2 == 3)
                        {

                            Value_From_File = Data;
                            count2++;
                            Console.WriteLine("PH Value:" + Value_From_File);
                            if (check == true)
                            {
                                double value = Convert.ToDouble(Value_From_File);
                                PH_data_value += value;
                                check = false;
                                PH_Sensor_Count++;
                                Console.WriteLine();
                            }
                        }
                    }


                    //remember each line represent one sensor data (structure)
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);

            }
            Console.WriteLine("Total PH Sensor reading : " + PH_Sensor_Count);
            return (PH_data_value / PH_Sensor_Count);
        }



    }
}

