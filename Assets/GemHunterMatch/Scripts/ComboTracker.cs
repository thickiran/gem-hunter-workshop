using UnityEngine;

namespace Match3
{
    /// <summary>
    /// Tracks consecutive moves that scored at least one goal gem.
    /// A move that resolves without any goal progress resets the streak.
    /// </summary>
    public class ComboTracker : MonoBehaviour
    {
        public int CurrentCombo { get; private set; }

        private bool m_ScoredThisWindow;

        void Start()
        {
            var levelData = LevelData.Instance;
            if (levelData == null)
                return;

            levelData.OnGoalChanged += OnGoalChanged;
            levelData.OnMoveHappened += OnMoveHappened;
        }

        void OnGoalChanged(int gemType, int newAmount)
        {
            if (m_ScoredThisWindow)
                return;

            m_ScoredThisWindow = true;
            CurrentCombo += 1;

            if (CurrentCombo >= 2)
                Debug.Log("Combo x" + CurrentCombo);
        }

        void OnMoveHappened(int moveRemaining)
        {
            //a new move starts a new scoring window; if the previous one scored
            //nothing, the streak is broken
            if (!m_ScoredThisWindow)
                CurrentCombo = 0;

            m_ScoredThisWindow = false;
        }
    }
}
