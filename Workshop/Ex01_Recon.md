# Exercise 01 — Recon — Map the Codebase

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex01` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
You've just been handed a live game's code. Before touching anything, make the
agent map it — and *verify* its claims. Agents are excellent guides and
confident liars; today you learn to tell the difference.

## Instructor demo (5 min)
1. Ask Claude Code: *"Map this codebase: entry scene flow, where match
   detection lives, how boosters work, how levels are authored. Write nothing
   yet."*
2. Pick one claim ("match detection is in `Board.DoCheck`") and verify it in
   the source before believing it.

## Your turn (10 min)
1. Prompt:
   > Explore `Assets/GemHunterMatch/Scripts/` and produce
   > `Workshop/ARCHITECTURE.md`: (1) the scene flow from Init to a playable
   > level, (2) the five most important classes and one sentence each,
   > (3) where match detection happens, (4) how a booster (BonusGem) plugs in,
   > (5) how level data (moves, goals) is authored. Keep it under a page.
   > Cite file paths for every claim.
2. **Verify two claims yourself** — open the cited file, confirm the line is
   real. If a citation is wrong, tell the agent; make it correct the doc.

## Verify
- `Workshop/ARCHITECTURE.md` exists and every section cites real paths.
- You personally confirmed at least two citations in the source.

## If you get stuck
`git diff ex01-start..ex02-start` shows the canonical ARCHITECTURE.md.
