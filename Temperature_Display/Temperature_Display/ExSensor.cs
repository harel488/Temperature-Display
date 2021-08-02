using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature_Display
{
    class ExTempSensor
    {
        const double MAX_VAL=10.0;
        const double MIN_VAL= 1.0;
        const double MAX_TEMP = 90;
        const double MIN_TMP = 25;
        static double _partial = (MAX_TEMP - MIN_TMP) / (MAX_VAL - MIN_VAL) ; // Dividing the range of sensor values into 
                                                                             //  the possible temperature range size.
                                                                             
        public double _currentValue;
        
        // Default Constructor  
        public ExTempSensor()
        {
            _currentValue = 1;
        }

        /// <summary>
        /// To simulate that the system is connected to a real sensor 
        /// I generate a random value within the value range of the sensor
        /// </summary>
        public void MakeRandomVal()
        {
            Random rnd = new Random();
            double val = rnd.NextDouble() * (MAX_VAL - MIN_VAL) + MIN_VAL;
            _currentValue = val;
        }

        /// <summary>
        /// converting the sensor value (range 1-10) to a Celsius value(25-90).
        /// Multiplies the current value by the partial and adds the minimum value of the temperature 
        /// (the value from which the temperature starts)
        /// </summary>
        /// <returns></returns>
        public double ConvertToCelcius()
        {
            return ((_currentValue - 1) * _partial) + MIN_TMP;
        }
    }
}
