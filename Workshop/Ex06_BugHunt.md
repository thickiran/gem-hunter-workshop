# Exercise 06 — Bug Hunt — BUG-312

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex06` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
The morning-demo loop, on hard mode: an unfamiliar 1,500-line Board. The rule
has not changed: **no fix until the root cause is proven.**

## The bug report
> **BUG-312** · Live, many player reports, intermittent
> "Players run out of moves way too fast on some levels. The move counter
> sometimes drops when 'nothing happened'. One video shows a swap bouncing
> back — and the counter still went down. Started after the last gameplay
> patch."

## Instructor demo (5 min)
Reproduce it: play any level, make a swap that does NOT create a match (it
animates back) — watch the move counter. Then the wrong fix ("give players
more moves") vs. the right question: *who calls `LevelData.Moved()` and when?*

## Your turn (10 min)
1. Prompt:
   > Investigate BUG-312 [paste the report]. Find every call site of
   > LevelData.Moved() and explain, from Board.cs's swap flow, exactly when a
   > move should be consumed vs. when it currently is. Prove the root cause
   > with evidence (code path + a play-mode eval showing RemainingMove
   > dropping on a reverted swap) BEFORE proposing any change. Then apply the
   > minimal fix and prove it the same way.
2. The evidence you want, live in play mode:
   ```
   unity command --project-path . eval 'return "moves=" + Match3.LevelData.Instance.RemainingMove;'
   ```
   → make a failed swap → run again. Bugged: it dropped. Fixed: it doesn't.

## Verify
- Before: failed swap consumes a move (eval numbers prove it).
- After the one-line fix: failed swaps are free, successful swaps still cost 1.
- The agent's explanation names the exact wrong call site in `TickSwap`'s
  revert branch.

## If you get stuck
Reject symptom patches (raising MaxMove, clamping). The diff to `ex07-start`
is the canonical fix.
