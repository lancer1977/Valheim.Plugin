# Valheim.Plugin Legacy Extraction Plan

## Summary

`Valheim.Plugin` is the older PolyRcon/RPC-era Valheim project. It should not
receive new public REST contract work, but it remains useful as a source of
legacy command behavior and Harmony/Jotunn implementation ideas.

The modernization plan is to mine useful behavior from this repo, port it into
`Valheim.RestServer` only when it still works against current Valheim APIs, and
then validate it through the shared `API.GameServerInterop` contracts.

## Extraction Checklist

- [ ] Inventory command folders.
- [ ] Mark commands as keep, port, replace, or retire.
- [ ] Compare each command with `Valheim.RestServer` equivalents.
- [ ] Identify hook/bootstrap code that can help telemetry capture.
- [ ] Identify broken commands that should remain retired.
- [ ] Document any current Valheim API changes needed before porting.

## Candidate Areas To Mine

- [ ] AddEffect command/bootstrap behavior.
- [ ] AddNoise command/bootstrap behavior.
- [ ] Shake command/bootstrap behavior.
- [ ] Smite command/bootstrap behavior.
- [ ] Whisper behavior.
- [ ] Raid/event command behavior.
- [ ] RPC command mapping ideas.

## Retired Or Risky Areas

- [ ] `/command`-only HTTP endpoint pattern.
- [ ] PolyRcon-specific assumptions.
- [ ] Generated local deploy artifacts.
- [ ] `Broke_Commands` until each command is individually revalidated.

## Target Destination

- New REST endpoints go to `Valheim.RestServer`.
- Shared DTOs/contracts go to `API.GameServerInterop`.
- Stream policy goes to `channel-cheevos`.
- Display state goes to sidecar/play/mobile consumers.

## Definition Of Done

- [ ] Legacy command inventory exists.
- [ ] Useful behavior is linked to a `Valheim.RestServer` issue/roadmap item.
- [ ] No new stream-facing work is planned directly in `Valheim.Plugin`.
- [ ] `Valheim.Plugin` docs clearly identify the repo as reference/legacy.
