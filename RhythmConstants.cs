
namespace MT32Edit
{
    internal static class RhythmConstants
    {
        //
        // MT32Edit: RhythmConstants class (static)
        // S.Fryers Apr 2023
        // Read-only data class containing default values for MT-32 rhythm parameters.
        //

        public const int KEY_OFFSET = 24;    //lowest MIDI note no. to which a rhythm timbre can be allocated
        public const int PANPOT_OFFSET = 7;

        public static readonly byte[] defaultSampleNo =
        { 
            63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63,  0,  0, 10,  1, 11,
             5,  4,  6,  4, 29,  3,  7,  3,  2,  8,  2,  9, 63, 63, 22, 63,
            12, 63, 63, 63, 18, 19, 13, 14, 15, 16, 17, 20, 21, 27, 24, 26, 
            25, 28, 63, 23, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 
            42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 
            58, 59, 60, 61, 62
        };

        public static readonly int[] defaultPanPosition =
        {
             0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0, -1,
             1, -4,  1, -4,  1, -1,  1, -1,  4,  1,  4, -1,  0,  0, -2,  0,
             0,  0,  0,  0,  5,  3, -1, -2, -3,  0,  2,  5,  5, -2,  3, -2,
            -2, -3,  0, -5,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
             0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
             0,  0,  0,  0,  0
        };
    }
}
