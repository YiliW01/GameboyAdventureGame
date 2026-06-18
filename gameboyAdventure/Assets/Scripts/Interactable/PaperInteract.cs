using UnityEngine;
using UnityEngine.UI;

public class PaperInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private bool hasItem;
    [SerializeField] private GameObject itemSprite;
    [SerializeField] private bool popupActive;
    [SerializeField] private Sprite imageToShow;

    public bool CanInteract()
    {
        if (hasItem) { return true; }
        return false;
    }

    public void Interact()
    {
        if (CanInteract())
        {
            if (!popupActive)
            {
                UIManager.Instance.popUpImage.sprite = imageToShow;
                popupActive = true;
            }
            else
            {
                popupActive = false;
            }

            UIManager.Instance.popUpPanel.SetActive(popupActive);
            PauseManager.Instance.SetPause(popupActive);
        }
    }

    //only for when paper is spawned
    public void SpawnPaper()
    {
        hasItem = true;
        itemSprite.SetActive(true);
        AudioMgr.Instance.PlaySound(AudioMgr.SoundType.PuzzleSolve, 1f);
    }
}
