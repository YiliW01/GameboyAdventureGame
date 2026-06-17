using System.Collections;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    [SerializeField] private float _pushSpeed;
    private bool isMoving = false;
    [SerializeField] private LayerMask obstaclesLayer;
    [SerializeField] private float pushDistance = 2;
    [SerializeField] private BlockPuzzleManager blockPuzzleManager;

    private bool CanPush()
    {
        if (blockPuzzleManager.IsPuzzleSolved() || isMoving == true) { return false; }
        return true;
    }

    public void TryPush(Vector2 direction)
    {
        if (!CanPush()) { return; }
        //Debug.Log("1");
        Vector3 targetPos = transform.position + (new Vector3(direction.x, direction.y, 0f) * pushDistance);

        if (IsTileBlocked(targetPos)) { return; }
        //Debug.Log("2");
        StartCoroutine(Move(targetPos, _pushSpeed));
        //Debug.Log("3");
    }

    private bool IsTileBlocked(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, obstaclesLayer) != null;
    }

    private IEnumerator Move(Vector3 targetPos, float speed)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPos) > 0.001f)
        { 
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime); 
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
    
}
