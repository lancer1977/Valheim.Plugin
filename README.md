# Valheim.Plugin

**Valheim.Plugin** is a C# Valheim mod project intended as a foundational plugin for the Valheim modding ecosystem.  
It provides a clean, extensible starting point for building gameplay changes, utilities, and integrations using standard Valheim mod loaders.

---

## 🚀 Project Overview

This repository serves as:

- 🧩 A starter Valheim plugin project
- 🛠 A base for building gameplay mods or server-side utilities
- 📦 A structured, testable C# mod codebase

The project is designed to grow as your mod evolves, supporting additional features, configs, and tooling over time.

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
