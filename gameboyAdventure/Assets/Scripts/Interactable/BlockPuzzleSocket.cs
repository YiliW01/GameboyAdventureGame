using UnityEngine;

public class BlockPuzzleSocket : MonoBehaviour
{
    [SerializeField] private bool isCorrectPosition;
    public bool blockInPlace = false;
    [SerializeField] private BlockPuzzleManager blockPuzzleManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PushBlock"))
        {
            blockInPlace = true;
            Debug.Log("Block in place");

            blockPuzzleManager.CheckPuzzle();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PushBlock"))
        {
            blockInPlace = false;
        }
    }
}
