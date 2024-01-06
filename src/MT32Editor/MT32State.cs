namespace MT32Edit;

/// <summary>
/// Data structure representing user-accessible memory areas of MT-32, as per published MIDI implementation.
/// </summary>
public class MT32State
{
    // MT32Edit: MT32State class
    // S.Fryers Mar 2023
    // Data structure representing user-accessible
    // memory areas of MT-32, as per published MIDI implementation.
    private SystemLevel system = new SystemLevel();

    private Patch[] patchArray = new Patch[128];
    private Rhythm[] rhythmBank = new Rhythm[85];
    private TimbreStructure[] memoryTimbre = new TimbreStructure[64];
    private readonly TimbreNames timbreName = new TimbreNames();
    private readonly string[] mt32Message = new string[10];
    private DateTime timeOfLastFullUpdate = DateTime.Now;
    public bool patchEditorActive = false;
    public bool rhythmEditorActive = false;
    public bool returnFocusToPatchEditor = false;
    public bool returnFocusToRhythmEditor = false;
    public bool returnFocusToMemoryBankList = false;
    private bool timbreEditable = true;
    private int selectedPatch = 0;
    private int selectedMemoryTimbre = 0;
    private int selectedKey = 24;
    private readonly bool changesMade = false;
    private readonly bool sendSysEx = false;
    private readonly int channelNo = 1;

    public MT32State()
    {
        ResetAll();
        changesMade = false;
    }

    public void ResetAll()
    {
        InitialisePatchArray();
        InitialiseMemoryTimbreArray();
        InitialiseRhythmBank();
        system.SetMessage(0, "");
        system.SetMessage(1, "");
    }

    private void InitialisePatchArray()
    {
        for (int patchNo = 0; patchNo < 128; patchNo++)
        {
            patchArray[patchNo] = new Patch(patchNo);
        }
    }

    public void InitialiseMemoryTimbreArray()
    {
        for (int timbreNo = 0; timbreNo < 64; timbreNo++)
        {
            memoryTimbre[timbreNo] = new TimbreStructure(false);
        }
    }

    public void InitialiseRhythmBank()
    {
        int keyOffset = 24;
        for (int keyNo = 24; keyNo < 109; keyNo++)
        {
            int bankNo = keyNo - keyOffset;
            rhythmBank[bankNo] = new Rhythm(keyNo);
        }
    }

    public DateTime GetUpdateTime()
    {
        return timeOfLastFullUpdate;
    }

    public void SetUpdateTime()
    {
        timeOfLastFullUpdate = DateTime.Now;
        for (int patchNo = 0; patchNo < 128; patchNo++)
        {
            patchArray[patchNo].SetUpdateTime();
        }

        for (int timbreNo = 0; timbreNo < 64; timbreNo++)
        {
            memoryTimbre[timbreNo].SetUpdateTime();
        }

        for (int bankNo = 0; bankNo < 84; bankNo++)
        {
            rhythmBank[bankNo].SetUpdateTime();
        }
    }

    private void ValidateTimbreNo(int timbreNo)
    {
        LogicTools.ValidateRange("Timbre No.", timbreNo, 0, 63, autoCorrect: false);
    }

    private void ValidatePatchNo(int patchNo)
    {
        LogicTools.ValidateRange("Patch No.", patchNo, 0, 127, autoCorrect: false);
    }

    private void ValidateKeyNo(int keyNo)
    {
        LogicTools.ValidateRange("Key No.", keyNo, 24, 108, autoCorrect: false);
    }

    private void ValidateBankNo(int bankNo)
    {
        LogicTools.ValidateRange("Bank No.", bankNo, 0, 85, autoCorrect: false);
    }

    public TimbreStructure[] GetMemoryTimbreArray()
    {
        return memoryTimbre;
    }

    public void SetMemoryTimbreArray(TimbreStructure[] memoryTimbreArrayInput)
    {
        memoryTimbre = memoryTimbreArrayInput;
    }

    public TimbreStructure GetMemoryTimbre(int timbreNo)
    {
        ValidateTimbreNo(timbreNo);
        return memoryTimbre[timbreNo];
    }

    public void SetMemoryTimbre(TimbreStructure memoryTimbreInput, int timbreNo)
    {
        ValidateTimbreNo(timbreNo);
        memoryTimbre[timbreNo] = memoryTimbreInput;
    }

    public void SetPatchArray(Patch[] patchArrayInput)
    {
        patchArray = patchArrayInput;
    }

    public Patch[] GetPatchArray()
    {
        return patchArray;
    }

    public Patch GetPatch(int patchNo)
    {
        ValidatePatchNo(patchNo);
        return patchArray[patchNo];
    }

    public void SetPatch(Patch patchInput, int patchNo)
    {
        ValidatePatchNo(patchNo);
        patchArray[patchNo] = patchInput;
    }

    public Rhythm[] GetRhythmBankArray()
    {
        return rhythmBank;
    }

    public void SetRhythmBankArray(Rhythm[] rhythmBankArrayInput)
    {
        rhythmBank = rhythmBankArrayInput;
    }

    public Rhythm GetRhythm(int bankNo)
    {
        ValidateBankNo(bankNo);
        return rhythmBank[bankNo];
    }

    public void SetRhythm(Rhythm rhythmBankInput, int bankNo)
    {
        ValidateBankNo(bankNo);
        rhythmBank[bankNo] = rhythmBankInput;
    }

    public TimbreNames GetTimbreNames()
    {
        return timbreName;
    }

    public SystemLevel GetSystem()
    {
        return system;
    }

    public void SetSystem(SystemLevel systemInput)
    {
        system = systemInput;
    }

    public string[] GetMessages()
    {
        return mt32Message;
    }

    public string GetMessage(int messageNo)
    {
        return mt32Message[messageNo];
    }

    public void SetMessage(string messageInput, int messageNo)
    {
        messageInput = ParseTools.TrimToLength(messageInput, 20);
        mt32Message[messageNo] = messageInput;
    }

    public bool TimbreIsEditable()
    {
        return timbreEditable;
    }

    public void SetTimbreIsEditable(bool selectionState)
    {
        timbreEditable = selectionState;
    }

    public void SetSelectedPatchNo(int patchNo)
    {
        ValidatePatchNo(patchNo);
        selectedPatch = patchNo;
    }

    public int GetSelectedPatchNo()
    {
        return selectedPatch;
    }

    public void SetSelectedKey(int keyNo)
    {
        ValidateKeyNo(keyNo);
        selectedKey = keyNo;
    }

    public int GetSelectedKey()
    {
        return selectedKey;
    }

    public int GetSelectedBank()
    {
        return selectedKey - 24;
    }

    public void SetSelectedMemoryTimbre(int timbreNo)
    {
        ValidateTimbreNo(timbreNo);
        selectedMemoryTimbre = timbreNo;
    }

    public int GetSelectedMemoryTimbre()
    {
        return selectedMemoryTimbre;
    }
}