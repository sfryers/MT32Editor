namespace MT32Edit;

/// <summary>
/// Data structure representing user-accessible rhythm areas of MT-32, as per published MIDI implementation.
/// </summary>
public class Rhythm
{
    // MT32Edit: Rhythm class
    // S.Fryers Apr 2023

    private int timbreGroup = 1;

    private readonly string[] timbreGroupType = { "Memory", "Rhythm" };
    private int timbreNo = 0;
    private int panPot = 0;
    private int outputLevel = 80;
    private bool reverbEnabled = true;

    private DateTime timeOfLastFullUpdate = DateTime.Now;

    public Rhythm(int keyNo, bool autoCorrect = false)
    {
        keyNo = LogicTools.ValidateRange("keyNo", keyNo, minPermitted: RhythmConstants.KEY_OFFSET, maxPermitted: 108, autoCorrect);
        timbreGroup = 1;
        timbreNo = RhythmConstants.defaultSampleNo[keyNo - RhythmConstants.KEY_OFFSET];
        panPot = RhythmConstants.defaultPanPosition[keyNo - RhythmConstants.KEY_OFFSET];
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
                return (timbreGroup * 64) + timbreNo;

            case 1:
                return outputLevel;

            case 2:
                return panPot + RhythmConstants.PANPOT_OFFSET;

            case 3:
                if (reverbEnabled)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

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
                SetTimbreNoAndGroup(parameterValue, autoCorrect);
                return;

            case 1:
                SetOutputLevel(parameterValue, autoCorrect);
                return;

            case 2:
                SetPanPot(parameterValue, autoCorrect);
                return;

            case 3:
                if (parameterValue == 1)
                {
                    SetReverbEnabled(true);
                }
                else
                {
                    SetReverbEnabled(false);
                }

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
                SetTimbreNoAndGroup(parameterValue, autoCorrect);
                return;

            case 1:
                SetOutputLevel(parameterValue, autoCorrect);
                return;

            case 2:
                SetPanPot(parameterValue - RhythmConstants.PANPOT_OFFSET, autoCorrect);
                return;

            case 3:
                if (parameterValue == 1)
                {
                    SetReverbEnabled(true);
                }
                else
                {
                    SetReverbEnabled(false);
                }

                return;

            default:
                InvalidParameterNo(parameterNo);
                return;
        }
    }

    private void InvalidParameterNo(int parameterNo)
    {
        throw new ArgumentOutOfRangeException("Specified Parameter no. (" + parameterNo + ") is outside of the permitted range (0-3)");
    }

    public void SetTimbreNoAndGroup(int parameterValue, bool autoCorrect = false)
    {
        parameterValue = LogicTools.ValidateRange("Timbre no.", parameterValue, minPermitted: 0, maxPermitted: 127, autoCorrect);
        if (parameterValue < 64)
        {
            SetTimbreGroup(0);
            SetTimbreNo(parameterValue);
        }
        else
        {
            SetTimbreGroup(1);
            SetTimbreNo(parameterValue - 64);
        }
    }

    public int GetTimbreGroup()
    {
        return timbreGroup;
    }

    public void SetTimbreGroup(int groupNo, bool autoCorrect = false)
    {
        timbreGroup = LogicTools.ValidateRange("Timbre Group", groupNo, minPermitted: 0, maxPermitted: 1, autoCorrect);
    }

    public string GetTimbreGroupType()
    {
        return timbreGroupType[timbreGroup];
    }

    public void SetTimbreNo(int timbre, bool autoCorrect = false)
    {
        timbreNo = LogicTools.ValidateRange("Timbre No", timbre, minPermitted: 0, maxPermitted: 63, autoCorrect);
    }

    public int GetTimbreNo()
    {
        return timbreNo;
    }

    public void SetPanPot(int panPotValue, bool autoCorrect = false)
    {
        panPot = LogicTools.ValidateRange("Pan pot value", panPotValue, minPermitted: -7, maxPermitted: 7, autoCorrect);
    }

    public int GetPanPot()
    {
        return panPot;
    }

    public void SetOutputLevel(int level, bool autoCorrect = false)
    {
        outputLevel = LogicTools.ValidateRange("Output Level", level, minPermitted: 0, maxPermitted: 100, autoCorrect);
    }

    public int GetOutputLevel()
    {
        return outputLevel;
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