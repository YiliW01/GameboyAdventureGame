using UnityEngine;

public class LeverPuzzleManager : MonoBehaviour
{
    [SerializeField] private LeverScript[] _levers;
    [SerializeField] private DoorScript leverDoor;

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
            leverDoor.OpenDoor();
        }
    }
}
