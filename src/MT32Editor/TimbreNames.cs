#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Data class containing names of MT-32 memory timbres and an interface to static read-only class PresetTimbreNames.
/// </summary>
public class TimbreNames
{
    // MT32Edit: TimbreNames class
    // S.Fryers Feb 2025

    private const string EMPTY = MT32Strings.EMPTY;
    private const string NONE = MT32Strings.NONE;
    private const string TIMBRE = "Timbre No.";
    private const string GROUP = "Group No.";

    private string[] memoryGroup = {
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                    EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY
                                   }; //64 members

    public string Get(int timbreNo, int groupNo = -1)
    {
        LogicTools.ValidateRange(GROUP, groupNo, -1, 3, autoCorrect: false);
        switch (groupNo)
        {
            case 0:
                LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
                return PresetTimbreNames.GetPresetA(timbreNo);

            case 1:
                LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
                return PresetTimbreNames.GetPresetB(timbreNo);

            case 2:
                LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
                return memoryGroup[timbreNo];

            case 3:
                LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
                return timbreNo == 63 ? NONE : PresetTimbreNames.GetRhythm(timbreNo);

            default:
                LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 127, autoCorrect: false);
                return timbreNo < 64 ? PresetTimbreNames.GetPresetA(timbreNo) : PresetTimbreNames.GetPresetB(timbreNo - 64);
        }
    }

    public string[] GetAllWithIndices(int groupNo)
    {
        LogicTools.ValidateRange(GROUP, groupNo, 0, 3, autoCorrect: false);
        string[] list = GetAll(groupNo);
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = $"{i+1}: {list[i]}";
        }
        return list;
    }

    public string[] GetAll(int groupNo)
    {
        LogicTools.ValidateRange(GROUP, groupNo, 0, 3, autoCorrect: false);
        switch (groupNo)
        {
            case 0:
                return PresetTimbreNames.GetAllPresetA();

            case 1:
                return PresetTimbreNames.GetAllPresetB();

            case 2:
                return memoryGroup;

            default:
                return PresetTimbreNames.GetAllRhythm();
        }
    }

    public void SetMemoryTimbreName(string timbreName, int timbreNo)
    {
        LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
        memoryGroup[timbreNo] = ParseTools.RemoveTrailingSpaces(ParseTools.MakeNCharsLong(timbreName, 10));
    }

    public void ResetMemoryTimbreName(int timbreNo)
    {
        LogicTools.ValidateRange(TIMBRE, timbreNo, 0, 63, autoCorrect: false);
        memoryGroup[timbreNo] = MT32Strings.EMPTY;
    }

    public void ResetAllMemoryTimbreNames()
    {
        for (int timbreNo = 0; timbreNo < 64; timbreNo++)
        {
            ResetMemoryTimbreName(timbreNo);
        }
    }
}