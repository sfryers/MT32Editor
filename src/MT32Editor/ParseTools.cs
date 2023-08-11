namespace MT32Edit;

/// <summary>
/// Simple tools for parsing text strings
/// </summary>
internal static class ParseTools
{
    // MT32Edit: ParseTools class (static)
    // S.Fryers Mar 2023
    // Simple tools for parsing text strings
    
    /// <summary>
    /// Ensures string is precisely the desiredLength by adding spaces or removing excess characters from right hand side
    /// </summary>
    public static string MakeNCharsLong(string str, int desiredLength)
    {
        str = PadWithSpace(str, desiredLength);
        str = TrimToLength(str, desiredLength);
        return str;
    }

    /// <summary>
    /// Adds spaces to end of string to pad it to the desiredLength
    /// </summary>
    public static string PadWithSpace(string str, int desiredLength)
    {
        while (str.Length < desiredLength)
        {
            str += " ";
        }
        return str;
    }

    /// <summary>
    /// Helps format text for plural instances - returns string "s" if input value is exactly 1, otherwise returns null string
    /// </summary>
    public static string Plural(int noOfItems)
    {
        if (noOfItems == 1)
        {
            return "";
        }
        else
        {
            return "s";
        }
    }

    public static string TrimToLength(string str, int desiredLength)
    {
        if (str.Length > desiredLength)
        {
            str = str.Substring(0, desiredLength);
        }
        return str;
    }

    public static string RemoveTrailingSpaces(string str)
    {
        while (RightMost(str, 1) == " ")
        {
            // remove any trailing space characters
            str = LeftMost(str, str.Length - 1);
        }
        return str;
    }

    public static string RemoveLeadingSpaces(string str)
    {
        while (LeftMost(str, 1) == " ")
        {
            // remove any trailing space characters
            str = RightMost(str, str.Length - 1);
        }
        return str;
    }

    /// <summary>
    /// Returns leftmost [charCount] characters from str
    /// </summary>
    public static string LeftMost(string str, int charCount)
    {
        if (string.IsNullOrEmpty(str))
        {
            str = string.Empty;
        }
        else if (str.Length > charCount)
        {
            str = str.Substring(0, charCount);
        }
        return str;
    }

    /// <summary>
    /// Returns rightmost [charCount] characters from str
    /// </summary>
    public static string RightMost(string str, int charCount)
    {
        if (string.IsNullOrEmpty(str))
        {
            str = string.Empty;
        }
        else if (str.Length > charCount)
        {
            str = str.Substring(str.Length - charCount, charCount);
        }
        return str;
    }

    /// <summary>
    /// Returns all characters to right of specified character, if it exists
    /// </summary>
    public static string RightOfChar(string str, char character)
    {
        while (LeftMost(str, 1) != character.ToString() && str.Length > 1)
        {
            str = RightMost(str, str.Length - 1);
            if (str.Length == 1)
            {
                return "";
            }
        }
        return RightMost(str, str.Length - 1);
    }

    /// <summary>
    /// Return all characters to right of specified character, if it exists
    /// </summary>
    public static string LeftOfChar(string str, char character)
    {
        while (RightMost(str, 1) != character.ToString() && str.Length > 1)
        {
            str = LeftMost(str, str.Length - 1);
            if (str.Length == 1)
            {
                return "";
            }
        }
        return LeftMost(str, str.Length - 1);
    }

    /// <summary>
    /// Calculate sum of ascii values in byte array
    /// </summary>
    public static int CharacterSum(byte[] asciiValue, int length)
    {
        int sum = 0;
        for (int charNo = 0; charNo < length; charNo++)
        {
            sum += asciiValue[charNo];
        }
        return sum;
    }
}