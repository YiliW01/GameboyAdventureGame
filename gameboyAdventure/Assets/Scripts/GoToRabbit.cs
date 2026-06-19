using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoToRabbit : MonoBehaviour, IInteractable
{
    [Header("Text Object:")]
    [SerializeField] private NPCDialogue dialogueData;

    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;

    private int dialogueLineIndex;
    private bool isDialogueActive;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

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
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueLineIndex = 0;

        dialoguePanel.SetActive(true);
        PauseManager.Instance.SetPause(true);

        dialogueText.SetText(dialogueData.dialogueLines[dialogueLineIndex]);

        TypeText();

    }

    void NextLine()
    {
        if (++dialogueLineIndex < dialogueData.dialogueLines.Length)
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
        dialogueText.SetText(dialogueData.dialogueLines[dialogueLineIndex]);
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseManager.Instance.SetPause(false);

        Destroy(gameObject);
    }
}
