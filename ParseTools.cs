namespace MT32Edit
{
    internal static class ParseTools
    {
        //
        // MT32Edit: ParseTools class (static)
        // S.Fryers Mar 2023
        // Simple tools for parsing text strings
        //
        public static string MakeNCharsLong(string str, int desiredLength) //ensure string is precisely the desiredLength by adding spaces or removing excess characters from right hand side
        {
            str = PadWithSpace(str, desiredLength);
            str = TrimToLength(str, desiredLength);
            return str;
        }

        public static string PadWithSpace(string str, int desiredLength) //adds spaces to end of string to pad it to the desiredLength
        {
            while (str.Length < desiredLength)
            {
                str += " ";
            }
            return str;
        }

        public static string Plural(int noOfItems) //helps format text for plural instances- returns string "s" if input value is exactly 1, otherwise returns null string
        {
            if (noOfItems == 1) return "";
            else return "s";
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
                str = LeftMost(str, str.Length - 1); //remove any trailing space characters
            }
            return str;
        }

        public static string RemoveLeadingSpaces(string str)
        {
            while (LeftMost(str, 1) == " ")
            {
                str = RightMost(str, str.Length - 1); //remove any trailing space characters
            }
            return str;
        }

        public static string LeftMost(string str, int charCount) //return leftmost [charCount] characters from str
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

        public static string RightMost(string str, int charCount) //return rightmost [charCount] characters from str
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

        public static string RightOfChar(string str, char character) //return all characters to right of specified character, if it exists
        {
            while (LeftMost(str, 1) != character.ToString() && str.Length > 1)
            {
                str = RightMost(str, str.Length - 1);
                if (str.Length == 1) return "";
            }
            return RightMost(str, str.Length - 1);
        }

        public static string LeftOfChar(string str, char character) //return all characters to right of specified character, if it exists
        {
            while (RightMost(str, 1) != character.ToString() && str.Length > 1)
            {
                str = LeftMost(str, str.Length - 1);
                if (str.Length == 1) return "";
            }
            return LeftMost(str, str.Length - 1);
        }

        public static int CharacterSum(byte[] asciiValue, int length) // calculate sum of ascii values in byte array
        {
            int sum = 0;
            for (int charNo = 0; charNo < length; charNo++)
            {
                sum += asciiValue[charNo];
            }
            return sum;
        }
    }
}
