namespace MT32Edit_legacy;

/// <summary>
/// Read-only data class containing names of all preset MT-32 timbres.
/// </summary>
internal static class PresetTimbreNames
{
    // MT32Edit: PresetTimbreNames class (static)
    // S.Fryers Feb 2023

    private static readonly string[] presetGroupA =     {
                                                        "AcouPiano1","AcouPiano2","AcouPiano3","ElecPiano1","ElecPiano2","ElecPiano3","ElecPiano4","Honkytonk" ,
                                                        "Elec Org 1","Elec Org 2","Elec Org 3","Elec Org 4","Pipe Org 1","Pipe Org 2","Pipe Org 3","Accordion" ,
                                                        "Harpsi 1"  ,"Harpsi 2"  ,"Harpsi 3"  ,"Clavi 1"   ,"Clavi 2"   ,"Clavi 3"   ,"Celesta 1" ,"Celesta 2" ,
                                                        "Syn Brass1","Syn Brass2","Syn Brass3","Syn Brass4","Syn Bass 1","Syn Bass 2","Syn Bass 3","Syn Bass 4",
                                                        "Fantasy"   ,"Harmo Pan" ,"Chorale"   ,"Glasses"   ,"Soundtrack","Atmosphere","Warm Bell" ,"Funny Vox" ,
                                                        "Echo Bell" ,"Ice Rain"  ,"Oboe 2001" ,"Echo Pan"  ,"DoctorSolo","Schooldaze","Bellsinger","SquareWave",
                                                        "Str Sect 1","Str Sect 2","Str Sect 3","Pizzicato ","Violin 1"  ,"Violin 2"  ,"Cello 1"   ,"Cello 2"   ,
                                                        "Contrabass","Harp 1"    ,"Harp 2"    ,"Guitar 1"  ,"Guitar 2"  ,"Elec Gtr 1","Elec Gtr 2","Sitar"
                                                        }; //64 members

    private static readonly string[] presetGroupB =     {
                                                        "Acou Bass1","Acou Bass2","Elec Bass1","Elec Bass2","Slap Bass1","Slap Bass2","Fretless 1","Fretless 2",
                                                        "Flute 1"   ,"Flute 2"   ,"Piccolo 1" ,"Piccolo 2" ,"Recorder"  ,"Pan Pipes" ,"Sax 1"     ,"Sax 2"     ,
                                                        "Sax 3"     ,"Sax 4"     ,"Clarinet 1","Clarinet 2","Oboe"      ,"Engl Horn" ,"Bassoon"   ,"Harmonica" ,
                                                        "Trumpet 1" ,"Trumpet 2" ,"Trombone 1","Trombone 2","Fr Horn 1" ,"Fr Horn 2" ,"Tuba"      ,"Brs Sect 1",
                                                        "Brs Sect 2","Vibe 1"    ,"Vibe 2"    ,"Syn Mallet","Windbell"  ,"Glock"     ,"Tube Bell" ,"Xylophone" ,
                                                        "Marimba"   ,"Koto"      ,"Sho"       ,"Shakuhachi","Whistle 1" ,"Whistle 2" ,"Bottleblow","Breathpipe",
                                                        "Timpani"   ,"MelodicTom","Deep Snare","Elec Perc1","Elec Perc2","Taiko"     ,"Taiko Rim ","Cymbal"    ,
                                                        "Castanets" ,"Triangle"  ,"Orche Hit ","Telephone" ,"Bird Tweet","OneNoteJam","WaterBells","JungleTune"
                                                        }; //64 members

    private static readonly string[] rhythmGroup =      {
                                                        "Acou BD"   ,"Acou SD"   ,"Acou HiTom","AcouMidTom","AcouLowTom","Elec SD"   ,"Clsd HiHat","OpenHiHat1",
                                                        "Crash Cym" ,"Ride Cym"  ,"Rim Shot"  ,"Hand Clap" ,"Cowbell"   ,"Mt HiConga","High Conga","Low Conga" ,
                                                        "Hi Timbale","LowTimbale","High Bongo","Low Bongo" ,"High Agogo","Low Agogo" ,"Tambourine","Claves"    ,
                                                        "Maracas"   ,"SmbaWhis L","SmbaWhis S","Cabasa"    ,"Quijada"   ,"OpenHiHat2","Laughing"  ,"Screaming" ,
                                                        "Punch"     ,"Heartbeat" ,"Footsteps1","Footsteps2","Applause"  ,"Creaking"  ,"Door"      ,"Scratch"   ,
                                                        "Windchime" ,"Engine"    ,"Car-stop"  ,"Car-pass"  ,"Crash"     ,"Siren"     ,"Train"     ,"Jet"       ,
                                                        "Helicopter","Starship"  ,"Pistol"    ,"Machinegun","Lasergun"  ,"Explosion" ,"Dog"       ,"Horse"     ,
                                                        "Birds"     ,"Rain"      ,"Thunder"   ,"Wind"      ,"Waves"     ,"Stream"    ,"Bubble"    ,"[none]"
                                                        }; //63 members plus blank (on CM-32L; only the first 30 samples are available on MT-32)

    public static string GetPresetA(int timbreNo)
    {
        if (timbreNo < 0 || timbreNo > 63)
        {
            OutOfRangeException(timbreNo);
        }

        return presetGroupA[timbreNo];
    }

    public static string GetPresetB(int timbreNo)
    {
        if (timbreNo < 0 || timbreNo > 63)
        {
            OutOfRangeException(timbreNo);
        }

        return presetGroupB[timbreNo];
    }

    public static string GetRhythm(int timbreNo)
    {
        if (timbreNo < 0 || timbreNo > 63)
        {
            OutOfRangeException(timbreNo);
        }

        return rhythmGroup[timbreNo];
    }

    public static string[] GetAllPresetA()
    {
        return presetGroupA;
    }

    public static string[] GetAllPresetB()
    {
        return presetGroupB;
    }

    public static string[] GetAllRhythm()
    {
        return rhythmGroup;
    }

    private static void OutOfRangeException(int timbreNo)
    {
        throw new ArgumentOutOfRangeException("Timbre No.", $"Specified Timbre No. ({timbreNo}) is outside of the permitted range (0 to 63)");
    }
}