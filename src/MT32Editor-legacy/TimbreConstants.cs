#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Static class containing constant values for MT-32 memory structure sizes
/// </summary>

internal static class TimbreConstants
{
    // MT32Edit: TimbreConstants class (static)
    // S.Fryers Mar 2026

    //each timbre group contains 64 (preset, memory or rhythm) timbres
    public const int NO_OF_TIMBRES_PER_GROUP = 64;

    //4 timbre groups exist: Preset A, Preset B, Memory, Rhythm
    public const int NO_OF_TIMBRE_GROUPS = 4;

    //each timbre consists of (up to) 4 partials
    public const int NO_OF_PARTIALS = 4;

    //each partial contains 58 (0x3A) parameters
    public const int NO_OF_PARTIAL_PARAMETERS = 58;

    public const int TIMBRE_NAME_LENGTH = 10;

}
