using Unity.VisualScripting;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //Closest interactable

    public void OnInteract()
    {
        if (interactableInRange != null)
        {
            interactableInRange.Interact();
        }
        else { Debug.Log("Nothing to Interact"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable)  && interactable.CanInteract())
        {
            interactableInRange = interactable;
        }
        //var interactable = collision.gameObject.GetComponent<IInteractable>();
        //if (interactable != null)
        //{
        //    interactableInRange = interactable;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
        }
        
    }
}
