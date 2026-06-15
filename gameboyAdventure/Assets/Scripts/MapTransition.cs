using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    [SerializeField] Direction direction;
    [SerializeField] Transform teleportTargetPosition;
    CinemachineConfiner2D confiner;

    enum Direction { Up, Down, Left, Right, Teleport }

    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPostion(collision.gameObject);
        }
    }

    private void UpdatePlayerPostion(GameObject player)
    {
        if (direction == Direction.Teleport)
        {
            player.transform.position = teleportTargetPosition.position;
        }

        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += 2;
                break;
            case Direction.Down:
                newPos.y -= 2;
                break;
            case Direction.Left:
                newPos.x += 2;
                break;
            case Direction.Right:
                newPos.x -= 2;
                break;
        }

        player.transform.position = newPos;
    }
}
