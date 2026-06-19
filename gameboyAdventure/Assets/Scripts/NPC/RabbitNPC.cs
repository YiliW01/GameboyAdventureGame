using TMPro;
using UnityEngine;

public class RabbitNPC : MonoBehaviour, IInteractable
{
    [Header("NPC Dialogue Object:")]
    [SerializeField] private NPCDialogue[] dialogueData;

    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;
    private TMP_Text nameText => UIManager.Instance.nameText;

    private int dialogueLineIndex;
    private bool isDialogueActive;
    private int currentDialogueDataIndex;

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
        if (QuestTracker.Instance.blockPuzzleSolved == true && currentDialogueDataIndex < (dialogueData.Length - 1)) { currentDialogueDataIndex++; }

        isDialogueActive = true;
        dialogueLineIndex = 0;

        nameText.SetText(dialogueData[currentDialogueDataIndex].npcName);

        dialoguePanel.SetActive(true);
        PauseManager.Instance.SetPause(true);

        dialogueText.SetText(dialogueData[currentDialogueDataIndex].dialogueLines[dialogueLineIndex]);

        TypeText();

    }

    void NextLine()
    {
        if (++dialogueLineIndex < dialogueData[currentDialogueDataIndex].dialogueLines.Length)
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
        dialogueText.SetText(dialogueData[currentDialogueDataIndex].dialogueLines[dialogueLineIndex]);
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseManager.Instance.SetPause(false);
    }
}
