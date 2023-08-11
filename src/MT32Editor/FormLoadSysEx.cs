namespace MT32Edit;

/// <summary>
/// Simple form containing loading bar to display during timbre data upload Includes 50ms delay timer to avoid buffer overflows on hardware MT-32
/// </summary>
public partial class FormLoadSysEx : Form
{
    // MT32Edit: FormLoadSysEx
    // S.Fryers Mar 2023
    // Simple form containing loading bar to display
    // during timbre data upload Includes 50ms delay timer to avoid buffer overflows on hardware MT-32

    private readonly MT32State memoryState;

    private int timbreNo = 0;
    private int patchNo = 0;
    private int keyNo = 24;
    private const int PATCHES_PER_BLOCK = 32;
    private const int RHYTHM_BANKS_PER_BLOCK = 42;
    private const int MT32_DELAY = 50;

    // Step 0 = load system area,
    // step 1 = load patches,
    // step 2 = load timbres,
    // step 3 = load rhythm bank area.
    private int stepNo = 0;

    private readonly bool clearMemory;

    public FormLoadSysEx(MT32State inputMemoryState, bool clearMemoryState)
    {
        InitializeComponent();
        MT32SysEx.blockSysExMessages = true;
        clearMemory = clearMemoryState;
        if (clearMemory)
        {
            Text = "Clearing Memory Timbres";
        }

        memoryState = inputMemoryState;
        if (Midi.hardwareMT32)
        {
            timer.Interval = MT32_DELAY;
        }
        else
        {
            timer.Interval = 1;
        }

        progressBar.Maximum = 66 + (88 / RHYTHM_BANKS_PER_BLOCK) + (128 / PATCHES_PER_BLOCK);
        MT32SysEx.blockSysExMessages = false;
        timer.Start();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        switch (stepNo)
        {
            case 0:
                if (!clearMemory)
                {
                    SendSystemArea();
                }

                break;

            case 1:
                if (!clearMemory && patchNo < 128)
                {
                    SendNextPatchBlock();
                }
                else
                {
                    stepNo++;
                }

                break;

            case 2:
                if (!clearMemory && keyNo < 104)
                {
                    SendNextRhythmBankBlock();
                }
                else
                {
                    stepNo++;
                }

                break;

            case 3:
                stepNo++;
                break;

            case 4:
                stepNo++;
                break;

            default:
                if (timbreNo < 64)
                {
                    SendNextMemoryTimbre();
                }
                else
                {
                    Finish();
                }

                break;
        }

        void SendSystemArea()
        {
            labelLoadProgress.Text = "Loading system memory area";
            MT32SysEx.SendSystemParameters(memoryState.GetSystem());
            progressBar.Value++;
            stepNo++;
        }

        void SendNextPatchBlock()
        {
            labelLoadProgress.Text = "Loading patch data";
            MT32SysEx.SendPatchBlock(memoryState.GetPatchArray(), patchNo, patchNo + PATCHES_PER_BLOCK - 1);
            UpdateProgressBarPatchStatus(patchNo);
            patchNo += PATCHES_PER_BLOCK;
            progressBar.Value++;
        }

        void SendNextRhythmBankBlock()
        {
            labelLoadProgress.Text = "Loading rhythm data";
            MT32SysEx.SendRhythmKeyBlock(memoryState.GetRhythmBankArray(), keyNo, keyNo + RHYTHM_BANKS_PER_BLOCK - 1);
            keyNo += RHYTHM_BANKS_PER_BLOCK;
            progressBar.Value++;
        }

        void SendNextMemoryTimbre()
        {
            MT32SysEx.SendMemoryTimbre(timbreNo, memoryState.GetMemoryTimbre(timbreNo));
            UpdateProgressBarTimbreStatus(timbreNo);
            timbreNo++;
            progressBar.Value++;
        }

        void Finish()
        {
            labelLoadProgress.Text = "SysEx load completed";
            timer.Stop();
            Close();
        }
    }

    private void UpdateProgressBarTimbreStatus(int timbreNo)
    {
        if (clearMemory)
        {
            labelLoadProgress.Text = "Clearing timbre memory " + (timbreNo + 1).ToString() + " of 64";
        }
        else
        {
            labelLoadProgress.Text = "Loading " + memoryState.GetMemoryTimbre(timbreNo).GetTimbreName() + " (" + timbreNo.ToString() + " of 64)";
        }
    }

    private void UpdateProgressBarPatchStatus(int patchNo)
    {
        labelLoadProgress.Text = "Loading patches " + (patchNo + 1).ToString() + "-" + (patchNo + PATCHES_PER_BLOCK).ToString();
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}