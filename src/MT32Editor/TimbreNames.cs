namespace MT32Edit;

public class TimbreNames
{
    //
    // MT32Edit: TimbreNames class (static)
    // S.Fryers Apr 2023
    // Data class containing names of MT-32 memory timbres and an interface to static read-only class PresetTimbreNames.
    //
    private const string EMPTY = MT32Strings.EMPTY;

    private readonly string[] memoryGroup =               {
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                                 EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY
                                                 }; //64 members

    public string Get(int timbreNo, int group = -1)
    {
        LogicTools.ValidateRange("Group No.", group, -1, 3, autoCorrect: false);
        switch (group)
        {
            case 0:
                LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
                return PresetTimbreNames.GetPresetA(timbreNo);

            case 1:
                LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
                return PresetTimbreNames.GetPresetB(timbreNo);

            case 2:
                LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
                return memoryGroup[timbreNo];

            case 3:
                LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
                if (timbreNo == 63)
                {
                    return "[none]";
                }
                else
                {
                    return PresetTimbreNames.GetRhythm(timbreNo);
                }

            default:
                LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 127, autoCorrect: false);
                if (timbreNo < 64)
                {
                    return PresetTimbreNames.GetPresetA(timbreNo);
                }
                else
                {
                    return PresetTimbreNames.GetPresetB(timbreNo - 64);
                }
        }
    }

    public string[] GetAll(int group)
    {
        LogicTools.ValidateRange("Group No.", group, 0, 3, autoCorrect: false);
        switch (group)
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
        LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
        memoryGroup[timbreNo] = ParseTools.RemoveTrailingSpaces(ParseTools.MakeNCharsLong(timbreName, 10));
    }

    public void ResetMemoryTimbreName(int timbreNo)
    {
        LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
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