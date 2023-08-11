namespace MT32Edit;

public class SystemLevel
{
    //
    // MT32Edit: SystemLevel class
    // S.Fryers Mar 2023
    // Data structure representing user-accessible system memory areas of MT-32, as per published MIDI implementation.
    // Note that temporary memory areas are not implemented, except for the Part 1 timbre temp area which is used by the Timbre Editor form.
    //
    private int masterTune = 63;

    private int masterLevel = 85;
    private int reverbType = 0;
    private int reverbTime = 5;
    private int reverbLevel = 5;
    private readonly string[] textMessage = { "", "" }; //Store up to 2 user messages to show on MT-32 display

    private readonly int[] defaultMidiChannel = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //1 = MIDI channel 2, 2 = MIDI channel 3, etc. - default MT-32/CM-32L configuration.
    private readonly int[] alternativeMidiChannel = { 0, 1, 2, 3, 4, 5, 6, 7, 9 }; //General MIDI compatible option, using MIDI channels 1-8 and 10.
    private readonly int[] defaultPartialReserve = { 3, 10, 6, 4, 3, 0, 0, 0, 6 }; //default values as shown on page 28 of MT-32 user manual
    private const float LOWEST_TUNING = (float)427.6;
    private const double HIGHEST_TUNING = (float)452.6;

    private readonly int[] midiChannel = new int[9];
    private readonly int[] partialReserve = new int[9];

    public SystemLevel()
    {
        for (int partNo = 0; partNo < 9; partNo++)
        {
            midiChannel[partNo] = defaultMidiChannel[partNo];
            partialReserve[partNo] = defaultPartialReserve[partNo];
        }
    }

    public void SetMasterLevel(int level, bool autoCorrect = false)
    {
        masterLevel = LogicTools.ValidateRange("Master Level", level, minPermitted: 0, maxPermitted: 100, autoCorrect);
    }

    public int GetMasterLevel()
    {
        return masterLevel;
    }

    public void SetMasterTune(int tune, bool autoCorrect = false)
    {
        masterTune = LogicTools.ValidateRange("Master Tune", tune, minPermitted: 0, maxPermitted: 127, autoCorrect);
    }

    public int GetMasterTune()
    {
        return masterTune;
    }

    public string GetMasterTuneFrequency()
    {
        double frequency = LOWEST_TUNING + (masterTune * (HIGHEST_TUNING - LOWEST_TUNING) / 127);
        return frequency.ToString("000.0") + "Hz";
    }

    public void SetReverbMode(int type, bool autoCorrect = false)
    {
        reverbType = LogicTools.ValidateRange("Reverb Type", type, minPermitted: 0, maxPermitted: 3, autoCorrect);
    }

    public int GetReverbMode()
    {
        return reverbType;
    }

    public string GetReverbModeName()
    {
        return MT32Strings.reverbTypeName[reverbType];
    }

    public void SetReverbTime(int time, bool autoCorrect = false)
    {
        reverbTime = LogicTools.ValidateRange("Reverb Time", time, minPermitted: 0, maxPermitted: 7, autoCorrect);
    }

    public int GetReverbTime()
    {
        return reverbTime;
    }

    public void SetReverbLevel(int level, bool autoCorrect = false)
    {
        reverbLevel = LogicTools.ValidateRange("Reverb Level", level, minPermitted: 0, maxPermitted: 7, autoCorrect);
    }

    public int GetReverbLevel()
    {
        return reverbLevel;
    }

    public byte[] GetReverbSysExValues()
    {
        byte[] sysExData = new byte[3];
        sysExData[0] = (byte)reverbType;
        sysExData[1] = (byte)reverbLevel;
        sysExData[2] = (byte)reverbTime;
        return sysExData;
    }

    public void SetSysExMidiChannel(int partNo, int midiChannelNo, bool autoCorrect = false) // permitted channel range 0-15
    {
        partNo = LogicTools.ValidateRange("Part No.", partNo, minPermitted: 0, maxPermitted: 8, autoCorrect);
        midiChannel[partNo] = LogicTools.ValidateRange("MIDI Channel No.", midiChannelNo, minPermitted: 0, maxPermitted: 15, autoCorrect);
    }

    public int GetSysExMidiChannel(int partNo)
    {
        partNo = LogicTools.ValidateRange("Part No.", partNo, minPermitted: 0, maxPermitted: 8, autoCorrect: false);
        return midiChannel[partNo];
    }

    public byte[] GetMidiChannelSysExValues()
    {
        byte[] sysExData = new byte[9];
        for (int part = 0; part < 9; part++)
        {
            sysExData[part] = (byte)midiChannel[part];
        }
        return sysExData;
    }

    public void SetUIMidiChannel(int partNo, int midiChannelNo, bool autoCorrect = false) // permitted channel range 1-16
    {
        partNo = LogicTools.ValidateRange("Part No.", partNo, minPermitted: 0, maxPermitted: 8, autoCorrect);
        midiChannelNo = LogicTools.ValidateRange("MIDI Channel No.", midiChannelNo, minPermitted: 1, maxPermitted: 16, autoCorrect);
        midiChannel[partNo] = midiChannelNo - 1;
    }

    public int GetUIMidiChannel(int partNo)
    {
        return midiChannel[partNo] + 1;
    }

    public void SetMidiChannels1to8()
    {
        for (int partNo = 0; partNo < 9; partNo++)
        {
            midiChannel[partNo] = alternativeMidiChannel[partNo];
        }
    }

    public void SetMidiChannels2to9()
    {
        for (int partNo = 0; partNo < 9; partNo++)
        {
            midiChannel[partNo] = defaultMidiChannel[partNo];
        }
    }

    public bool MidiChannelsAreSet1to8()
    {
        for (int partNo = 0; partNo < 9; partNo++)
        {
            if (midiChannel[partNo] != alternativeMidiChannel[partNo]) return false;
        }
        return true;
    }

    public bool MidiChannelsAreSet2to9()
    {
        for (int partNo = 0; partNo < 9; partNo++)
        {
            if (midiChannel[partNo] != defaultMidiChannel[partNo]) return false;
        }
        return true;
    }

    public void SetPartialReserve(int partNo, int partials, bool autoCorrect = false)
    {
        partNo = LogicTools.ValidateRange("Part No.", partNo, minPermitted: 0, maxPermitted: 8, autoCorrect);
        partials = LogicTools.ValidateRange("Partial Reserve", partials, minPermitted: 0, maxPermitted: 32, autoCorrect);
        partialReserve[partNo] = partials;
    }

    public int GetPartialReserve(int partNo)
    {
        LogicTools.ValidateRange("Part No.", partNo, minPermitted: 0, maxPermitted: 8, autoCorrect: false);
        return partialReserve[partNo];
    }

    public byte[] GetPartialReserveSysExValues()
    {
        byte[] sysExData = new byte[9];
        for (int part = 0; part < 9; part++)
        {
            sysExData[part] = (byte)partialReserve[part];
        }
        return sysExData;
    }

    public void SetMessage(int messageNo, string message)
    {
        LogicTools.ValidateRange("Message No.", messageNo, minPermitted: 0, maxPermitted: 1, autoCorrect: false);
        textMessage[messageNo] = ParseTools.RemoveTrailingSpaces(ParseTools.MakeNCharsLong(message, 20));
    }

    public string GetMessage(int messageNo)
    {
        LogicTools.ValidateRange("Message No.", messageNo, minPermitted: 0, maxPermitted: 1, autoCorrect: false);
        return textMessage[messageNo];
    }
}