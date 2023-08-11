namespace MT32Edit
{
    internal static class PartialConstants
    //
    // MT32Edit: PartialConstants class (static)
    // S.Fryers Feb 2023
    // Read-only data class containing default and maximum values for MT-32 partial parameters, plus offset values to transpose SysEx byte values to human-readable ones
    // (eg. valid SysEx data range for parameter 1, Fine Pitch, is 0-100. However this represents a value in the UI of -50 to +50, hence an offset value of 50 is used
    // for this parameter).
    //
    {
        public static readonly byte[] maxValue =
        {
             96, 100,  16,   1,   3, 127, 100,  14,  10,  14,   4, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,  30,  16, 127,  14, 100,
            100,   4,   4, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 127,  12, 127,  12,   4,   4, 100, 100, 100, 100, 100, 100, 100, 100, 100
        }; //maximum value MT-32 will accept for each parameter

        public static readonly byte[] offset =
        {
              0,  50,   0,   0,   0,   0,   0,   7,   0,   0,   0,   0,   0,   0,   0,  50,  50,  50,  50,  50,   0,   0,   0,   0,   0,   0,   0,   7,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  12,   0,  12,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0
        }; //zero point = maxValue - offset (parameters with an offset allow negative UI values). Minimum permitted parameter value = 0 - offset.

        public static readonly byte[] defaultValue =
        {
             36,  50,  11,   1,   1,  49,   0,   7,   0,   0,   0,   0,   0,   0,   0,  50,  50,  50,  50,  50,  60,   0, 100,  65,   0,  11,   0,   7, 100,
              0,   0,   0,   2,   0,   0,   0,   2, 100, 100, 100, 100,  70,  50,   0,  12,   0,  12,   0,   0,   2,   0,   0,   0,   2, 100, 100, 100, 100
        }; //'default' values for all 58 partial parameters: describes a basic saw wave tone with no filtering or modulation.
    }
}
