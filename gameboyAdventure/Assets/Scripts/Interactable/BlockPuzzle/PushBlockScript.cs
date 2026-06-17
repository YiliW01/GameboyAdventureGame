using UnityEngine;

public class PushBlockScript : MonoBehaviour, IInteractable
{
    [SerializeField] Rigidbody _rb;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
