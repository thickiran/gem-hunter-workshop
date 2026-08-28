using System.Text;
using Unity.Pipeline.Commands;
using UnityEngine;

namespace Match3.EditorTools
{
    /// <summary>
    /// CLI-facing validator for the open level scene. (Exercise 07 reference)
    /// Run with:  unity command --project-path . level_lint
    /// </summary>
    public static class LevelLint
    {
        [CliCommand("level_lint", "Validate the open Gem Hunter level scene", Tags = new[] { "workshop" })]
        public static string Lint()
        {
            var sb = new StringBuilder();
            int failures = 0;

            var levelData = Object.FindFirstObjectByType<LevelData>();
            Check(sb, ref failures, levelData != null, "LevelData present in the open scene");
            if (levelData == null)
                return Verdict(failures, sb);

            Check(sb, ref failures, levelData.MaxMove > 0,
                "MaxMove > 0 (found " + levelData.MaxMove + ")");

            var board = Object.FindFirstObjectByType<Board>();
            Check(sb, ref failures, board != null, "Board present in the open scene");

            Check(sb, ref failures, levelData.Goals != null && levelData.Goals.Length > 0,
                "at least one goal defined");

            if (levelData.Goals != null)
            {
                foreach (var goal in levelData.Goals)
                {
                    if (goal.Gem == null)
                    {
                        Check(sb, ref failures, false, "goal has a Gem assigned");
                        continue;
                    }

                    Check(sb, ref failures, goal.Count > 0,
                        "goal '" + goal.Gem.name + "' Count > 0 (found " + goal.Count + ")");

                    if (board != null && board.ExistingGems != null)
                    {
                        bool inMix = false;
                        foreach (var gem in board.ExistingGems)
                        {
                            if (gem != null && gem.GemType == goal.Gem.GemType) { inMix = true; break; }
                        }
                        Check(sb, ref failures, inMix,
                            "goal gem '" + goal.Gem.name + "' (type " + goal.Gem.GemType + ") exists in Board.ExistingGems");
                    }
                }
            }

            if (Application.isPlaying && board != null)
                Check(sb, ref failures, board.SpawnerPosition.Count > 0, "board has at least one spawner");

            return Verdict(failures, sb);
        }

        static string Verdict(int failures, StringBuilder sb) =>
            (failures == 0 ? "PASS — level is valid" : "FAIL — " + failures + " check(s) failed") + "\n" + sb;

        static void Check(StringBuilder sb, ref int failures, bool ok, string what)
        {
            sb.AppendLine((ok ? "  [ok]   " : "  [FAIL] ") + what);
            if (!ok) failures++;
        }
    }
}
