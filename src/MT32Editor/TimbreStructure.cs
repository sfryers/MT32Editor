namespace MT32Edit;

/// <summary>
/// Data structure representing user-accessible timbre memory areas of MT-32, as per published
/// Roland MIDI implementation.
/// </summary>
public class TimbreStructure
{
    // MT32Edit: TimbreStructure class S.Fryers Apr 2023 Data structure representing user-accessible
    // timbre memory areas of MT-32, as per published Roland MIDI implementation.

    //each timbre consists of (up to) 4 partials
    public const int PARTIALS = 4;

    //each partial contains 58 (0x3A) parameters
    public const int PARAMETERS = 58;

    private string timbreName = string.Empty;
    private int part12Structure;
    private int part34Structure;
    private bool[] partialMuteStatus = new bool[4];
    private bool sustain;
    private readonly byte[,] partial = new byte[PARTIALS, PARAMETERS];
    private DateTime timeOfLastFullUpdate;

    public TimbreStructure(bool createAudibleTimbre)
    {
        SetDefaultTimbreParameters(createAudibleTimbre);
    }

    public void SetDefaultTimbreParameters(bool createAudibleTimbre)
    {
        if (createAudibleTimbre)
        {
            timbreName = "New Timbre";

            //false = not muted, true = muted
            partialMuteStatus = new bool[] { false, true, true, true };
        }
        else
        {
            timbreName = ParseTools.MakeNCharsLong(MT32Strings.EMPTY, 10);

            //all partials muted
            partialMuteStatus = new bool[] { true, true, true, true };
        }
        part12Structure = 0;
        part34Structure = 0;
        sustain = true;
        for (int partialNo = 0; partialNo < PARTIALS; partialNo++)
        {
            SetDefaultPartialValues(partialNo);
        }
        timeOfLastFullUpdate = DateTime.Now;
    }

    public void SetDefaultPartialValues(int partialNo)
    {
        for (int parameterNo = 0; parameterNo < PARAMETERS; parameterNo++)
        {
            partial[partialNo, parameterNo] = PartialConstants.defaultValue[parameterNo];
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

    public string GetTimbreName()
    {
        return ParseTools.RemoveTrailingSpaces(timbreName);
    }

    public void SetTimbreName(string name)
    {
        timbreName = ParseTools.MakeNCharsLong(name, 10);
    }

    public int GetPart12Structure()
    {
        return part12Structure;
    }

    public int GetPart34Structure()
    {
        return part34Structure;
    }

    public void SetPart12Structure(int structure, bool autoCorrect = false)
    {
        part12Structure = ValidateStructureNo(structure, autoCorrect);
    }

    public void SetPart34Structure(int structure, bool autoCorrect = false)
    {
        part34Structure = ValidateStructureNo(structure, autoCorrect);
    }

    private int ValidateStructureNo(int structure, bool autoCorrect)
    {
        return LogicTools.ValidateRange("Structure No.", structure, minPermitted: 0, maxPermitted: 12, autoCorrect);
    }

    private void ValidatePartialNo(int partialNo)
    {
        LogicTools.ValidateRange("Partial No.", partialNo, minPermitted: 0, maxPermitted: 3, autoCorrect: false);
    }

    private void ValidateParameterNo(int parameterNo)
    {
        LogicTools.ValidateRange("Parameter No.", parameterNo, minPermitted: 0, maxPermitted: 57, autoCorrect: false);
    }

    public bool[] GetPartialMuteStatus()
    {
        return partialMuteStatus;
    }

    public void SetPartialMuteStatus(int partial, bool newStatus, bool autoCorrect = false)
    {
        ValidatePartialNo(partial);
        bool initialStatus = partialMuteStatus[partial];
        partialMuteStatus[partial] = newStatus;
        if (newStatus != initialStatus)
        {
            MT32SysEx.UpdatePartialMuteStatus(partialMuteStatus, partial);
        }
    }

    public void FlipPartialMuteStatus(int partial, bool autoCorrect = false)
    {
        ValidatePartialNo(partial);
        partialMuteStatus[partial] ^= true;
        MT32SysEx.UpdatePartialMuteStatus(partialMuteStatus, partial);
    }

    public bool GetSustainStatus()
    {
        return sustain;
    }

    public void SetSustainStatus(bool status)
    {
        sustain = status;
    }

    public void FlipSustainStatus()
    {
        sustain ^= true;
    }

    public string GetParameterName(int parameterNo)
    {
        return MT32Strings.partialParameterNames[parameterNo];
    }

    /// <summary>
    /// Returns parameter byte value
    /// </summary>
    public byte GetSysExParameter(int partialNo, int parameterNo)
    {
        ValidatePartialNo(partialNo);
        return partial[partialNo, parameterNo];
    }

    /// <summary>
    /// Set parameter byte value, restricting value to valid range
    /// </summary>
    public void SetSysExParameter(int partialNo, int parameterNo, int value)
    {
        ValidatePartialNo(partialNo);
        ValidateParameterNo(parameterNo);
        if (value < 0)
        {
            partial[partialNo, parameterNo] = 0;
        }
        else if (value > PartialConstants.maxValue[parameterNo])
        {
            partial[partialNo, parameterNo] = PartialConstants.maxValue[parameterNo];
        }
        else
        {
            partial[partialNo, parameterNo] = (byte)value;
        }
    }

    public int GetPCMBankNo(int partialNo)
    {
        ValidatePartialNo(partialNo);
        int bankNo = 0;
        if (partial[partialNo, 0x04] > 1)
        {
            bankNo = 1;
        }

        return bankNo;
    }

    public int GetUIParameter(int partialNo, int parameterNo)
    {
        ValidatePartialNo(partialNo);
        ValidateParameterNo(parameterNo);

        //return parameter value with appropriate offset for UI controls that permit negative values
        return partial[partialNo, parameterNo] - PartialConstants.offset[parameterNo];
    }

    /// <summary>
    /// Set parameter UI value, restricting input range and applying correct offset value
    /// </summary>
    public void SetUIParameter(int partialNo, int parameterNo, int value)
    {
        ValidatePartialNo(partialNo);
        ValidateParameterNo(parameterNo);
        if (value + PartialConstants.offset[parameterNo] < 0)
        {
            partial[partialNo, parameterNo] = 0;
        }
        else if (value > PartialConstants.maxValue[parameterNo] + PartialConstants.offset[parameterNo])
        {
            partial[partialNo, parameterNo] = PartialConstants.maxValue[parameterNo];
        }
        else
        {
            partial[partialNo, parameterNo] = (byte)(value + PartialConstants.offset[parameterNo]);
        }
    }

    public byte[] CopyPartial(int partialNo)
    {
        ValidatePartialNo(partialNo);
        byte[] partialValues = new byte[PARAMETERS];
        for (int parameterNo = 0; parameterNo < PARAMETERS; parameterNo++)
        {
            partialValues[parameterNo] = partial[partialNo, parameterNo];
        }
        return partialValues;
    }

    public void PastePartial(int partialNo, byte[] partialValues)
    {
        ValidatePartialNo(partialNo);
        for (int parameterNo = 0; parameterNo < PARAMETERS; parameterNo++)
        {
            partial[partialNo, parameterNo] = partialValues[parameterNo];
        }
    }

    public TimbreStructure Clone()
    {
        TimbreStructure clonedTimbre = new TimbreStructure(false);
        clonedTimbre.timbreName = timbreName;
        clonedTimbre.part12Structure = part12Structure;
        clonedTimbre.part34Structure = part34Structure;
        clonedTimbre.sustain = sustain;
        clonedTimbre.timeOfLastFullUpdate = timeOfLastFullUpdate;
        for (int partialNo = 0; partialNo < PARTIALS; partialNo++)
        {
            clonedTimbre.partialMuteStatus[partialNo] = partialMuteStatus[partialNo];
            for (int parameterNo = 0; parameterNo < PARAMETERS; parameterNo++)
            {
                clonedTimbre.partial[partialNo, parameterNo] = partial[partialNo, parameterNo];
            }
        }
        return clonedTimbre;
    }
}