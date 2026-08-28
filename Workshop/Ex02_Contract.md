# Exercise 02 — Write the Agent Contract

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex02` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
Turn recon into rules. The repo ships a stub `CLAUDE.md`; you now write the
real one — the difference between an agent that helps and an agent you babysit.

## Instructor demo (5 min)
Show the stub, then derive one rule live from ARCHITECTURE.md: "level tuning
belongs in LevelData fields, not hardcoded in Board.cs — so the contract says
*data changes go through LevelData/scene values*."

## Your turn (10 min)
1. Prompt:
   > Using Workshop/ARCHITECTURE.md, rewrite CLAUDE.md as a real agent
   > contract for this repo: protected areas (Settings/, ProjectSettings/,
   > scene files by hand), where each kind of change belongs (gameplay logic /
   > level data / UI / boosters), the Match3 namespace conventions, and the
   > verification ritual (compile check via CLI, eval proof, play-mode test).
   > Keep the existing hard safety rules.
2. Read it critically: would YOU follow these rules? Cut anything vague.

## Verify
- New CLAUDE.md replaces the stub and names at least: protected paths, where
  boosters go, where level data lives, and how to verify a change.
- Start a FRESH agent session and ask "what are you not allowed to touch
  here?" — it should answer from your contract.

## If you get stuck
`git diff ex02-start..ex03-start` shows the canonical contract.
