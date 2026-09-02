#!/bin/bash
# Workshop catch-up: sync to any exercise's start state with one command.
#   ./catchup.sh ex05        -> checkout ex05-start
#   ./catchup.sh complete    -> checkout the finished game
#   ./catchup.sh reskin      -> checkout the Track B result (reskinned game)
#   ./catchup.sh list        -> show all checkpoints
# Your uncommitted work is stashed (git stash list to recover it later).
set -e
cd "$(dirname "$0")"

if [ "$1" = "list" ] || [ -z "$1" ]; then
  echo "Checkpoints:"; git branch --list 'ex0*-start' complete reskin-complete | sed 's/^..//'
  [ -z "$1" ] && echo "Usage: ./catchup.sh <ex01..ex09|complete|reskin>"; exit 0
fi

TARGET="$1"
case "$TARGET" in
  ex0[1-9]) TARGET="${TARGET}-start" ;;
  reskin) TARGET="reskin-complete" ;;
  complete|reskin-complete|ex0[1-9]-start) ;;
  *) echo "Unknown checkpoint '$1' — try ./catchup.sh list"; exit 1 ;;
esac

if ! git diff --quiet || ! git diff --cached --quiet; then
  git stash push -u -m "catchup auto-stash $(date +%H:%M:%S)"
  echo "(your work was stashed — 'git stash list' to see it)"
fi

git checkout "$TARGET"
# Nudge the running editor to reload changed assets, if one is connected.
unity command --project-path . eval 'UnityEditor.AssetDatabase.Refresh(); return "refreshed";' --no-banner >/dev/null 2>&1 || true
echo ""
echo "You are now at $TARGET. In Unity, reopen the scene you are working in"
echo "(File > Open Recent) — the editor has already reloaded the changed files."
