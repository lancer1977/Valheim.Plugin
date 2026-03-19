# Valheim.Plugin

**Location:** `~/code/Valheim.Plugin`

**Purpose:** Valheim mod providing RCON functionality, HTTP command server, and gameplay commands for server administrators. Integrates with BepInEx mod loader.

## Tech Stack

- **Framework:** .NET Framework 4.8
- **Mod Loader:** BepInEx 5+
- **Patching:** Harmony (0Harmony)
- **Libraries:** Jotunn (ValheimLib)

## Project Structure

```
Valheim.Plugin/
├── src/
│   ├── Commands/           # RCON command implementations
│   │   ├── AddEffect/      # Status effects
│   │   ├── Smite/          # Smite commands
│   │   ├── Whisper/        # Messaging
│   │   └── RaidCommand.cs  # Trigger raids
│   ├── WebServer/          # HTTP command server
│   │   ├── HttpCommandServer.cs
│   │   └── ActionProcessor.cs
│   ├── Plugin.cs           # Main plugin entry
│   ├── RpcCommand.cs       # RPC command definitions
│   └── RpcCommandMap.cs    # Command mapping
├── test/                   # Unit tests
├── dependencies/           # Valheim/BepInEx DLLs
└── publish/                # Build output
```

## Entry Points

| File | Purpose |
|------|---------|
| `src/Plugin.cs` | Main plugin, BepInEx entry point |
| `src/WebServer/HttpCommandServer.cs` | HTTP command server |
| `src/RpcCommandMap.cs` | Command registration |

## Key Dependencies

| Package | Purpose |
|---------|---------|
| BepInEx | Mod loader framework |
| 0Harmony | Runtime patching |
| Jotunn | Valheim library |
| ValheimRcon | RCON protocol support |
| Newtonsoft.Json | JSON serialization |

## Build & Deploy

```bash
# Build
dotnet restore
dotnet build

# Deploy
# Copy publish/*.dll to Valheim/BepInEx/plugins/
```

## Features

- RCON server functionality
- HTTP command API
- Player manipulation (smite, whisper, effects)
- Raid/trigger events
- Impersonation commands

## Notes

- Requires BepInEx installed in Valheim
- `dependencies/` contains game assemblies
- Soft dependency on ValheimRcon