---
title: RPC Command System
status: done
owner: @DreadBreadcrumb
priority: high
complexity: 1
created: 2026-03-19
updated: 2026-03-19
tags: [feature, valheim-plugin, modding]
---

# RPC Command System

The RPC Command System provides a robust infrastructure for defining and handling custom commands in Valheim. It uses a mapping mechanism to route incoming RPC calls to their respective command handlers.

## `RpcCommandMap`

The `RpcCommandMap` is a central registry that associates command names with their corresponding action handlers. This allows for a clean separation of command definition and implementation.

- **Centralized Registration**: Easily add new commands to the map.
- **Argument Handling**: Supports parsing and passing arguments to command handlers.
- **Dynamic Routing**: Dispatches RPC calls based on the command identifier.

## Custom Command Infrastructure

By leveraging the `RpcCommandMap`, developers can create complex server-side and client-side interactions.

- **Ease of Use**: Define new commands with minimal boilerplate.
- **Extensibility**: Build upon the base system to create unique modding features.
- **Inter-Mod Communication**: Enables different mods to interact via standardized RPC calls.
