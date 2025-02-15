MT-32 Editor - a patch editor and librarian for MT-32/CM-32L and compatible MIDI synthesisers

Unless stated otherwise, any reference in this document to MT-32 also applies to CM-32L, CM-64 or MUNT software synthesiser.
The term 'SysEx' refers to MIDI System Exclusive message files, which normally contain a file extension '.syx'.

COMPATIBILITY:

- The 'main' .NET 6 release of this software should run on any PC running Windows 8, 8.1, 10 or 11 which has the .NET 6.0 runtime installed. A monitor with at least 1080p resolution is recommended. This version can alternatively be compiled for .NET 8.
- The 'legacy' .NET 2 release should run on any PC running Windows 98, Me, 2000, XP or later which has the .NET Framework 2.0 runtime installed. A monitor with at least 720p resolution is recommended. This version can alternatively be compiled for .NET Framework 3.5, 4.0 or 4.5.
- The application should also run (with some UI imperfections) on Linux systems with the latest versions of Wine and wine-mono.msi installed. It has been successfully tested on Ubuntu 24.04 with Wine 9.2 and wine-mono 9.0. 
- A MIDI input device and an MT-32 compatible MIDI output device is strongly recommended but not required (SysEx files can still be loaded and edited without a connected MIDI device, but you will not hear any sounds).
- SysEx (.syx) files created with this software can be uploaded to an MT-32 device using external software such as MIDI-OX, MIDI Tools, MUNT or any MIDI sequencer/DAW with built-in SysEx functionality.

LICENCE:

This software is licenced under the GPL3.0 (https://www.gnu.org/licenses/gpl-3.0.en.html). No warranty is offered. Source code is available from GitHub (https://github.com/sfryers/MT32Editor). The only external dependencies are the NAudio.Midi library for the main version, or the Sanford.Multimedia.Midi library for the legacy version. These can be imported using NuGet in Visual Studio (https://www.nuget.org/packages/NAudio.Midi/2.2.1, https://www.nuget.org/packages/Sanford.Multimedia.Midi/6.6.2).

This software and its author are in no way linked to or endorsed by the Roland Corporation.

FEATURES:

- Load, save and edit standard MT-32 SysEx (.syx) files.
- Load MT-32 SysEx data from MIDI (.mid) files.
- Edit all MT-32 system parameters
- Edit all MT-32 timbre parameters
- Edit all MT-32 patch parameters
- Edit all MT-32 rhythm parameters
- Live preview of timbres via hardware or software MIDI devices
- Load and save individual timbres as .timbre files

A settings file named MT32Edit.ini will be created in the same folder as the application- ensure you have write access to the folder where the application is stored.

LIMITATIONS:

- The application may ignore otherwise valid MT-32 SysEx data if it is formatted in an unconventional way (eg. data blocks which don't align with normal timbre/patch starting addresses).
- Loading/saving data for timbre temp area and patch temp area has intentionally not been implemented (the timbre editor does make use of timbre temp area 1).
- Saving over a .syx file which was not produced by MT-32 Editor may result in some of the original data being lost (eg. non-MT32 SysEx commands or timbre/patch temporary data). It is recommended to save to a new filename or path after opening an externally-produced SysEx file.

LAYOUT:

Menu Bar

File Menu - load or save a SysEx file (a complete MT-32 memory state, consisting of system settings plus up to 64 timbres, 128 patches and 85 rhythm keys). Any existing MT-32 compatible SysEx files can be loaded, browsed and edited.

Individual timbres, in .timbre format, can also be loaded and saved using this menu. SysEx files are saved in a standard format and can be used with any compatible external software and devices, however .timbre files are only intended to be used with this software.

View Menu 
	- Patch Editor (shows the patch editor at the right hand side of the application window).
        - Rhythm Editor (shows the rhythm editor at the right hand side of the application window).
        - Timbre Editor (when selected, if the application window is of a sufficiently small size, hides the patch/rhythm editor and shows the full timbre editor. This option is disabled when the application window is large enough to show the full timbre editor alongside the patch or rhythm editor).
        - Default window size (when selected, resizes the application window to show the full timbre editor alongside the patch or rhythm editor. This option is not currently available in the legacy build).

Options Menu 
	- System area settings (allows setting master volume, master tune, reverb, midi channels and partial reserve values).
	- Autosave every 5 minutes (when enabled, regularly saves the current state to a file named autosave.syx in the same folder as the main applicaton).
        - Save window size and position (when enabled, the application window will be restored to its size and position from the previous session).
	- Ignore system config messages when loading SysEx file (will not load any new MIDI channel assignments, partial reserve settings, master tune, master level or reverb settings). 
	- Exclude system config messages when saving SysEx file (will not save any of the above). Note- if you ONLY wish to save system area settings, use the Save option in the System area settings window.
        - Hardware MT-32 connected (when enabled, adds 60ms delay between large sysex messages to prevent buffer overflow errors on original hardware).
	- Send info to MT-32 display (when enabled, sends messages to device's matrix display to show parameter changes etc).
	- Allow MT-32 reset from SysEx (when enabled, will pass any MT-32 reset messages found whilst loading a SysEx file directly to the connected MIDI Out device).
        - CM-32L mode (when disabled, will highlight in red any timbres or rhythm banks which use PCM samples that are not present in the original MT-32. Changing this option requires the application to restart).
        - Dark mode (set user interface theme either to dark background with light text, or light background with dark text).
	- Show console (show or hide the console window- this option is not available in Windows 98 due to compatibility issues).
	- Verbose console messages (when enabled, sends status messages to the console window).

Help Menu
        - About (shows information about the application, including the current release version).
        - Envelope Diagrams (shows two graphs to help explain the effect of the L0-L3, T1-T5, Sustain and Release parameters included in the Pitch, TVA and TVF settings. This option is only available in the legacy version- the main version displays these diagrams within the Timbre Editor).

MIDI In/MIDI Out - select MIDI input and output devices. 

Play button - sends a Middle C note to the selected MIDI Out device, allowing the current timbre to be auditioned without a MIDI In controller being connected.

Memory Bank Editor

The memory bank editor sits on the left side of the application window. This area displays a list of the MT-32's 64 memory timbre slots. Selecting a timbre opens it in the Timbre Editor. If you select a different timbre after editing another, your changes are kept in memory until you load, save or exit the program.

Timbre Editor

The timbre editor occupies the central part of the application window. This area displays all of the parameters which make up the selected timbre. Altering the controls changes the sound of the current timbre accordingly. You can preview the current timbre using a MIDI input device set to channel 2 (or whichever MIDI channel Part 1 of your MT-32 is set to receive messages on).

An MT-32 timbre consists of up to four separate tones, called 'partials', each with 58 parameters which define the partial's pitch, filter (TVF) and amplitude (TVA) envelopes. Enable and disable each partial using the four numbered checkboxes, and select the partial to be edited using the four radio buttons.

Each partial is made up of either a synthesised tone (saw or square wave), or a sampled (PCM) tone. Partials 1/2 and 3/4 are grouped together in pairs, with one of 13 possible partial structures defining their make-up. Some structures are monophonic, others place one partial on the left stereo channel and the other on the right stereo channel. Other structures utilise a ring modulation effect, allowing one partial to modulate the other's tone. Select the desired partial structures using the two drop-down boxes- "S" denotes a synthesised tone, "P" denotes a PCM tone and "R" denotes a ring modulator. 

When a PCM tone is used for the selected partial, a pull-down list of available PCM tones is shown. Note that the bank 2 tones are only available on a CM-32L compatible device (or by using MUNT with a CM-32L ROM image). When a PCM tone is selected, filter (TVF) parameters are not available.

Timbres can be named using standard ASCII characters (a-z, A-Z, 0-9, space and the symbols !"$%^&*()-+=_[]{};:'@#~\/|,.<>?). Timbre names can be up to 10 characters long. Any other characters entered into the timbre name box will be ignored or substituted when saved or sent to the device. Note that two ASCII symbols will display differently on the MT-32 display; backslash (\, substituted with ¥) and tilde (~, substituted with →).

Refer to the original user manuals for detailed information on device specific features: 
http://www.midimanuals.com/manuals/roland/mt-32/owners_manual/mt-32_om.pdf 
http://www.midimanuals.com/manuals/roland/cm-32l/owners_manual/cm-32l_om.pdf

To assist with the editing process, any user changes to parameters in the Timbre Editor section can be undone and re-done by using the undo/redo buttons. Undo history is preserved when changing between partials in a single timbre, but is cleared when a different timbre is selected.

Patch Editor

The patch editor occupies the right side of the application window. This area displays a list of the MT-32's 128 patches. Selecting a patch will disable or enable the timbre editor, depending on whether that patch is set to a preset/rhythm (non-user editable) or memory (user-editable) timbre. You can preview the selected patch using a MIDI input device set to channel 2 (or whichever MIDI channel Part 1 of your MT-32 is set to receive messages on).

Rhythm Editor

The rhythm editor, when selected in place of the patch editor, also appears at the right hand side of the application window. This area displays a list of the MT-32's rhythm keys. Selecting a rhythm key will disable or enable the timbre editor, depending on whether that rhythm key is set to a rhythm timbre (non-user editable) or a memory timbre (user-editable). You can preview the full set of rhythm timbres using a MIDI input device set to channel 10 (or whichever MIDI channel Part R of your MT-32 is set to receive messages on), or hear the selected timbre by clicking the play button (green arrow) above the list.

TROUBLESHOOTING

Program exits immediately after startup:

- Check whether another program is using the selected MIDI In or MIDI Out devices.
- Try deleting MT32Edit.ini (in the same folder as the program executable file)- this will reset the MIDI device selection.
- Ensure you have write access to the folder where the application is stored. The application is portable (ie. doesn't use an installer), so will happily run from any user-accessible folder on your device.

I can't hear any sound:

- Check that you have an MT-32 compatible device connected to the selected MIDI Out port. If you're running MUNT on the same PC, make sure that the Windows MME driver is correctly installed, otherwise MT-32 Editor won't be able to find the virtual synth device. When MUNT is set up correctly, you'll be able to see an entry named 'MT-32 Synth Emulator' in the list of MIDI Out devices.
- Check that the timbre you're editing has at least one partial selected. If all partials are muted, no sound will be made.
- Check that you don't have multiple partials with the exact same parameter settings, which can cause them to cancel each other out completely (or alternatively to sound at double the volume). Try moving the Fine pitch control a small amount to ensure the partials are not perfectly out of phase with one another.
- Check that you have your MIDI input device connected to the selected MIDI In port.
- Check that your MIDI input device is set to send on MIDI channel 2 (or whichever channel your MT-32 is using for Part 1).
- Check in the system settings window that Part 1 and the Rhythm Part are assigned to an appropriate channel (2 and 10 by default). If any part is assigned a channel value of zero, it will be disabled.
- Press the refresh button in the Timbre Editor to re-send the current timbre data to the connected MIDI device.

Unexpected timbres are coming from my device:

- Check that the MIDI Out port is connected to an MT-32 or compatible device. Other devices will sound in response to MIDI messages, but will not understand the MT-32 SysEx commands issued by this application.
- If you're using MUNT, make sure MUNT is running before opening MT-32 Editor.
- Press the refresh button in the Timbre Editor to re-send the current timbre data to the connected MIDI device.
- If you've changed the MIDI Out port during the current session, you'll need to restart MT32 Editor to fully synchronise your MIDI device.
- If you've changed the Unit No. in MT32Edit.ini from the default value of 17, only devices with a matching Unit No. value will respond to SysEx messages. Unless you're attempting to work with multiple hardware MT-32 devices, do not change the default value. Default Unit No. can be changed on a hardware MT-32 by pressing the [MASTER VOLUME] + [SOUND] buttons together. CM-32L and later devices have a fixed Unit No. of 17, which cannot be changed.

My timbre sounds crackly/distorted:

- MT-32 devices will produce audible clipping if patches or partials are set too loud. Reduce the master volume, the level of the patch or the level of the individual partials in a memory timbre to help resolve this.

I can't save my timbre or SysEx files: 

- If you see an error message "File not found. Check the filename and try again.", check that you have write access to the folder you're trying to save into.