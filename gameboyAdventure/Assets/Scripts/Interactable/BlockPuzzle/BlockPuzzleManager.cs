using UnityEngine;
using static Unity.Collections.Unicode;

public class BlockPuzzleManager : MonoBehaviour
{
    [SerializeField] private BlockPuzzleSocket[] correctPositions;
    [SerializeField] private Pushable[] blocks;
    [SerializeField] private DoorScript blockDoor;

    public bool IsPuzzleSolved()
    {
        foreach (BlockPuzzleSocket socket in correctPositions)
        {
            if (!socket.blockInPlace)
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
            Debug.Log("BLOCK Puzzle Solved!");
            blockDoor.OpenDoor();
        }
    }
}
