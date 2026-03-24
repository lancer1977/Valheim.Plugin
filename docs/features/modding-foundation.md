---
title: Modding Foundation
status: done
owner: @DreadBreadcrumb
priority: high
complexity: 1
created: 2026-03-19
updated: 2026-03-19
tags: [feature, valheim-plugin, modding]
---

# Modding Foundation

The Modding Foundation provides a structured, testable C# base for building Valheim mods. This architecture is designed to overcome common modding challenges such as complex game logic, lack of testing, and maintenance difficulties.

## Structured Base

- **Separation of Concerns**: Decouples game-specific code from the mod's core infrastructure.
- **Dependency Injection**: Uses DI principles to manage dependencies and enhance testability.
- **Modular Components**: Allows developers to build mods as a collection of reusable and independent components.

## Testable Infrastructure

- **Mocking Support**: Interfaces and abstractions are used throughout the codebase, making it easy to mock game components for unit testing.
- **Unit Testing Framework**: Pre-configured to support unit tests, ensuring reliability and preventing regressions.
- **Consistent Quality**: Promotes software engineering best practices within the Valheim modding community.
