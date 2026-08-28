# Exercise 05 — A Seventh Gem

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex05` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
Content extension: add a new gem type to Level 1's mix. The system is
data-driven — `Board.ExistingGems` per scene plus a Gem prefab with a unique
`GemType` int. Done right, zero logic changes.

## Instructor demo (5 min)
Show an existing gem prefab (sprite, `GemType`, match VFX) and where the
board learns about gem types (`Board.ExistingGems` in the level scene).

## Your turn (10 min)
1. Prompt:
   > Add a seventh gem type: duplicate an existing gem prefab into a new
   > "Amethyst" prefab with a distinct purple-tinted sprite (tint the sprite
   > via the SpriteRenderer color if no new art is available), give it the
   > next unused GemType number, and register it in the Level1 scene's
   > Board.ExistingGems via the CLI. Do not modify any C#. Verify in play
   > mode that the new gem spawns and matches.
2. Play Level 1: purple gems should appear, fall, and match like the rest.

## Verify
- `unity command --project-path . eval 'return UnityEngine.Object.FindFirstObjectByType<Match3.Board>().ExistingGems.Length;'` went up by one.
- A 3-match of the new gem disappears correctly in play mode.

## If you get stuck
`git diff ex05-start..ex06-start` shows the canonical prefab + scene change
(ignore the LevelData/Board noise from the seeded exercise ahead…).
