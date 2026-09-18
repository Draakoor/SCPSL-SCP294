# Build SCP-294 2.0.0

Target: SCP:SL **14.2.7**, EXILED **9.14.2**, LabAPI **1.1.7** and ProjectMER **2026.7.6.1**. The plugin targets .NET Framework 4.8 and builds with a current .NET SDK.

Supply DLLs from the matching server in a separate folder: the game's Managed assemblies, EXILED API/Events/Loader, ProjectMER, LabApi and their existing dependencies. SCP-294 additionally requires the tested AudioPlayerApi 1.1.2 and Harmony references. Proprietary game-reference binaries are not included.

```powershell
dotnet build SCP294.csproj -c Release -p:SLReferences=C:/path/to/server-references
```

Output: `bin/Release/net48/Ultimate294.dll`. The NuGet package Microsoft.NETFramework.ReferenceAssemblies 1.0.3 supplies net48 framework references. For an offline NuGet feed add `--source C:/path/to/feed`. No absolute developer paths or custom post-build deployment commands are used.

The gameplay C# sources match the server-tested Technikbudde port. Only the standalone project/assembly metadata and release documentation differ. A fresh standalone Release build was completed for this publication. Earlier server startup and round logs confirmed plugin enablement and a spawned SCP-294 with room/zone/coordinates. Client appearance and full multiplayer behavior are not certified by that smoke test.
