# Exercise 07 — level_lint — Your Own CLI Command

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex07` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
Studio tooling: a `level_lint` command any agent (or CI) can run against the
open level scene. Same mechanism you used in Workshop 1 — `[CliCommand]` from
the pipeline package — now guarding a real content pipeline.

## Instructor demo (5 min)
`unity command --project-path . | grep lint` — nothing. Let's change that.
Recap the attribute pattern from the pipeline package source.

## Your turn (10 min)
1. Prompt:
   > Create `Assets/GemHunterMatch/Scripts/Editor/LevelLint.cs`: an editor
   > class registering a CLI command `level_lint` (CliCommandAttribute from
   > the com.unity.pipeline package) that validates the OPEN scene:
   > (1) a LevelData exists with MaxMove > 0, (2) every Goal has Count > 0
   > and a non-null Gem, (3) every Goal's gem type exists in
   > Board.ExistingGems, (4) the board has at least one spawner
   > (Board.SpawnerPosition non-empty in play mode — outside play mode check
   > it via the scene's authoring tiles if simpler). Output a readable
   > PASS/FAIL report; fail loudly per broken check.
2. Run it on Level 1 (PASS), then sabotage: set a goal's Count to 0 via eval,
   run again (FAIL), undo.

## Verify
- `unity command --project-path . level_lint` exists and passes on Level 1.
- Sabotage turns it red with a message that names the broken check.

## If you get stuck
`git diff ex07-start..ex08-start` is the canonical linter.
