# SCP-294 — 2.0.0

A coin-operated anomalous drinks machine with configurable Entrance Zone spawn points, drink effects, dispensing sounds and admin commands. The included server preset allows eight uses per machine and disables community joke drinks.

Updated for **SCP:SL 14.2.7 / EXILED 9.14.2 / LabAPI 1.1.7 / ProjectMER 2026.7.6.1**. [Download the release](https://github.com/Draakoor/SCPSL-SCP294/releases/tag/v2.0.0).

## Installation

1. Back up the existing plugin and its configuration, then stop the server.
2. Install the matching ProjectMER, EXILED and [AudioPlayerApi 1.1.2](https://github.com/Killers0992/AudioPlayerApi/releases/tag/1.1.2), including its NVorbis/SharpCompress dependencies.
3. Extract the release ZIP: merge `EXILED/` into the EXILED configuration root, and `LabAPI/` into the SCP Secret Laboratory LabAPI root. Replace the old plugin DLL; do not keep duplicate versions under different filenames.
4. The ZIP includes a ready server preset at `EXILED/Configs/Plugins/ultimate294/7777.yml`. Rename `7777.yml` for another server port. Merge its keys into existing settings if you want to retain your own configuration.
5. Start the server. SCP-294 spawns when a normal round starts; its room, zone and position are logged when location logging is enabled.

For manual installation, copy `Ultimate294.dll` into `EXILED/Plugins/`, and `Schematics/scp294` into `LabAPI/configs/ProjectMER/Schematics/`. Copy Both files under `Audio/` → `EXILED/Configs/SCP294/`.

The release ZIP includes the plugin, model, configuration and sounds. Framework/API dependency binaries must already be installed and are not bundled. On Linux these configuration roots are normally under `/home/container/.config/`; on Windows they are under the server account’s application-data directory.

## Usage

Hold a coin, stand near the machine and enter `.scp294 <drink>` in the client console. Administrators with `SCP294.admin` can use RA `scp294 create`, `remove`, `setuses` and `givedrink`. The assembly remains `Ultimate294.dll`; do not also load the old SCP294/Ultimate294 DLL. The schematic folder is lowercase `scp294`.

The `tbsite anomalies` console helper mentioned by the Technikbudde build belongs to the optional TechnikbuddeSite plugin; this standalone plugin does not require it.

## Source and validation

[BUILD.md](BUILD.md) documents the standalone build. The C# gameplay sources are the compatible version already used on Draakoors Technikbudde. [RELEASE-NOTES.md](RELEASE-NOTES.md) records the port changes and validation limits.

## Attribution

Original Ultimate294 author: creepycats. This compatibility port also follows [gatodevelowoper/Ultimate294](https://github.com/gatodevelowoper/Ultimate294). Existing source/DSP attribution is retained. The model and dispensing audio come from that project’s v1.1.1-bugfix release. No new blanket license is asserted over the original authors’ work. Preserve the existing notices when redistributing source or assets.
