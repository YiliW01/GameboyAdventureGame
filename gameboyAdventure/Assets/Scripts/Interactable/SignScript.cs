using TMPro;
using UnityEngine;

public class SignScript : MonoBehaviour, IInteractable
{
    private bool textActive = false;
    [SerializeField] private NPCDialogue text;

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

        UIManager.Instance.dialogueText.SetText(text.dialogueLines[0]);
        UIManager.Instance.dialoguePanel.SetActive(textActive);
        PauseManager.Instance.SetPause(textActive);
    }
}
