using UnityEngine;

public class TestSquareInteract : MonoBehaviour, IInteractable
{
    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        Debug.Log("Actor talks");
    }
}
