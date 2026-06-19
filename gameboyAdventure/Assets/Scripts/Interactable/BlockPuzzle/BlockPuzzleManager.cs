using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

public class BlockPuzzleManager : MonoBehaviour
{
    [SerializeField] private BlockPuzzleSocket[] correctPositions;
    [SerializeField] private Pushable[] blocks;
    [SerializeField] private DoorScript blockDoor;
    [SerializeField] private List<Vector2> blocksStartPos;

    private void Start()
    {
        MakeStartPos();
    }

    private void MakeStartPos()
    {
        for (int i = 0; i < (blocks.Length); i++)
        {
            blocksStartPos.Add(blocks[i].gameObject.transform.position);
        }
    }

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
            QuestTracker.Instance.blockPuzzleSolved = true;
            if (blockDoor != null) { blockDoor.OpenDoor(); }
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.PuzzleSolve, 1f);
        }
    }

    public void ResetBlockPos()
    {
        for (int i = 0; i < (blocks.Length); i++)
        {
            blocks[i].transform.position = blocksStartPos[i];
        }
    }
}
