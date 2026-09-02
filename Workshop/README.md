# Gem Hunter — AI/CLI in a Real Codebase (Workshop 2, Track A)

Workshop 1 built a game from scratch. This one is the harder, more valuable
skill: working with an agent inside a production-style codebase you didn't
write — Unity's official **Gem Hunter Match** sample (~4,800 lines, board
logic, boosters, shop, levels).

## Format
Nine exercises, each: **5 min instructor demo → 5–10 min hands-on → terminal
verification.** Detailed steps live in `Workshop/Ex0N_*.md`.

## Catch-up: git checkpoints
Every exercise has a start branch equal to the previous exercise's finished
state. One command syncs you:

```
./catchup.sh ex05
```

Your uncommitted work is auto-stashed (`git stash list` to recover). This also
happens to be exactly the branch discipline we preach: nobody's experiments can
break anyone else's afternoon.

| # | Exercise | Teaches |
|---|----------|---------|
| 01 | Recon | agent-led code archaeology; verifying agent claims |
| 02 | Write the CLAUDE.md | encoding what you learned as an agent contract |
| 03 | Level design via data | data-driven changes; eval on a live board |
| 04 | Combo counter | multi-file feature following existing patterns |
| 05 | New gem type | extending someone else's system |
| 06 | Bug hunt (BUG-312) | root-cause proof in unfamiliar code |
| 07 | level_lint command | studio tooling over a content pipeline |
| 08 | Cross Bomb (FEAT-88) | solo: ticket → verified feature |
| 09 | iOS build | shipping; the CI story |

`complete` branch = the finished workshop state.

## Ground rules
- The agent works ONLY where the exercise says; reject plans that wander.
- No fix without a proven root cause; no "done" without terminal evidence.
- Stuck? 1) this doc, 2) `git diff ex0N-start..ex0N+1-start` shows the
  canonical solution, 3) instructor.

## Track B checkpoint
`./catchup.sh reskin` is the finished Track B state (branch `reskin-complete`):
a placeholder 7-gem set under `Assets/Reskin/` (board sprites + HUD icons,
provenance in `SOURCES.md`) applied to all gem prefabs, global 2D lights
warmed in every level. Without Scenario access, pull just the set into your
own branch with `git checkout reskin-complete -- Assets/Reskin`. Before/after
captures: `Workshop/reskin_before.png`, `Workshop/reskin_after.png` (on that
branch).
