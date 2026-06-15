using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    private int dialogueIndex;
    private bool isDialogueActive;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        if (dialogueData == null && !isDialogueActive) //NEEDS PAUSE
            return;

        if (isDialogueActive)
        {
            //NextLine
        }
        else
        {
            //StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.name);

        dialoguePanel.SetActive(true);
        //PauseController.SetPause(true);
    }
}
