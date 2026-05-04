# Valheim.Plugin portfolio roadmap

## Snapshot
- 90-day evidence: 9 commits, 25 files changed
- Last signal: `7c17c0e`
- Top modified areas: `docs`, `test`, `src`
- Stack: .NET
- Docs folder: yes
- Roadmap folder: no
- Features docs: yes
- Tests indexed: yes (`test/`)

## Implemented now (V1 baseline)
- Plugin and RPC surfaces are documented across `valheimplugin.md`, `rpc-command-system.md`, and `modding-foundation.md`.
- Publish and test workflows are documented through `sub-module-publish.md` and `sub-module-test.md`.
- Starter and image guidance is captured in `a-starter-valheim-plugin-project.md` and `sub-module-images.md`.

## Gaps and opportunities
- Integration behavior around plugin lifecycle in real Valheim contexts remains partially under-tested.
- Publish assumptions are not consistently enforced with explicit release criteria.
- No explicit rollback strategy for breaking command changes.

## V1 (stability)
- [ ] Add end-to-end smoke for plugin load, unload, and RPC command handling.
- [ ] Add local install and startup verification steps to docs and release checklist.
- [ ] Add compatibility notes for versioned command payloads and config.
- [ ] Make publish testable from clean checkout in one documented command path.

## V2 (confidence)
- [ ] Expand integration test matrix for server + command edge cases.
- [ ] Add changelog-driven migration notes for command API and runtime config.
- [ ] Align `README`, feature docs, and test results into one release artifact.
- [ ] Document dependency and environment constraints in a stable checklist.

## V10 (scale)
- [ ] Formalize plugin API compatibility policy and support matrix by Valheim versions.
- [ ] Add monitoring signals for command failures and lifecycle faults.
- [ ] Introduce reusable Valheim plugin maintenance template for future repos.
- [ ] Create quarterly stability review with owner-defined risk acceptance criteria.

## Delivery checklist
- [ ] Plugin surface changes are accompanied by integration test evidence.
- [ ] Publish and docs are updated together before merge.
- [ ] Runtime behavior changes include explicit rollback instructions.
