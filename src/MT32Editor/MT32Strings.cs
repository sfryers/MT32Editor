namespace MT32Edit;

internal static class MT32Strings
{
    //
    // MT32Edit: MT32Strings class (static)
    // S.Fryers Apr 2023
    // Read-only data class containing MT-32 PCM sample names, parameter names and other user-readable strings.
    //
    public static readonly string[] bank1SampleNames = 
    {
        "Ac. Bass Drum","Ac. Snare Drum","El. Snare Drum","Electric Tom","Closed Hihat","Open Hihat","Crash Cymbal","Crash Cymbal (loop)","Ride cymbal","Rim Shot","Hand Clap","Muted Conga","Conga","Bongo","Cowbell",
        "Tambourine", "Agogo Bell","Claves","Timbale","Cabasa","Keypress","Perc Organ","Trombone","Trumpet","Breath Noise (loop)","Clarinet","Flute","Pan Pipes","Shakuhachi","Alto Sax",
        "Baritone Sax","Marimba","Glockenspiel","Xylophone","Tubular Bells","Fingered Bass","Slap Bass","Picked Bass (loop)","Acoustic Bass","Nylon Guitar","Steel Guitar","Pizzicato",
        "Harp","Harpsichord (loop)","Bow string","Violin","Timpani","Orchestra Hit","Flute","Organ (loop)","Bowed Glass (loop)","Telephone","Bowed Glass","Reverse Cymbal","Ac. Bass Drum #",
        "Ac. Snare Drum #","El. Snare Drum #","Ac. Tom #","Closed Hihat #","Open Hihat (loop) #","Crash Cymbal #","Crash Cymbal (loop) #","Ride cymbal #","Rim shot #","Hand clap #","Mute Conga #",
        "Conga #","Bongo #","Cowbell #","Tambourine #","Agogo #","Claves #","Timbale #","Cabasa #","Bass Drum (loop)","Snare (loop)","Acoustic Tom (loop)","Electric Tom (loop)","Hihat (loop)",
        "Crash Cymbal (loop)","Ride cymbal (loop)","Ride cymbal 2 (loop)","Rim (loop)","Hand clap (loop)","Bongo (loop)","Conga (loop)","Muted conga (loop)","Cowbell (loop)","Tambourine (loop)",
        "Agogo (loop)","Woodblock (loop)","Timbales (loop)","Maracas (loop)","Sticks (loop)","Perc Organ (loop)","Trombone (loop)","Trumpet (loop)","Clarinet (loop)","Piccolo (loop)","Pan Pipe (loop)",
        "Breath Noise (loop)","Alto Sax (loop)","Baritone Sax (loop)","Xylophone (loop)","Glockenspiel (loop)","Marimba (loop)","Tubular Bells (loop)","Fingered Bass (loop)","Slap Bass (loop)",
        "Acoustic Bass (loop)","Nylon Guitar (loop)","Steel Guitar (loop)","Pizzicato (loop)","Harp (loop)","Bowed string (loop)","String Ensemble (loop)","[null]","Orchestra Hit (loop)","Flute (loop)",
        "Perc. loop 1","Perc. loop 2","Orch&Perc loop","Wind&Perc loop","Guitar & Bass loop","Orchestra loop","Perc. loop 3","Bass & Perc. loop","Bass & Snare loop"
    };

    public static readonly string[] bank2SampleNames = 
    {
        "Laugh #","Applause #","Windchime #","Crash #","Train #","Wind #","Bird #","Stream #","Door Creak #","Scream #","Punch #","Footsteps #","Door Slam #","Car Start #","Aircraft #","Gun Shot #",
        "Horse #","Thunder #","Bubble #","Heartbeat #","Engine #","Tyre Screech #","Siren #","Helicopter #","Dog Bark #","Car Pass #","Male Voice #","Machine Gun #","Starship #","Laugh (Loop) #",
        "Applause (Loop) #","Windchime (Loop) #","Crash (Loop) #","Train (Loop) #","Wind (Loop) #","Bird (Loop) #","Stream (Loop) #","Door Creak (Loop) #","Scream (Loop) #","Punch (Loop) #",
        "Footsteps (Loop) #","Door Slam (Loop) #","Car Start (Loop) #","Aircraft (Loop) #","Gun Shot (Loop) #","Horse (Loop) #","Thunder (Loop) #","Bubble (Loop) #","Heartbeat (Loop) #",
        "Engine (Loop) #", "Tyre Screech (Loop) #","Siren (Loop) #","Helicopter (Loop) #","Dog Bark (Loop) #","Car Pass (Loop) #","Male Voice (Loop) #","Machine Gun (Loop) #","Starship (Loop) #",
        "Jam-1 (Loop)","Jam-2 (Loop)","Jam-3 (Loop)","Jam-4 (Loop)","Jam-5 (Loop)","Jam-6 (Loop)","Jam-7 (Loop)","Jam-8 (Loop)","Jam-9 (Loop)","Jam-10 (Loop)","Jam-11 (Loop)","Jam-12 (Loop)",
        "Jam-13 (Loop)","Jam-14 (Loop)","Jam-15 (Loop)","Jam-16 (Loop)","Jam-17 (Loop)","Jam-18 (Loop)","Jam-19 (Loop)","Jam-20 (Loop)","Jam-21 (Loop)","Jam-22 (Loop)","Jam-23 (Loop)","Jam-24 (Loop)",
        "Jam-25 (Loop)","Jam-26 (Loop)","Jam-27 (Loop)","Jam-28 (Loop)","Jam-29 (Loop)","Jam-30 (Loop)","Jam-31 (Loop)","Jam-32 (Loop)","Jam-33 (Loop)","Jam-34 (Loop)","Jam-35 (Loop)","Jam-36 (Loop)",
        "Jam-37 (Loop)","Jam-38 (Loop)","Jam-39 (Loop)","Jam-40 (Loop)","Shot-1","Shot-2","Shot-3","Shot-4","Shot-5","Shot-6","Shot-7","Shot-8","Shot-9","Shot-10","Shot-11","Shot-12","Shot-13","Shot-14",
        "Shot-15","Shot-16","Shot-17","Shot-18","Shot-19","Shot-20","Shot-21","Shot-22","Shot-23","Shot-24","Shot-25","Shot-26","Alto Sax","Shakuhachi","Marimba","Dog Bark"
    };  //This sample bank is only available on CM-32L or MUNT with a CM-32L compatible ROM loaded

    public static readonly string[] partialParameterNames = 
    {
        "Pitch", "Fine Pitch", "Pitch KF", "Pitch Bend", "Waveform", "PCM Sample No.", "Pulse Width", "PW Velo. Sens.", "Pitch Env Depth", "P.Env Velo Sens", "P.Env Time KF",
        "P.Env Time 1", "P.Env Time 2", "P.Env Time 3", "P.Env Time 4", "P.Env Level 0", "P.Env Level 1", "P.Env Level 2", "P.Env Sust Lvl", "P.Env Rel Lvl",
        "Pitch LFO Rate", "Pitch LFO Depth", "P.LFO Mod Sens",
        "TVF Cutoff", "TVF Resonance", "TVF Keyfollow", "TVF Bias Pt", "TVF Bias Lvl", "TVF Env Depth", "TVF Velo Sens", "TVF Depth KF", "TVF Time KF",
        "TVF Env Time 1", "TVF Env Time 2", "TVF Env Time 3", "TVF Env Time 4", "TVF Env Time 5", "TVF Env Lvl 1", "TVF Env Lvl 2", "TVF Env Lvl 3", "TVF Sust Lvl",
        "TVA Level", "TVA Velo Sens", "TVA Bias Pt.1", "TVA Bias Lvl 1", "TVA Bias Pt.2", "TVA Bias Lvl 2", "TVA Time KF", "TVA Velo KF", "TVA Env Time 1", "TVA Env Time 2",
        "TVA Env Time 2", "TVA Env Time 3", "TVA Env Time 4", "TVA Env Time 5", "TVA Env Lvl 1", "TVA Env Lvl 2", "TVA Env Lvl 3", "TVA Sust Lvl"
    };

    public static readonly string[] patchParameterNames =
    {
        "Group", "Timbre ", "Key Shift", "Fine Tune", "Bend Range", "Assign Mode", "Reverb"
    };

    public static readonly string[] noteName = { "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B" };

    public static readonly string[] keyfollowRatio = { "-1", "-1/2", "-1/4", "0", "1/8", "1/4", "3/8", "1/2", "5/8", "3/4", "7/8", "1", "5/4", "3/2", "2", "s1", "s2" };

    public static readonly string[] reverbTypeName = { "Room", "Hall", "Plate", "Delay" };

    public static readonly string[] waveform = { "Square", "Saw" };

    public static readonly string[] onOff = { "Off", "On" };
    
    public static readonly string[] partialConfig = { "(SS)     ", "(S(SR))", "(PS)     ", "(P(SR))", "(S(PR))", "(PP)     ", "(P(PR))", "(S)(S)   ", "(P)(P)  ", "(SS)R ", "(PS)R ", "(SP)R ", "(PP)R " };
    public static readonly string[] partialConfig12Desc =   { 
                                                            "(Partial 1 [Synth] + Partial 2 [Synth]) → Mono Out",
                                                            "(Partial 1 [Synth] + Partial 2 [Synth] → Ring Mod.) + Partial 1 [Synth] → Mono Out",
                                                            "(Partial 1 [PCM] + Partial 2 [Synth]) → Mono Out",
                                                            "(Partial 1 [PCM] + Partial 2 [Synth] → Ring Mod.) + Partial 1 [PCM] → Mono Out",
                                                            "(Partial 1 [Synth] + Partial 2 [PCM] → Ring Mod.) + Partial 1 [Synth] → Mono Out",
                                                            "(Partial 1 [PCM] + Partial 2 [PCM]) → Mono Out",
                                                            "(Partial 1 [PCM] + Partial 2 [PCM] → Ring Mod.) + Partial 1 [PCM] → Mono Out",
                                                            "(Partial 1 [Synth] → Left Channel) (Partial 2 [Synth] → Right Channel) → Stereo Out",
                                                            "(Partial 1 [PCM] → Left Channel) (Partial 2 [PCM] → Right Channel) → Stereo Out", 
                                                            "(Partial 1 [Synth] + Partial 2 [Synth]) → Ring Mod. → Mono Out", 
                                                            "(Partial 1 [PCM] + Partial 2 [Synth]) → Ring Mod. → Mono Out", 
                                                            "(Partial 1 [Synth] + Partial 2 [PCM]) → Ring Mod. → Mono Out", 
                                                            "(Partial 1 [PCM] + Partial 2 [PCM]) → Ring Mod. → Mono Out" 
                                                            };
    public static readonly string[] partialConfig34Desc = {
                                                            "(Partial 3 [Synth] + Partial 4 [Synth]) → Mono Out",
                                                            "(Partial 3 [Synth] + Partial 4 [Synth] → Ring Mod.) + Partial 3 [Synth] → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [Synth]) → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [Synth] → Ring Mod.) + Partial 3 [PCM] → Mono Out",
                                                            "(Partial 3 [Synth] + Partial 4 [PCM] → Ring Mod.) + Partial 3 [Synth] → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [PCM]) → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [PCM] → Ring Mod.) + Partial 3 [PCM] → Mono Out",
                                                            "(Partial 3 [Synth] → Left Channel) (Partial 4 [Synth] → Right Channel) → Stereo Out",
                                                            "(Partial 3 [PCM] → Left Channel) (Partial 4 [PCM] → Right Channel) → Stereo Out",
                                                            "(Partial 3 [Synth] + Partial 4 [Synth]) → Ring Mod. → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [Synth]) → Ring Mod. → Mono Out",
                                                            "(Partial 3 [Synth] + Partial 4 [PCM]) → Ring Mod. → Mono Out",
                                                            "(Partial 3 [PCM] + Partial 4 [PCM]) → Ring Mod. → Mono Out"
                                                            };

    public const string EMPTY = "[empty]";

    public static string PitchNote(int pitchValue)
    {
        //returns note & octave name from integer value where 0 = C-1 and 120 = C9
        LogicTools.ValidateRange("Pitch Value", pitchValue, 0, 127, autoCorrect: false);
        int octave = (pitchValue - 12) / 12;
        int noteValue = pitchValue % 12;
        return noteName[noteValue] + octave.ToString();
    }

    public static string BiasPoint(int biasPointValue)
    {
        //returns bias point note name where 0-63 = <A1 to <C4 and 64-128 = >A1 to >C4
        LogicTools.ValidateRange("Bias Point Value", biasPointValue, 0, 127, autoCorrect: false);
        string biasPt = ">";
        if (biasPointValue < 64) biasPt = "<" + PitchNote(biasPointValue + 21);
        else biasPt += PitchNote(biasPointValue - 43);
        return biasPt;
    }

    public static string Keyfollow(int keyfollowValue)
    {
        LogicTools.ValidateRange("Keyfollow Value", keyfollowValue, 0, 16, autoCorrect: false);
        return keyfollowRatio[keyfollowValue];
    }

    public static string PartialStatus(bool[] partialMuteStatus)  
    {
        //create 4-character string representing active partials with numbers and muted partials with an underscore character
        string partialStatusList = "";
        for (int partialNo = 0; partialNo < 4; partialNo++) 
        {
            if (partialMuteStatus[partialNo]) partialStatusList += "_";
            else partialStatusList += (partialNo + 1).ToString();
        }
        return partialStatusList;
    }

    public static string OnOffStatus(bool statusIsOn)
    {
        if (statusIsOn) return onOff[1];
        else return onOff[0];
    }

    public static string WaveformType(int waveformValue)
    {
        LogicTools.ValidateRange("Waveform Type", waveformValue, 0, 3, autoCorrect: false);
        if (waveformValue > 1) waveformValue -= 2;
        return waveform[waveformValue];
    }

    public static string PartialParameterValueText(int parameterNo, int parameterValue)
    {
        switch (parameterNo) //produce appropriate string for non-numeric UI values
        {
            case 0x00:
                return PitchNote(parameterValue);
            case 0x02:
            case 0x19:
                return Keyfollow(parameterValue);
            case 0x03:
                return OnOffStatus(LogicTools.IntToBool(parameterValue));
            case 0x04:
                return WaveformType(parameterValue);
            case 0x1A:
            case 0x2B:
            case 0x2D:
                return BiasPoint(parameterValue);
            default:
                return parameterValue.ToString();                           //if no text is provided then make numeric value into string
        }
    }

    public static string PatchParameterValueText(int parameterNo, int parameterValue)
    {
        switch (parameterNo) //produce appropriate string for non-numeric UI values
        {
            case 0x05:
                return (parameterValue + 1).ToString();                     //assign mode
            case 0x06:
                return OnOffStatus(LogicTools.IntToBool(parameterValue));   //reverb status
            default:
                return parameterValue.ToString();                           //if no text is provided then make numeric value into string
        }
    }
}
