using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Rendering.MaterialUpgrader;

public class SceneSequence : MonoBehaviour
{
    [SerializeField] private NPCDialogue dialogueData;

    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;
    private TMP_Text nameText => UIManager.Instance.nameText;

    [SerializeField] private string nextScene;

    private int dialogueLineIndex;

    private void Start()
    {
        StartDialogue();
    }

    public void Input(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            NextLine();
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.UITick, 1f);
        }
    }

    void StartDialogue()
    {
        dialogueLineIndex = 0;

        nameText.SetText(dialogueData.npcName);

        dialoguePanel.SetActive(true);
        PauseManager.Instance.SetPause(true);

        dialogueText.SetText(dialogueData.dialogueLines[dialogueLineIndex]);

        TypeText();

    }

    public void NextLine()
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
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseManager.Instance.SetPause(false);
        SceneLoader.Instance.LoadScene(nextScene);
    }
}
