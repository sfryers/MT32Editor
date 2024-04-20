using System.Text;

namespace MT32Edit_legacy;

/// <summary>
/// Simple tools for parsing text strings
/// </summary>
internal static class ParseTools
{
    // MT32Edit: ParseTools class (static)
    // S.Fryers Apr 2024
   
    /// <summary>
    /// Ensures str is precisely the desiredLength by adding spaces or removing excess characters from right hand side
    /// </summary>
    public static string MakeNCharsLong(string str, int desiredLength)
    {
        str = PadWithSpace(str, desiredLength);
        str = TrimToLength(str, desiredLength);
        return str;
    }

    /// <summary>
    /// Adds spaces to end of str to pad it to the desiredLength
    /// </summary>
    public static string PadWithSpace(string str, int desiredLength)
    {
        StringBuilder outputString = new StringBuilder();
        outputString.Append(str);
        while (outputString.Length < desiredLength)
        {
            outputString.Append(" ");
        }
        return outputString.ToString();
    }

    /// <summary>
    /// Helps format text for plural instances - returns string "s" if input value is exactly 1, otherwise returns null string
    /// </summary>
    public static string Pluralise(int noOfItems)
    {
        return noOfItems == 1 ? string.Empty : "s";
    }

    /// <summary>
    /// Returns asterisk character for window title bar if changes have been made
    /// </summary>
    public static string UnsavedEdits(bool changesMade)
    {
        return changesMade ? "*" : string.Empty;
    }

    /// <summary>
    /// Trims str to desiredLength
    /// </summary>
    public static string TrimToLength(string str, int desiredLength)
    {
        if (str.Length > desiredLength)
        {
            str = str.Substring(0, desiredLength);
        }
        return str;
    }

    /// <summary>
    /// Removes any trailing space or null characters from str
    /// </summary>
    public static string RemoveTrailingSpaces(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        str = ReplaceNullsWithSpaces(str);
        return str.TrimEnd();
    }

    /// <summary>
    /// Removes any leading space or null characters from str
    /// </summary>
    public static string RemoveLeadingSpaces(string str)
    {
        str = ReplaceNullsWithSpaces(str);
        while (LeftMost(str, 1) == " ")
        {
            str = RightMost(str, str.Length - 1);
        }
        return str;
    }

    /// <summary>
    /// Replaces any null characters in str with space characters
    /// </summary>
    public static string ReplaceNullsWithSpaces(string str)
    {
        return str.Replace("\0", " ");
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
                return string.Empty;
            }
        }
        return RightMost(str, str.Length - 1);
    }

    /// <summary>
    /// Return all characters to left of specified character, if it exists
    /// </summary>
    public static string LeftOfChar(string str, char character)
    {
        while (RightMost(str, 1) != character.ToString() && str.Length > 1)
        {
            str = LeftMost(str, str.Length - 1);
            if (str.Length == 1)
            {
                return string.Empty;
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

    /// <summary>
    /// Returns true if line ends with string "true", 
    /// false if line ends with string "false",
    /// Any other value returns null.
    /// Function is not case sensitive.
    /// </summary>
    public static bool? StringToBool(string str)
    {
        if (RightMost(str.ToLower(), true.ToString().Length) == true.ToString().ToLower())
        {
            return true;
        }
        else if (RightMost(str.ToLower(), false.ToString().Length) == false.ToString().ToLower())
        {
            return false;
        }
        else
        {
            return null;
        }
    }

    public static string Architecture()
    {
        return IntPtr.Size == 8 ? "x64" : "x86";
    }

    public static string GetVersion(string version)
    {
        return $"{version}_{Architecture()}";
    }
}