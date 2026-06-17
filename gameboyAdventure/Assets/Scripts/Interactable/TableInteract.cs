using UnityEngine;

public class TableInteract : MonoBehaviour, IInteractable
{
    private bool hasItem = true;
    [SerializeField] private GameObject wandSprite;

    public bool CanInteract()
    {
        if (hasItem) { return true; }
        return false;
    }

    public void Interact()
    {
        if(CanInteract())
        {
            hasItem = false;
            QuestTracker.Instance.ObtainWand();
            wandSprite.SetActive(false);
        }
    }
}
