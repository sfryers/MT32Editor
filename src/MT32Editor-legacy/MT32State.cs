namespace MT32Edit_legacy;

/// <summary>
/// Data structure representing user-accessible memory areas of MT-32, as per published MIDI implementation.
/// </summary>
public class MT32State
{
    // MT32Edit: MT32State class
    // S.Fryers Apr 2024

    public const int NO_OF_MEMORY_TIMBRES = 64;
    public const int NO_OF_PATCHES = 128;
    public const int NO_OF_RHYTHM_BANKS = 85;

    private SystemLevel system = new SystemLevel();
    private TimbreStructure[] memoryTimbre = new TimbreStructure[NO_OF_MEMORY_TIMBRES];
    private Patch[] patchArray = new Patch[NO_OF_PATCHES];
    private Rhythm[] rhythmBank = new Rhythm[NO_OF_RHYTHM_BANKS];
    private readonly TimbreNames timbreName = new TimbreNames();
    private DateTime timeOfLastFullUpdate = DateTime.Now; 

    private bool timbreEditable = true;
    private int selectedPatch = 0;
    private int selectedMemoryTimbre = 0;
    private int selectedKey = RhythmConstants.KEY_OFFSET;

    public bool patchEditorActive { get; set; } = false;
    public bool rhythmEditorActive { get; set; } = false;
    public bool returnFocusToPatchEditor { get; set; } = false;
    public bool returnFocusToRhythmEditor { get; set; } = false;
    public bool returnFocusToMemoryBankList { get; set; } = false;
    public bool enableTimbreSaveButton { get; set; } = false;
    public bool changesMade { get; set; } = false;
    public bool requestPatchRefresh { get; set; } = false;
    public bool requestRhythmRefresh { get; set; } = false;

    public MT32State()
    {
        ResetAll();
    }

    /// <summary>
    /// Resets the entire internal MT-32 memory state.
    /// </summary>
    public void ResetAll()
    {
        InitialisePatchArray();
        InitialiseMemoryTimbreArray();
        InitialiseRhythmBank();
        system.SetMessage(0, "");
        system.SetMessage(1, "");
        changesMade = false;
    }

    private void InitialisePatchArray()
    {
        for (int patchNo = 0; patchNo < NO_OF_PATCHES; patchNo++)
        {
            patchArray[patchNo] = new Patch(patchNo);
        }
    }

    private void InitialiseMemoryTimbreArray()
    {
        for (int timbreNo = 0; timbreNo < NO_OF_MEMORY_TIMBRES; timbreNo++)
        {
            memoryTimbre[timbreNo] = new TimbreStructure(false);
        }
    }

    private void InitialiseRhythmBank()
    {
        for (int keyNo = RhythmConstants.KEY_OFFSET; keyNo < RhythmConstants.KEY_OFFSET + NO_OF_RHYTHM_BANKS; keyNo++)
        {
            int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
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
        for (int patchNo = 0; patchNo < NO_OF_PATCHES; patchNo++)
        {
            patchArray[patchNo].SetUpdateTime();
        }

        for (int timbreNo = 0; timbreNo < NO_OF_MEMORY_TIMBRES; timbreNo++)
        {
            memoryTimbre[timbreNo].SetUpdateTime();
        }

        for (int bankNo = 0; bankNo < NO_OF_RHYTHM_BANKS; bankNo++)
        {
            rhythmBank[bankNo].SetUpdateTime();
        }
    }

    private void ValidateTimbreNo(int timbreNo)
    {
        LogicTools.ValidateRange("Timbre No.", timbreNo, 0, NO_OF_MEMORY_TIMBRES - 1, autoCorrect: false);
    }

    private void ValidatePatchNo(int patchNo)
    {
        LogicTools.ValidateRange("Patch No.", patchNo, 0, NO_OF_PATCHES - 1, autoCorrect: false);
    }

    private void ValidateKeyNo(int keyNo)
    {
        LogicTools.ValidateRange("Key No.", keyNo, 24, NO_OF_RHYTHM_BANKS + RhythmConstants.KEY_OFFSET - 1, autoCorrect: false);
    }

    private void ValidateBankNo(int bankNo)
    {
        LogicTools.ValidateRange("Bank No.", bankNo, 0, NO_OF_RHYTHM_BANKS - 1, autoCorrect: false);
    }

    /// <summary>
    /// Gets all current memory timbres
    /// </summary>
    /// <returns>An array of TimbreStructures containing all current memory timbres</returns>
    public TimbreStructure[] GetMemoryTimbreArray()
    {
        return memoryTimbre;
    }

    /// <summary>
    /// Sets all current memory timbres
    /// </summary>
    public void SetMemoryTimbreArray(TimbreStructure[] memoryTimbreArrayInput)
    {
        memoryTimbre = memoryTimbreArrayInput;
    }

    /// <summary>
    /// Gets a single memory timbre from slot [timbreNo].
    /// </summary>
    /// <returns>A TimbreStructure containing the requested memory timbre</returns>
    public TimbreStructure GetMemoryTimbre(int timbreNo)
    {
        ValidateTimbreNo(timbreNo);
        return memoryTimbre[timbreNo];
    }

    public string GetMemoryTimbreName(int timbreNo)
    {
        ValidateTimbreNo(timbreNo);
        return ParseTools.RemoveTrailingSpaces(GetTimbreNames().Get(timbreNo, 2));
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

    public Rhythm GetRhythmBank(int bankNo)
    {
        ValidateBankNo(bankNo);
        return rhythmBank[bankNo];
    }

    public Rhythm GetRhythmKey(int keyNo)
    {
        int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
        ValidateKeyNo(keyNo);
        return rhythmBank[bankNo];
    }

    public void SetRhythmBank(Rhythm rhythmBankInput, int bankNo)
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
        return selectedKey - RhythmConstants.KEY_OFFSET;
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