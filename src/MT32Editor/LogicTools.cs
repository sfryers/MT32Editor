namespace MT32Edit;

/// <summary>
/// Simple tools for boolean logic and data validation.
/// </summary>
internal static class LogicTools
{
    // MT32Edit: LogicTools class (static)
    // S.Fryers Mar 2023

    public static int BoolToInt(bool flag)
    {
        if (flag)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static bool IntToBool(int value)
    {
        if (value == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool DivisibleBy(int value, int divisor)
    {
        return value % divisor == 0;
    }

    /// <summary>
    /// Checks if an integer value is within the specified range. If autoCorrect is set to true, outlier values will be brought within range.
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="value"></param>
    /// <param name="minPermitted"></param>
    /// <param name="maxPermitted"></param>
    /// <param name="autoCorrect"></param>
    /// <returns>Either the original value, the closest value within the permitted range, or an out of range exception</returns>
    public static int ValidateRange(string parameterName, int value, int minPermitted, int maxPermitted, bool autoCorrect)
    {
        if (autoCorrect)
        {
            value = AutoCorrect(value, minPermitted, maxPermitted);
        }
        else
        {
            ErrorCheck(parameterName, value, minPermitted, maxPermitted);
        }

        return value;
    }

    /// <summary>
    /// If value is outside permitted range, change it to closest permitted value
    /// </summary>
    public static int AutoCorrect(int value, int minPermitted, int maxPermitted)
    {
        if (value < minPermitted)
        {
            value = minPermitted;
        }
        else if (value > maxPermitted)
        {
            value = maxPermitted;
        }

        return value;
    }

    /// <summary>
    /// Throw exception if value is outside permitted range
    /// </summary>
    /// <param name="parameterName">The name of the parameter, used in the error message.</param>
    /// <param name="value">The value to test.</param>
    /// <param name="minPermitted">The range start of permitted values.</param>
    /// <param name="maxPermitted">The range end of permitted values.</param>
    /// <exception cref="ArgumentOutOfRangeException">When the value is outside the expected range.</exception>
    public static void ErrorCheck(string parameterName, int value, int minPermitted, int maxPermitted)
    {
        if (value < minPermitted || value > maxPermitted)
        {
            throw new ArgumentOutOfRangeException(parameterName, parameterName + " value " + value + " is outside of the permitted range (" + minPermitted + " to " + maxPermitted + ")");
        }
    }

    /// <summary>
    /// Determines which of four boolean (radioButton) states is true.
    /// </summary>
    /// <returns>
    /// Normally, a number between 0 and 3. If all input values are false, returns -1.
    /// If more than one input value is true, returns a number corresponding to the lowest true value.
    /// </returns>
    /// 
    public static int GetRadioButtonValue(bool a, bool b, bool c, bool d)
    {
        if (a)
        { 
            return 0;
        }
        else if (b)
        {
            return 1;
        }
        else if (c)
        {
            return 2;
        }
        else if (d)
        {
            return 3;   
        }
        else
        { 
            return -1;
        }
    }
}