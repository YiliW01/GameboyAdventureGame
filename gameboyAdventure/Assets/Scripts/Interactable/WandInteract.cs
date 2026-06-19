using UnityEngine;

public class WandInteract : MonoBehaviour, IInteractable
{
    private bool hasItem = false;
    [SerializeField] private GameObject itemSprite;
    [SerializeField] private NPCDialogue text;
    private bool textActive;

    public bool CanInteract()
    {
        if (hasItem) { return true; }
        return false;
    }

    public void Interact()
    {
        if (CanInteract())
        {
            if (!textActive)
            {
                textActive = true;
            }
            else
            {
                textActive = false;
                hasItem = false;
            }

            UIManager.Instance.dialogueText.SetText(text.dialogueLines[0]);
            UIManager.Instance.dialoguePanel.SetActive(textActive);
            PauseManager.Instance.SetPause(textActive);

            QuestTracker.Instance.ObtainWand();
            itemSprite.SetActive(false);
        }
    }

    public void SpawnWand()
    {
        hasItem = true;
        itemSprite.SetActive(true);
        AudioMgr.Instance.PlaySound(AudioMgr.SoundType.PuzzleSolve, 1f);
    }
}
