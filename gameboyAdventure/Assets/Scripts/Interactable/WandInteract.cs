using UnityEngine;

public class WandInteract : MonoBehaviour, IInteractable
{
    private bool hasItem = false;
    [SerializeField] private GameObject itemSprite;

    public bool CanInteract()
    {
        if (hasItem) { return true; }
        return false;
    }

    public void Interact()
    {
        if (CanInteract())
        {
            hasItem = false;
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
