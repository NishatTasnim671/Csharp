using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFishFarming3.alldata
{
    struct Sensor
    {
        public byte sensor_id;
        public sensortypes sensor_type;//temp or ph
        public string date_time;
        public double data_value;

    }
    public struct FILEData
    {

        public string TYPE;
        public string ID;
        public string DATE;
        public string VALUE;

    }
}
