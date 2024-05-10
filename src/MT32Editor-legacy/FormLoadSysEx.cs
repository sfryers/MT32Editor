using System;
using System.Windows.Forms;
namespace MT32Edit_legacy;

/// <summary>
/// Simple form to display loading bar during timbre data upload. 
/// Includes 50ms delay timer to avoid buffer overflows on hardware MT-32.
/// </summary>
public partial class FormLoadSysEx : Form
{
    // MT32Edit: FormLoadSysEx
    // S.Fryers Apr 2024

    private readonly MT32State memoryState;

    private int timbreNo = 0;
    private int patchNo = 0;
    private int keyNo = 24;
    private const int PATCHES_PER_BLOCK = 32;
    private const int RHYTHM_BANKS_PER_BLOCK = 42;

    // step 0 = load system area,
    // step 1 = load patches,
    // step 2 = load timbres,
    // step 3 = load rhythm bank area.
    private int stepNo = 0;

    private readonly bool clearMemory;

    public FormLoadSysEx(MT32State inputMemoryState, bool requestClearMemory)
    {
        InitializeComponent();
        MT32SysEx.blockSysExMessages = true;
        clearMemory = requestClearMemory;
        if (clearMemory)
        {
            labelLoadProgress.Text = "Clearing Memory Timbres";
        }
        memoryState = inputMemoryState;
        SetTextLabels();
        SetTheme();
        timer.Interval = MT32SysEx.hardwareMT32Connected ? MT32SysEx.MT32_DELAY : 75;
        progressBar.Maximum = 66 + (88 / RHYTHM_BANKS_PER_BLOCK) + (128 / PATCHES_PER_BLOCK);
        MT32SysEx.blockSysExMessages = false;
        timer.Start();
    }

    private void SetTextLabels()
    {
        labelMT32Text1.Text = ParseTools.RemoveLeadingSpaces(memoryState.GetSystem().GetMessage(0));
        labelMT32Text2.Text = ParseTools.RemoveLeadingSpaces(memoryState.GetSystem().GetMessage(1));
    }

    private void SetTheme()
    {
        Label[] labels = { labelLoadProgress, labelMT32Text1, labelMT32Text2 };
        BackColor = UITools.SetThemeColours(titleLabel: null, labels, warningLabels: null, checkBoxes: null, groupBoxes: null, listView: null, radioButtons: null, alternate: true);
    }


    private void timer_Tick(object sender, EventArgs e)
    {
        switch (stepNo)
        {
            case 0:
                SendSystemArea();
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

        void Finish()
        {
            labelLoadProgress.Text = "SysEx load completed";
            timer.Stop();
            Close();
        }
    }

    private void SendSystemArea()
    {
        if (!clearMemory)
        {
            labelLoadProgress.Text = "Loading system memory area";
            MT32SysEx.SendSystemParameters(memoryState.GetSystem());
        }
        progressBar.Value++;
        stepNo++;
    }

    private void SendNextPatchBlock()
    {
        labelLoadProgress.Text = "Loading patch data";
        MT32SysEx.SendPatchBlock(memoryState.GetPatchArray(), patchNo, patchNo + PATCHES_PER_BLOCK - 1);
        UpdateProgressBarPatchStatus();
        patchNo += PATCHES_PER_BLOCK;
        progressBar.Value++;
    }

    private void SendNextRhythmBankBlock()
    {
        labelLoadProgress.Text = "Loading rhythm data";
        MT32SysEx.SendRhythmKeyBlock(memoryState.GetRhythmBankArray(), keyNo, keyNo + RHYTHM_BANKS_PER_BLOCK - 1);
        keyNo += RHYTHM_BANKS_PER_BLOCK;
        progressBar.Value++;
    }

    private void SendNextMemoryTimbre()
    {
        MT32SysEx.SendMemoryTimbre(timbreNo, memoryState.GetMemoryTimbre(timbreNo));
        UpdateProgressBarTimbreStatus();
        timbreNo++;
        progressBar.Value++;
    }

    private void UpdateProgressBarTimbreStatus()
    {
        if (clearMemory)
        {
            labelLoadProgress.Text = $"Clearing timbre memory {timbreNo + 1} of 64";
        }
        else
        {
            labelLoadProgress.Text = $"Loading {memoryState.GetMemoryTimbre(timbreNo).GetTimbreName()} ({timbreNo} of 64)";
        }
    }

    private void UpdateProgressBarPatchStatus()
    {
        labelLoadProgress.Text = $"Loading patches {patchNo + 1}-{patchNo + PATCHES_PER_BLOCK}";
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}