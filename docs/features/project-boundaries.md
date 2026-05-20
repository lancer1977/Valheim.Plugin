---
title: Valheim Project Boundaries
status: active
owner: @DreadBreadcrumb
priority: high
complexity: 2
created: 2026-05-15
updated: 2026-05-15
tags: [feature, valheim-plugin, valheim-restserver, channel-cheevos]
---

# Valheim Project Boundaries

## Summary

`Valheim.Plugin` is the older Polyhydra Valheim modding/RPC experiment. It is
related to `Valheim.RestServer`, but it is not the current production REST
contract used by `channel-cheevos`.

Use this repository as a reference for legacy command experiments, RPC patterns,
Harmony/Jotunn bootstrap ideas, and older PolyRcon-era behavior.

## Current Ownership

- `Valheim.Plugin`
  - Legacy modding foundation and PolyRcon/RPC command experiments.
  - Contains older command implementations for effects, raids, audio, whisper,
    shake, and smite.
  - Uses the older `/command` style HTTP entry point.
- `Valheim.RestServer`
  - Current REST-facing Valheim mod.
  - Owns the active OpenAPI/Postman contract.
  - Exposes command-name paths such as `/serverstats`, `/players`, `/shout`,
    `/spawnnpc`, and `/randomraid`.
- `channel-cheevos`
  - Current backend authority and REST caller.
  - Uses `PolyhydraGames.Valheim.Api`, `ValheimServerManager`, and configured
    `Valheim:BaseUrl` to call the Valheim REST server.
- `cc-sidecar`
  - Future display/overlay surface only unless a bridge is intentionally built.
  - Should not become the default Valheim command authority.

## Relationship

```text
Valheim.Plugin
  legacy PolyRcon/RPC experiments
  useful reference for command behavior and mod hooks

Valheim.RestServer
  current in-game REST mod
  exposes HTTP endpoints from inside Valheim/BepInEx

channel-cheevos
  calls Valheim.RestServer
  applies stream/admin policy

cc-sidecar
  displays public state
```

## Migration Guidance

- [ ] Treat `Valheim.RestServer` as the source of truth for new REST endpoints.
- [ ] Port useful command experiments from `Valheim.Plugin` only after verifying
      they still match current Valheim/Jotunn APIs.
- [ ] Do not add new public REST contract work to `Valheim.Plugin`.
- [ ] Keep risky actions behind `channel-cheevos` policy and moderation.
- [ ] Use `cc-sidecar` for overlays, not direct server mutation.

See also: [Legacy Extraction Plan](../roadmaps/legacy-extraction-plan.md).

## Telemetry Expansion Notes

The next major product opportunity is Valheim telemetry:

- server snapshot
- player health and position
- current raid/event
- game day/time
- recent deaths
- recent kills
- recent REST-triggered actions

New telemetry should be implemented in `Valheim.RestServer` first, then pulled
into `channel-cheevos` for persistence, policy, dashboards, and sidecar display.
