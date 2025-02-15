using System.Text;
using System;
#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Data structure representing user-accessible timbre memory areas of MT-32, 
/// as per published Roland MIDI implementation.
/// </summary>
public class TimbreStructure
{
    // MT32Edit: TimbreStructure class
    // S.Fryers May 2024

    //each timbre consists of (up to) 4 partials
    public const int NO_OF_PARTIALS = 4;

    //each partial contains 58 (0x3A) parameters
    public const int NO_OF_PARAMETERS = 58;

    public const string NEW_TIMBRE = "New Timbre";

    private string timbreName = string.Empty;
    private int part12Structure;
    private int part34Structure;
    private int activePartial = 0;
    private bool[] partialMuteStatus = new bool[NO_OF_PARTIALS];
    private bool sustain;
    private readonly byte[,] partial = new byte[NO_OF_PARTIALS, NO_OF_PARAMETERS];
    private DateTime timeOfLastFullUpdate;

    public TimbreStructure(bool createAudibleTimbre)
    {
        SetDefaultTimbreParameters(createAudibleTimbre);
    }

    /// <summary>
    /// Configures timbre parameters to create a basic saw wave sound.
    /// If createAudibleTimbre is set to true, partial 1 is unmuted.
    /// If set to false, all partials are muted.
    /// </summary>
    /// <param name="createAudibleTimbre"></param>
    public void SetDefaultTimbreParameters(bool createAudibleTimbre)
    {
        if (createAudibleTimbre)
        {
            timbreName = NEW_TIMBRE;

            //false = not muted, true = muted
            partialMuteStatus = new bool[] { false, true, true, true };
        }
        else
        {
            timbreName = ParseTools.MakeNCharsLong(MT32Strings.EMPTY, 10);

            //all partials muted
            partialMuteStatus = new bool[] { true, true, true, true };
        }
        activePartial = 0;
        part12Structure = 0;
        part34Structure = 0;
        sustain = true;
        for (int partialNo = 0; partialNo < NO_OF_PARTIALS; partialNo++)
        {
            SetDefaultPartialValues(partialNo);
        }
        timeOfLastFullUpdate = DateTime.Now;
    }

    private void SetDefaultPartialValues(int partialNo)
    {
        for (int parameterNo = 0; parameterNo < NO_OF_PARAMETERS; parameterNo++)
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

    public int GetActivePartial()
    {
        return activePartial;
    }

    public void SetActivePartial(int partialNo)
    {
        activePartial = ValidatePartialNo(partialNo);
    }

    public void SetPart12Structure(int structure, bool autoCorrect = false)
    {
        part12Structure = ValidateStructureNo(structure, autoCorrect);
    }

    public void SetPart34Structure(int structure, bool autoCorrect = false)
    {
        part34Structure = ValidateStructureNo(structure, autoCorrect);
    }

    private bool IsPCM(int partialNo)
    {
        int structure = partialNo < 2 ? part12Structure : part34Structure;

        if (partialNo == 0 || partialNo == 2)
        {
            switch (structure)
            {
                case 0:
                case 1:
                case 4:
                case 7:
                case 9:
                case 11: //structure nos. with S on left hand side
                    return false;

                default:
                    return true;
            }
        }
        else
        {
            switch (structure)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 7:
                case 9:
                case 10: //structure nos. with S on right hand side
                    return false;

                default:
                    return true;
            }
        }
    }

    private int ValidateStructureNo(int structure, bool autoCorrect)
    {
        return LogicTools.ValidateRange("Structure No.", structure, minPermitted: 0, maxPermitted: 12, autoCorrect);
    }

    private int ValidatePartialNo(int partialNo)
    {
        return LogicTools.ValidateRange("Partial No.", partialNo, minPermitted: 0, maxPermitted: 3, autoCorrect: false);
    }

    private void ValidateParameterNo(int parameterNo)
    {
        LogicTools.ValidateRange("Parameter No.", parameterNo, minPermitted: 0, maxPermitted: 57, autoCorrect: false);
    }

    public bool[] GetPartialMuteStatus()
    {
        return partialMuteStatus;
    }

    public void SetPartialMuteStatus(int partialNo, bool newStatus, bool autoCorrect = false)
    {
        ValidatePartialNo(partialNo);
        bool initialStatus = partialMuteStatus[partialNo];
        partialMuteStatus[partialNo] = newStatus;
        if (newStatus != initialStatus)
        {
            MT32SysEx.UpdatePartialMuteStatus(partialMuteStatus, partialNo);
        }
    }

    public bool GetSustainStatus()
    {
        return sustain;
    }

    public void SetSustainStatus(bool status)
    {
        sustain = status;
    }

    public string GetParameterName(int parameterNo)
    {
        return MT32Strings.partialParameterNames[parameterNo];
    }

    public bool ContainsCM32LSamples()
    {
        for (int partialNo = 0; partialNo < NO_OF_PARTIALS; partialNo++)
        {
            if (IsPCM(partialNo) && GetPCMBankNo(partialNo) == 1)
            {
                return true;
            }
        }
        return false;
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

    /// <summary>
    /// Returns the number of the PCM Bank currently assigned to the specified partial
    /// </summary>
    public int GetPCMBankNo(int partialNo)
    {
        ValidatePartialNo(partialNo);
        switch (partial[partialNo, 0x04])
        {
            case 2:
            case 3:
                return 1;
            default:
                return 0;
        }
    }

    /// <summary>
    /// Returns parameter value with appropriate offset for UI controls that permit negative values
    /// </summary>
    public int GetUIParameter(int partialNo, int parameterNo)
    {
        ValidatePartialNo(partialNo);
        ValidateParameterNo(parameterNo);
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

    /// <summary>
    /// Copies the specified partial.
    /// </summary>
    /// <returns>
    /// Byte array containing the specified partial parameter values.
    /// </returns>
    public byte[] CopyPartial(int partialNo)
    {
        ValidatePartialNo(partialNo);
        byte[] partialValues = new byte[NO_OF_PARAMETERS];
        for (int parameterNo = 0; parameterNo < NO_OF_PARAMETERS; parameterNo++)
        {
            partialValues[parameterNo] = partial[partialNo, parameterNo];
        }
        return partialValues;
    }

    /// <summary>
    /// Pastes the provided partial parameter values into the specified partial.
    /// </summary>
    public void PastePartial(int partialNo, byte[] partialValues)
    {
        ValidatePartialNo(partialNo);
        for (int parameterNo = 0; parameterNo < NO_OF_PARAMETERS; parameterNo++)
        {
            partial[partialNo, parameterNo] = partialValues[parameterNo];
        }
    }

    /// <summary>
    /// Returns an exact clone of the current timbre
    /// </summary>
    public TimbreStructure Clone()
    {
        TimbreStructure clonedTimbre = new TimbreStructure(false);
        clonedTimbre.SetTimbreName(timbreName);
        clonedTimbre.SetPart12Structure(part12Structure);
        clonedTimbre.SetPart34Structure(part34Structure);
        clonedTimbre.SetSustainStatus(sustain);
        clonedTimbre.timeOfLastFullUpdate = timeOfLastFullUpdate;
        clonedTimbre.SetActivePartial(activePartial);
        for (int partialNo = 0; partialNo < NO_OF_PARTIALS; partialNo++)
        {
            clonedTimbre.partialMuteStatus[partialNo] = partialMuteStatus[partialNo];
            ClonePartial(partialNo);
        }
        return clonedTimbre;

        void ClonePartial(int partialNo)
        {
            for (int parameterNo = 0; parameterNo < NO_OF_PARAMETERS; parameterNo++)
            {
                clonedTimbre.SetSysExParameter(partialNo, parameterNo, partial[partialNo, parameterNo]);
            }
        }
    }

    /// <summary>
    /// Returns a 64-bit checksum derived from all timbre parameter values
    /// </summary>
    public long CheckSum()
    {
        long checkSum = SumOfTimbreNameCharacters() + ((part12Structure + 1) * 8192) + ((part34Structure + 1) * 32768) + (LogicTools.BoolToInt(sustain) * 131072) + (activePartial * 262144);
        for (int i = 0; i < NO_OF_PARTIALS; i++)
        {
            checkSum += SumOfParameterValues(i);
            checkSum *= (i + 1) * (LogicTools.BoolToInt(partialMuteStatus[i]) + 1);
        }
        return checkSum;

        long SumOfParameterValues(int partialNo)
        {
            long sum = 0;
            for (int i = 0; i < NO_OF_PARAMETERS; i++)
            {
                sum += (long)partial[partialNo, i] * (partialNo + ((i + 1) * NO_OF_PARAMETERS)) * 128;
            }
            return sum;
        }

        long SumOfTimbreNameCharacters()
        {
            byte[] timbreNameCharacterValues = Encoding.ASCII.GetBytes(timbreName);
            if (timbreNameCharacterValues.Length == 0)
            {
                return 0;
            }
            long sum = 0;
            for (int i = 0; i < timbreNameCharacterValues.Length; i++)
            {
                sum += timbreNameCharacterValues[i] * ((i + 1) * 4096);
            }
            return sum;
        }
    }
}