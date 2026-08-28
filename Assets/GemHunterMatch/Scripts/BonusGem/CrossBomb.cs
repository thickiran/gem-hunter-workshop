using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    /// <summary>
    /// Bonus gem that clears its entire row and column when used. (FEAT-88)
    /// </summary>
    public class CrossBomb : BonusGem
    {
        public AudioClip TriggerSound;

        public override void Awake()
        {
            m_Usable = true;
        }

        public override void Use(Gem swappedGem, bool isBonus = true)
        {
            //this allow to stop recursion on some bonus (like bomb trying to explode themselve again and again)
            //if isBonus is true, this is not a gem on the board so no risk of recursion we can ignore this
            if (!isBonus && m_Used)
                return;

            m_Used = true;

            var board = GameManager.Instance.Board;

            var newMatch = board.CreateCustomMatch(m_CurrentIndex);
            newMatch.ForcedDeletion = true;
            HandleContent(board.CellContent[m_CurrentIndex], newMatch);

            GameManager.Instance.PlaySFX(TriggerSound);

            //snapshot the keys first: HandleContent can chain into other bonus gems
            var targets = new List<Vector3Int>();
            foreach (var cell in board.CellContent.Keys)
            {
                if (cell == m_CurrentIndex)
                    continue;
                if (cell.x == m_CurrentIndex.x || cell.y == m_CurrentIndex.y)
                    targets.Add(cell);
            }

            foreach (var idx in targets)
            {
                if (board.CellContent.TryGetValue(idx, out var content) && content.ContainingGem != null)
                {
                    HandleContent(content, newMatch);
                }
            }
        }
    }
}
