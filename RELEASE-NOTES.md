# SCP-294 2.0.0

Compatibility release for SCP:SL 14.2.7, EXILED 9.14.2, LabAPI 1.1.7 and ProjectMER 2026.7.6.1.

Replaces legacy MapEditorReborn and SCPSLAudioApi integrations with ProjectMER and AudioPlayerApi. Updates voice/event handling, round cleanup, delayed-operation guards and scoped Harmony removal. Retains the machine model, drink definitions and dispensing sounds. The supplied preset uses finite stock and bounded size effects.

Source and build project are now directly maintained in `Draakoor/SCPSL-SCP294`. Build dependencies are provided through `SLReferences`; no game DLLs, server secrets or machine-specific project paths are shipped.

Validation: standalone net48 Release build completed. This gameplay source previously loaded and spawned SCP-294 on the live server, with its location logged. Full client visuals and multiplayer playtesting remain separate checks.

Download `Ultimate294.dll` for an existing configured installation, or `SCP294-2.0.0.zip` for the plugin, model, audio, configuration and documentation. Dependencies must already be installed; see README.md.
