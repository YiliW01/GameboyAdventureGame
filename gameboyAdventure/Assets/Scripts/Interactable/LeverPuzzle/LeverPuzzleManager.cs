using UnityEngine;

public class LeverPuzzleManager : MonoBehaviour
{
    [SerializeField] private LeverScript[] _levers;
    [SerializeField] private PaperInteract paper;

    public bool IsPuzzleSolved()
    {
        foreach (LeverScript lever in _levers)
        {
            if (!lever.isCorrect)
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
            Debug.Log("LEVER Puzzle Solved!");
            paper.SpawnPaper();
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.PuzzleSolve, 1f);
        }
    }
}
