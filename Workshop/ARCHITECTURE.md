# Gem Hunter Match — Architecture Recon

## Scene flow
`Init.unity` boots the game: `InitLoader` ensures a `GameManager` singleton
exists, then loads `Main.unity` (menu: level select, shop, lives). Picking a
level calls `LevelList.LoadLevel(n)` (`Assets/GemHunterMatch/Scripts/LevelList.cs`),
which in-editor loads the scene directly and in builds goes through Build
Settings — filled at build time by the `BuildLevelList` preprocessor in the
same file. Level scenes: `Scenes/Level1..3.unity`.

## The five classes that matter
- **`Board`** (`Scripts/Board.cs`, ~1,500 lines) — the heart. Owns the cell
  grid (`CellContent`), gem spawning, falling/bouncing movement, swap handling
  (`TickSwap`), match detection (`DoCheck`, flood-fill from a cell, then line
  extraction), and input (`CheckInput`).
- **`GameManager`** (`Scripts/GameManager.cs`) — persistent singleton: coins,
  stars, lives, volume/save data, bonus-item inventory, camera fit
  (`ComputeCamera`), level bootstrapping (`StartLevel`).
- **`LevelData`** (`Scripts/LevelData.cs`) — per-level rules: `MaxMove`,
  `Goals` (gem type + count), remaining-move bookkeeping (`Moved()`), goal
  bookkeeping (`Matched()`), win trigger. Exposes `OnGoalChanged`,
  `OnMoveHappened`, `OnAllGoalFinished`, `OnNoMoveLeft`.
- **`Gem`** (`Scripts/Gem.cs`) — anything living in a cell: `GemType` int,
  fall/bounce state machine, `Usable`/`Use()` extension point for boosters.
- **`UIHandler`** (`Scripts/UI/UIHandler.cs`) — level HUD (UI Toolkit): move
  counter, goal display, end screens, match fly-to-goal effects.

## Match detection
`Board.DoCheck(startCell)` — flood-fills same-`GemType` neighbours from the
cell, then extracts straight lines of ≥3 through the origin; a valid line
becomes a `Match` (`Scripts/Match.cs`) which `MatchTicking` animates and
resolves (goal credit via `LevelData.Matched`, deletion, refill). A successful
swap consumes a move via `LevelData.Instance.Moved()` in `Board.TickSwap` —
only in the matched branch; reverted swaps are free.

## Boosters (BonusGem)
`Scripts/BonusGem/BonusGem.cs` is the base: set `m_Usable = true` in `Awake`,
implement `Use(Gem swappedGem, bool isBonus)`; build a forced-deletion match
via `Board.CreateCustomMatch(cell)` and feed affected cells through
`HandleContent`. Examples: `SmallBomb` (plus-shape), `LineRocket`
(row or column), `LargeBomb`, `ColorClean`. Bonus gems spawn from bigger
matches (see `GameSettings`/`Match`) and can also be bought as `BonusItem`s.

## Level authoring
Levels are scenes. The board layout is painted with authoring tiles
(`Scripts/Authoring/GemPlacerTile.cs`, `GemSpawner.cs`, `ObstaclePlacer.cs`)
on a Tilemap; the `Board` reads them into `CellContent` at `Init`. Level rules
(moves, goals, background, music) sit on the `LevelData` component in the
scene; the gem mix is the scene `Board.ExistingGems` array.
