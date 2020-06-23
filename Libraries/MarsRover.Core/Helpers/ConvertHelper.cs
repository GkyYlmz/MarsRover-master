using System;

namespace MarsRover.Core.Helpers
{
    public static class ConvertHelper
    {
        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return (int)decimal.MinusOne;
            }
        }

        public static bool IsNumber(this string value)
        {
            double oReturn = 0;
            return double.TryParse(value, out oReturn);
        }
    }
}
