namespace MT32Edit
{
    internal static class LogicTools
    {
        //
        // MT32Edit: LogicTools class (static)
        // S.Fryers Mar 2023
        // Simple tools for boolean logic and data validation.
        //
        public static int BoolToInt(bool flag)
        {
            if (flag) return 1;
            else return 0;
        }

        public static bool IntToBool(int value)
        {
            if (value == 0) return false;
            else return true;
        }

        public static bool DivisibleBy(int value, int divisor)
        { 
            return value % divisor == 0; 
        }

        public static int ValidateRange(string parameterName, int value, int minPermitted, int maxPermitted, bool autoCorrect) //check if value is within permitted range, then either change it or throw an exception
        {
            if (autoCorrect) value = AutoCorrect(value, minPermitted, maxPermitted);
            else ErrorCheck(parameterName, value, minPermitted, maxPermitted);
            return value;
        }

        public static int AutoCorrect(int value, int minPermitted, int maxPermitted) //if value is outside permitted range, change it to closest permitted value
        {
            if (value < minPermitted) value = minPermitted;
            else if (value > maxPermitted) value = maxPermitted;
            return value;
        }

        public static void ErrorCheck(string parameterName, int value, int minPermitted, int maxPermitted) //throw exception if value is outside permitted range
        {
            if (value < minPermitted || value > maxPermitted) throw new ArgumentOutOfRangeException(parameterName, parameterName + " value " + value + " is outside of the permitted range (" + minPermitted + " to " + maxPermitted + ")");
        }
    }
}
