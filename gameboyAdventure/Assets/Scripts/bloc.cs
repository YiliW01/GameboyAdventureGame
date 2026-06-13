using UnityEngine;

public class bloc : MonoBehaviour, IInteractable
{
public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        Debug.Log("Sup nerd");
    }
}
