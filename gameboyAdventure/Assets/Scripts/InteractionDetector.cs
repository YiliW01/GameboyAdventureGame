using Unity.VisualScripting;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //Closest interactable

    public void OnInteract()
    {
        interactableInRange.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactableInRange = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactableInRange = null;
    }
}
