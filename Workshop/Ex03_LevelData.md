# Exercise 03 — Level Design via Data

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex03` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
Live-ops reality: "make Level 2 harder" — without touching a line of C#.
Level tuning lives in the `LevelData` component in each level scene.

## Instructor demo (5 min)
1. Open `Assets/GemHunterMatch/Scenes/Level1.unity`; show LevelData in the
   Inspector: `MaxMove`, `Goals` (gem + count).
2. Read the live values from the terminal:
   ```
   unity command --project-path . eval 'return Match3.LevelData.Instance == null ? "open a level scene in play mode" : "moves=" + Match3.LevelData.Instance.MaxMove;'
   ```

## Your turn (10 min)
1. Prompt:
   > Open the Level2 scene with the Unity CLI and rebalance it: MaxMove from
   > its current value to 4 fewer, and raise the first goal's Count by 5.
   > Use the CLI's scene commands / eval — do not hand-edit the .unity file.
   > Then save the scene and show me the new values as evidence.
2. Enter play mode on Level 2 and confirm the HUD shows the new move count.

## Verify
- Eval on the open (play-mode) scene reports the new `MaxMove`.
- The move counter in the HUD matches.

## If you get stuck
`git diff ex03-start..ex04-start` shows exactly which scene values changed.
