using System;

namespace SmartFishFarming1
{
    class EntryPoints
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello  dear smart farmer!");
            Console.WriteLine("Welcome to the Pond Monitoring System");
            Console.WriteLine("--------------------------------------");
            //define the data we need
            byte sensor_id_temp = 12;
            string sensor_type_temp = "temp";
            string date_time_temp1;
            double temp1;
            string date_time_temp2;
            double temp2;
            //make this more flexible by taking data from user
            //Learing type conversion
            Console.WriteLine("Please enter First date and time for temperature data-");
            date_time_temp1 = Console.ReadLine();
            //read first temp but it may cause exception if non-neumeric input is given
            //handle exception
            try
            {
                Console.WriteLine("Please enter First temparature for data-");
                temp1 = double.Parse(Console.ReadLine());//in future -try-catch
                                                         //but following line should be checked as well as and date_time_temp1 
                                                         //should be Datetime type/object

                

               
            }
            
            catch (Exception e1)
            {
                //when working with large program, you will write all the details of the
                //exception in a log file
                Console.WriteLine(e1.Message);
                Console.WriteLine("Please again enter First temparature for data-");
                temp1 = double.Parse(Console.ReadLine());
            }
            //read the second
            Console.WriteLine("Please enter Second date and time for temperature data-");
            date_time_temp2 = Console.ReadLine();
            try
            {
                Console.WriteLine("Please enter First temparature for data-");
                temp2 = double.Parse(Console.ReadLine());
            }
            catch (Exception e2)
            {
                
                Console.WriteLine(e2.Message);
                Console.WriteLine("Please again enter First temparature for data-");
                temp2 = double.Parse(Console.ReadLine());
            }
            
            //-------------------

            //ph sensor info


            byte sensor_id_ph = 20;
            string sensor_type_ph = "ph";
            string date_time_ph1 ;
            double ph1;
            string date_time_ph2;
            double ph2;

            Console.WriteLine("Please enter First date and time for data-");
            date_time_ph1 = Console.ReadLine();

            
            try
            {
                Console.WriteLine("Please enter First ph for data-");
                ph1 = double.Parse(Console.ReadLine());


            }
            catch (Exception e3)
            {
                //when working with large program, you will write all the details of the
                //exception in a log file
                Console.WriteLine(e3.Message);
                Console.WriteLine("Please again enter First ph for data-");
                ph1 = double.Parse(Console.ReadLine());
            }
            //read the second

            Console.WriteLine("Please enter Second date and time for ph data-");
            date_time_ph2 = Console.ReadLine();
            try
            {
                Console.WriteLine("Please enter First ph for data-");
                ph2 = double.Parse(Console.ReadLine());
            }
            catch (Exception e4)
            {

                Console.WriteLine(e4.Message);
                Console.WriteLine("Please again enter First ph for data-");
                ph2 = double.Parse(Console.ReadLine());
            }



            //-----------------------
            //Display the data
            Console.WriteLine("Temp data 1="  + sensor_id_temp + "-" + sensor_type_temp +
                                "Date & time=" + date_time_temp1 + "  Temp=" + temp1);
            Console.WriteLine("Temp data 2=" + sensor_id_temp + "-" + sensor_type_temp +
                                "Date & time=" + date_time_temp2 + "  Temp=" + temp2);
            Console.WriteLine("PH data 1 =" + sensor_id_ph + "-" + sensor_type_ph +
                               "Date & time=" + date_time_ph1 + "  Ph=" + ph1);
            Console.WriteLine("PH data 2 =" + sensor_id_ph + "-" + sensor_type_ph +
                               "Date & time=" + date_time_ph2 + "  Ph=" + ph2);

        }
    }
}

