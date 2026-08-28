# Exercise 04 — Combo Counter — a Feature in Someone Else's UI

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex04` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
A real multi-file feature: a combo counter that tracks consecutive
goal-matches and shows "Combo xN" in the level HUD. The codebase already has
the hooks — `LevelData.OnGoalChanged` and `OnMoveHappened` delegates. Finding
and using existing hooks (instead of inventing new plumbing) is the skill.

## Instructor demo (5 min)
Show the delegates in `LevelData.cs`; sketch the design: a small
`ComboTracker` that increments on goal-matches and resets when a move happens
without one — then the UI label.

## Your turn (10 min)
1. Prompt:
   > Add a combo counter to levels: create
   > `Assets/GemHunterMatch/Scripts/ComboTracker.cs` in the Match3 namespace —
   > it subscribes to LevelData's OnGoalChanged and OnMoveHappened, counts
   > consecutive moves that scored at least one goal gem, resets otherwise,
   > and exposes CurrentCombo. Display "Combo xN" (only when N >= 2) in the
   > level HUD via the existing UI system — follow how UIHandler does labels.
   > Wire it into the level scenes' Managers, verify in play mode.
2. Review the plan hard: is it reusing the delegates, or inventing new events?

## Verify
- Two scoring moves in a row → "Combo x2" appears; a dud move clears it.
- `unity command --project-path . eval 'return UnityEngine.Object.FindFirstObjectByType<Match3.ComboTracker>().CurrentCombo;'`

## If you get stuck
`git diff ex04-start..ex05-start` is the canonical implementation.
