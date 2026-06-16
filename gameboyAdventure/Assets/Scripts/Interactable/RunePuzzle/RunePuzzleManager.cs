using UnityEngine;

public class RunePuzzleManager : MonoBehaviour
{
    [SerializeField] private Rune[] _runes;

    public bool IsPuzzleSolved()
    {
        foreach (Rune rune in _runes)
        {
            if (!rune.IsCorrect)
            {
                return false;
            }
        }

        return true;
    }

    public void CheckPuzzle()
    {
        if (IsPuzzleSolved())
        {
            Debug.Log("RUNE Puzzle Solved!");
            //do other stuff here
        }
    }
}
