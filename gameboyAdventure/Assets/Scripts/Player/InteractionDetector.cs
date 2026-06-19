using Unity.VisualScripting;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //Closest interactable
    private Pushable pushableInRange = null; //Closest pushable

    public void OnInteract()
    {
        if (interactableInRange != null)
        {
            interactableInRange.Interact();
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.UITick, 1);
        }
        else 
        { 
            //Debug.Log("Nothing to Interact"); 
        }

        if (pushableInRange != null)
        {
            Vector2 direction = 
                (pushableInRange.transform.position - gameObject.transform.position).normalized;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                direction = new Vector2(Mathf.Sign(direction.x), 0);
            }
            else
            {
                direction = new Vector2(0, Mathf.Sign(direction.y));
            }

            pushableInRange.TryPush(direction);
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.UITick, 1);
        }
        else 
        { 
            //Debug.Log("Nothing to Push"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable)  && interactable.CanInteract())
        {
            interactableInRange = interactable;
        }
        
        if (collision.TryGetComponent(out Pushable pushable))
        {
            pushableInRange = pushable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
        }

        if (collision.TryGetComponent(out Pushable pushable) && pushable == pushableInRange)
        {
            pushableInRange = null;
        }
    }
}
