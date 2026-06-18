using TMPro;
using UnityEngine;

public class SignScript : MonoBehaviour, IInteractable
{
    private bool textActive = false;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (!textActive)
        {
            textActive = true;
        }
        else
        {
            textActive = false;
        }

        UIManager.Instance.dialoguePanel.SetActive(textActive);
        PauseManager.Instance.SetPause(textActive);
    }
}
