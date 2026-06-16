using System.Collections;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("NPC Dialogue Object:")]
    [SerializeField] private NPCDialogue dialogueData;
    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;
    private TMP_Text nameText => UIManager.Instance.nameText;

    private int dialogueIndex;
    private bool isDialogueActive;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        if (dialogueData == null || PauseManager.Instance.IsGamePaused && !isDialogueActive)
            return;

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);

        dialoguePanel.SetActive(true);
        PauseManager.Instance.SetPause(true);

        dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);

        TypeText();
    }

    void NextLine()
    {
        if(++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            TypeText();
        }
        else
        {
            EndDialogue();
        }
    }

    void TypeText()
    {
        dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseManager.Instance.SetPause(false);
    }
}
