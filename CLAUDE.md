# Gem Hunter Workshop — Agent Contract

Production-style match-3 codebase (Unity's Gem Hunter Match sample) used for
the Panteon AI/CLI workshop. Read `Workshop/ARCHITECTURE.md` first.

## Protected — do not touch unless explicitly asked
- `Assets/GemHunterMatch/Settings/` (URP/render settings) and `ProjectSettings/`
- Scene/prefab YAML by hand — a live editor is connected; use the Unity CLI
  (`unity status`, `unity command --project-path .`, `eval '<C#>'`)
- Never delete or rename scenes; never edit `Packages/` without being asked

## Where each kind of change belongs
- **Gameplay logic** → `Assets/GemHunterMatch/Scripts/` (namespace `Match3`);
  board/swap/match flow lives in `Board.cs` — change it surgically, it is the
  load-bearing wall
- **Level tuning** (moves, goals, gem mix) → scene data: the `LevelData`
  component and `Board.ExistingGems` in the level scene — never hardcode into C#
- **Boosters** → subclass `BonusGem` in `Scripts/BonusGem/`, follow the
  SmallBomb pattern (`m_Usable = true`, `Use()` + `CreateCustomMatch`)
- **HUD/UI** → through `UIHandler` and the existing UI Toolkit documents
- **Editor tooling** → `Scripts/Editor/`; CLI commands via
  `Unity.Pipeline.Commands.CliCommandAttribute` on static methods
- **Workshop docs** → `Workshop/`

## Conventions
- Namespace `Match3` for runtime code; match the file's existing brace and
  naming style (`m_Field` privates, PascalCase publics)
- Prefer the hooks that exist (`LevelData.OnGoalChanged`, `OnMoveHappened`,
  `Board` callbacks) over new plumbing

## Verification ritual — nothing is "done" without it
1. Clean compile: `unity command --project-path . recompile` then
   `recompile_status` → no errors
2. Behavior proof: play mode + `eval` evidence (e.g.
   `Match3.LevelData.Instance.RemainingMove` before/after)
3. For bugs: prove the root cause with evidence BEFORE changing code, and
   prove the fix the same way after
4. `unity command --project-path . level_lint` must pass on the open level
   (once the linter exists, Ex07+)
