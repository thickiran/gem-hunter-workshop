# Exercise 08 — FEAT-88 — Cross Bomb, Solo

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex08` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
No prompt template. A ticket, a codebase, an agent — you.

## The ticket
> **FEAT-88 — Cross Bomb booster**
> A new bonus gem: when used, clears its entire row AND column. Follows the
> existing BonusGem pattern (see SmallBomb/LineRocket). Needs: the script, a
> prefab with a distinct look (tint is fine), and a trigger sound reusing an
> existing clip. Must not break: normal matches, other boosters, move
> counting, level_lint.

## Instructor demo (5 min)
Instructor walks the BonusGem contract once — `m_Usable = true` in Awake,
`Use()` builds a forced-deletion match via `Board.CreateCustomMatch`, then
`HandleContent` per affected cell — and stops. The rest is yours.

## Your turn (10 min)
Write your own prompt. Demand: plan first, files named, the SmallBomb pattern
followed, and play-mode evidence (row+column actually cleared) before "done".

## Verify
- Swapping/double-clicking the Cross Bomb clears its full row and column.
- Other boosters still work; `level_lint` still passes; a failed swap still
  costs no move (your Ex06 fix survived).

## If you get stuck
`git diff ex08-start..ex09-start` is the canonical Cross Bomb.
