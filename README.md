# Valheim.Plugin

> Archived and reference-only.
>
> The active Valheim REST contract and stream-facing work now live in `Valheim.RestServer`.

**Valheim.Plugin** is the older PolyRcon/RPC-era Valheim mod project. It remains here as a historical reference for legacy command experiments, Harmony/Jotunn hooks, and older implementation ideas.

---

## 🚀 Project Overview

This repository now serves as:

- 🧩 A legacy plugin reference
- 🛠 A historical source for old gameplay/RPC experiments
- 📦 A frozen C# mod codebase kept for archival lookup

## Relationship To Valheim.RestServer

The current HTTP REST contract used by `channel-cheevos` lives in
`Valheim.RestServer`.

Use this repo only as a reference for legacy command experiments and mod hooks.
If you need current REST endpoints, telemetry, or stream-safe integration work,
use `Valheim.RestServer` instead.

See [Archive Notes](./docs/ARCHIVE.md) and [Valheim Project Boundaries](./docs/features/project-boundaries.md).

This historical snapshot is preserved for reference only.

---

## 📁 Repository Structure

```
/
├── src/                # Plugin source code
├── test/               # Unit tests
├── docs/               # Documentation sources
├── images/             # Images used in documentation
├── Valheim.Plugin.sln  # .NET solution
├── build.yml           # CI pipeline
├── docfx.json          # DocFX configuration
├── LICENSE
└── README.md
```

---

## 🛠 Getting Started

### 📦 Prerequisites

| Tool | Version |
|------|---------|
| Valheim | Latest |
| .NET SDK | 7.0 or newer |
| Git | Latest |
| BepInEx | Installed |
| (Optional) DocFX | Latest |

You must have **BepInEx** installed into your Valheim game directory to load this plugin.

---

### 📥 Clone the Repository

```bash
git clone https://github.com/lancer1977/Valheim.Plugin.git
cd Valheim.Plugin
```

---

### 🔧 Build the Plugin

```bash
dotnet restore
dotnet build
```

The resulting plugin `.dll` will be located in the build output directory.

---

### ▶️ Installing the Plugin

1. Build the project
2. Copy the generated `.dll` into:

```
Valheim/BepInEx/plugins/
```

3. Launch Valheim

If loaded successfully, the plugin will appear in the BepInEx console/log output.

---

## 🧠 Features & Dependencies

This project is structured to support:

- BepInEx plugin lifecycle hooks
- Harmony patching
- Expandability for Jötunn or other Valheim modding libraries
- Configurable settings and logging

---

## 🧠 Example Use Cases

- ⚔️ Gameplay tweaks and enhancements
- 🧰 Quality-of-life utilities
- 🧪 Experimentation with Valheim internals
- 🔗 Integration with external services or APIs

---

## 🤝 Contributing

Contributions are welcome!

1. Fork the repository
2. Create a feature branch  
   ```bash
   git checkout -b feature/my-feature
   ```
3. Commit your changes
4. Open a Pull Request

Please include tests and documentation updates when applicable.

---

## ⚠️ Valheim Version Compatibility

Valheim updates may introduce breaking changes.

Best practices:
- Test against current Valheim versions
- Keep Harmony patches minimal and scoped
- Update dependencies regularly

---

## 📜 License

This project is licensed under the **MIT License**.  
See the [LICENSE](LICENSE) file for details.

---

## ❓ Support

If you encounter issues or have questions:

- Open a GitHub Issue
- Include Valheim version and BepInEx version
- Provide logs when possible

---

Happy modding! ⚔️


## 📖 Documentation
Detailed documentation can be found in the following sections:
- [Archive Notes](./docs/ARCHIVE.md)
- [Feature Index](./docs/features/README.md)
- [Core Capabilities](./docs/features/core-capabilities.md)
- [Valheim Project Boundaries](./docs/features/project-boundaries.md)
## Quality Goal

Non-UI and non-web library code should generally aim for 80%+ unit test coverage. When modifying shared/core libraries, prefer adding or updating tests as part of the change.
