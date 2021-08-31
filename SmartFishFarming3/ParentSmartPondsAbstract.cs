using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFishFarming3.alldata
{
    abstract class ParentSmartPondsAbstract
    {
        public abstract int getTotalTempData();
        public abstract void saveSensorData(Sensor sensordata);
        public abstract double getTempAverage();
        public abstract double getPHAverage();
    }
}
