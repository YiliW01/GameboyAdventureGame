using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SceneSequence : MonoBehaviour
{
    [SerializeField] private NPCDialogue dialogueData;
    [SerializeField] private NPCDialogue dialogueData2;

    private GameObject dialoguePanel => UIManager.Instance.dialoguePanel;
    private TMP_Text dialogueText => UIManager.Instance.dialogueText;

    [SerializeField] private string nextScene;

    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private Sprite rabbit, princess;

    private int dialogueLineIndex;

    private bool cutscenePlayed;
    private bool isCutscenePlaying;

    private void Start()
    {
        StartDialogue();
        bg.sprite = rabbit;
        cutscenePlayed = false;
    }

    public void Input(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isCutscenePlaying) { return; }
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.UITick, 1f);
            NextLine();
        }
    }

    void StartDialogue()
    {
        dialogueLineIndex = 0;

        dialoguePanel.SetActive(true);
        PauseManager.Instance.SetPause(true);

        TypeText();

    }

    public void NextLine()
    {
        if (cutscenePlayed)
        {
            if (++dialogueLineIndex < dialogueData2.dialogueLines.Length)
            {
                TypeText();
            }
            else
            {
                EndDialogue();
            }
        }
        else
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
    }

    void TypeText()
    {
        if (cutscenePlayed) { dialogueText.SetText(dialogueData2.dialogueLines[dialogueLineIndex]); }
        else { dialogueText.SetText(dialogueData.dialogueLines[dialogueLineIndex]); }
    }

    public void EndDialogue()
    {
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseManager.Instance.SetPause(false);

        if (cutscenePlayed)
        {
            SceneLoader.Instance.LoadScene(nextScene);
        }
        else
        {
            StartCoroutine(Cutscene());
        }
    }

    private IEnumerator Cutscene()
    {
        isCutscenePlaying = true;
        yield return new WaitForSeconds(1f);
        bg.sprite = princess;
        cutscenePlayed = true;
        isCutscenePlaying = false;
        StartDialogue();
    }
}
