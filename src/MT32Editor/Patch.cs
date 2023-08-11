namespace MT32Edit;

public class Patch
{
    //
    // MT32Edit: Patch class
    // S.Fryers Mar 2023
    // Data structure representing user-accessible patch memory areas of MT-32, as per published MIDI implementation.
    //
    private int timbreGroup = 0;

    private readonly string[] timbreGroupType = { "Preset A", "Preset B", "Memory", "Rhythm" };
    private readonly string[] assignModeType = { "Single Assign", "Multi Assign", "First In, First Out", "First In, Last Out" };
    private int timbreNo = 0;
    private int keyShift = 0;
    private int fineTune = 0;
    private int benderRange = 12;
    private int assignMode = 0;
    private bool reverbEnabled = true;
    private const int keyShiftOffset = 24;
    private const int fineTuneOffset = 50;
    private DateTime timeOfLastFullUpdate = DateTime.Now;

    public Patch(int patchNo, bool autoCorrect = false)
    {
        patchNo = LogicTools.ValidateRange("Patch No.", patchNo, minPermitted: 0, maxPermitted: 127, autoCorrect);
        if (patchNo < 64)
        {
            timbreGroup = 0;
            timbreNo = patchNo;
        }
        else
        {
            timbreGroup = 1;
            timbreNo = patchNo - 64;
        }
    }

    public DateTime GetUpdateTime()
    {
        return timeOfLastFullUpdate;
    }

    public void SetUpdateTime()
    {
        timeOfLastFullUpdate = DateTime.Now;
    }

    public int GetParameterSysExValue(int parameterNo)
    {
        switch (parameterNo)
        {
            case 0:
                return timbreGroup;

            case 1:
                return timbreNo;

            case 2:
                return keyShift + keyShiftOffset;

            case 3:
                return fineTune + fineTuneOffset;

            case 4:
                return benderRange;

            case 5:
                return assignMode;

            case 6:
                if (reverbEnabled)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            case 7:
                return 0;

            default:
                InvalidParameterNo(parameterNo);
                return 0;
        }
    }

    public int GetParameterUIValue(int parameterNo)
    {
        switch (parameterNo)
        {
            case 0:
                return timbreGroup;

            case 1:
                return timbreNo;

            case 2:
                return keyShift;

            case 3:
                return fineTune;

            case 4:
                return benderRange;

            case 5:
                return assignMode;

            case 6:
                if (reverbEnabled)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            case 7:
                return 0;

            default:
                InvalidParameterNo(parameterNo);
                return 0;
        }
    }

    public void SetParameterUIValue(int parameterNo, int parameterValue, bool autoCorrect = false)
    {
        switch (parameterNo)
        {
            case 0:
                SetTimbreGroup(parameterValue, autoCorrect);
                return;

            case 1:
                SetTimbreNo(parameterValue, autoCorrect);
                return;

            case 2:
                SetKeyShift(parameterValue, autoCorrect);
                return;

            case 3:
                SetFineTune(parameterValue, autoCorrect);
                return;

            case 4:
                SetBenderRange(parameterValue, autoCorrect);
                return;

            case 5:
                SetAssignMode(parameterValue, autoCorrect);
                return;

            case 6:
                if (parameterValue == 1)
                {
                    SetReverbEnabled(true);
                }
                else
                {
                    SetReverbEnabled(false);
                }

                return;

            case 7:
                return;

            default:
                InvalidParameterNo(parameterNo);
                return;
        }
    }

    public void SetParameterSysExValue(int parameterNo, int parameterValue, bool autoCorrect = false)
    {
        switch (parameterNo)
        {
            case 0:
                SetTimbreGroup(parameterValue, autoCorrect);
                return;

            case 1:
                SetTimbreNo(parameterValue, autoCorrect);
                return;

            case 2:
                SetKeyShift(parameterValue - keyShiftOffset, autoCorrect);
                return;

            case 3:
                SetFineTune(parameterValue - fineTuneOffset, autoCorrect);
                return;

            case 4:
                SetBenderRange(parameterValue, autoCorrect);
                return;

            case 5:
                SetAssignMode(parameterValue, autoCorrect);
                return;

            case 6:
                if (parameterValue == 1)
                {
                    SetReverbEnabled(true);
                }
                else
                {
                    SetReverbEnabled(false);
                }

                return;

            case 7:
                return;

            default:
                InvalidParameterNo(parameterNo);
                return;
        }
    }

    private void InvalidParameterNo(int parameterNo)
    {
        throw new ArgumentOutOfRangeException("Specified Parameter no. (" + parameterNo + ") is outside of the permitted range (0-7)");
    }

    public int GetTimbreGroup()
    {
        return timbreGroup;
    }

    public void SetTimbreGroup(int groupNo, bool autoCorrect = false)
    {
        timbreGroup = LogicTools.ValidateRange("Timbre Group", groupNo, minPermitted: 0, maxPermitted: 3, autoCorrect);
    }

    public string GetTimbreGroupType()
    {
        return timbreGroupType[timbreGroup];
    }

    public void SetTimbreNo(int timbre, bool autoCorrect = false)
    {
        timbreNo = LogicTools.ValidateRange("Timbre No.", timbre, minPermitted: 0, maxPermitted: 63, autoCorrect);
    }

    public int GetTimbreNo()
    {
        return timbreNo;
    }

    public void SetKeyShift(int keyShiftValue, bool autoCorrect = false)
    {
        keyShift = LogicTools.ValidateRange("Key Shift", keyShiftValue, minPermitted: -24, maxPermitted: 24, autoCorrect);
    }

    public int GetKeyShift()
    {
        return keyShift;
    }

    public void SetFineTune(int fineTuneValue, bool autoCorrect = false)
    {
        fineTune = LogicTools.ValidateRange("Fine Tune", fineTuneValue, minPermitted: -50, maxPermitted: 50, autoCorrect);
    }

    public int GetFineTune()
    {
        return fineTune;
    }

    public void SetBenderRange(int benderRangeValue, bool autoCorrect = false)
    {
        benderRange = LogicTools.ValidateRange("Bender Range", benderRangeValue, minPermitted: 0, maxPermitted: 24, autoCorrect);
    }

    public int GetBenderRange()
    {
        return benderRange;
    }

    public void SetAssignMode(int assignModeValue, bool autoCorrect = false)
    {
        assignMode = LogicTools.ValidateRange("Assign Mode", assignModeValue, minPermitted: 0, maxPermitted: 3, autoCorrect);
    }

    public int GetAssignMode()
    {
        return assignMode;
    }

    public string GetAssignModeType()
    {
        return assignModeType[assignMode];
    }

    public void SetReverbEnabled(bool reverbOn)
    {
        reverbEnabled = reverbOn;
    }

    public bool GetReverbEnabled()
    {
        return reverbEnabled;
    }
}