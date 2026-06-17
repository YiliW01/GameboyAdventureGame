using System.Collections;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("NPC Dialogue Object:")]
    [SerializeField] private NPCDialogue[] dialogueData;

    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;
    private TMP_Text nameText => UIManager.Instance.nameText;

    private int dialogueLineIndex;
    private bool isDialogueActive;
    private int currentDialogueDataIndex;
    [SerializeField] private bool isWizard;

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
            if (isWizard && QuestTracker.Instance.hasWand == true) { QuestTracker.Instance.GiveWand(); }
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        if (QuestTracker.Instance.questComplete == true && currentDialogueDataIndex < dialogueData.Length) { currentDialogueDataIndex++; }

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
        if(++dialogueLineIndex < dialogueData[currentDialogueDataIndex].dialogueLines.Length)
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
