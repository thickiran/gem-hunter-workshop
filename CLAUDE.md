# Gem Hunter Workshop — Agent Contract (stub)

This file is deliberately minimal. **Exercise 02 of the workshop is writing the
real contract** — after your recon of the codebase in Exercise 01, you will
replace this stub with a proper CLAUDE.md (protected areas, conventions, how to
verify). Until then, the hard safety rules:

- Never modify anything under `Assets/GemHunterMatch/Settings/` or
  `ProjectSettings/` unless explicitly asked.
- Never delete scenes. Never edit `.unity`/`.prefab` YAML by hand while the
  editor is reachable — use the Unity CLI (`unity status`, `unity command`,
  `unity command eval '<C#>'`).
- The game code lives in the `Match3` namespace under
  `Assets/GemHunterMatch/Scripts/`. Workshop docs live in `Workshop/`.
- Verify every change: clean compile, then prove behavior with eval or a
  play-mode test, and report the evidence.
