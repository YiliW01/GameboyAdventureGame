using UnityEngine;
using static Unity.Collections.Unicode;

public class BlockPuzzleManager : MonoBehaviour
{
    [SerializeField] private BlockPuzzleSocket[] correctPositions;
    [SerializeField] private Pushable[] blocks;

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

            //Loop to turn off pushing of blocks
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].allowPush = false;
            }

            //do other stuff here
        }
    }
}
