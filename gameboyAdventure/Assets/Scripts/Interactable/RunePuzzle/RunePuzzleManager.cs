using UnityEngine;

public class RunePuzzleManager : MonoBehaviour
{
    [SerializeField] private Rune[] _runes;
    [SerializeField] private DoorScript runeDoor;
    [SerializeField] private WandInteract wand;

    public bool IsPuzzleSolved()
    {
        foreach (Rune rune in _runes)
        {
            if (!rune.IsCorrect)
            {
                return false;
            }
        }
        Debug.Log("1");
        return true;
    }

    public void CheckPuzzle()
    {
        if (IsPuzzleSolved())
        {
            Debug.Log("RUNE Puzzle Solved!");

            //rune door logic
            //if (runeDoor != null) { runeDoor.OpenDoor(); }

            //wand spawn logic
            wand.SpawnWand();
        }
    }
}
