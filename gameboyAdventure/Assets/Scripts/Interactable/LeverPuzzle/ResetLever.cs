using System.Collections;
using UnityEngine;

public class ResetLever : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onSprite, offSprite;
    [SerializeField] private BlockPuzzleManager puzzleManager;
    private bool isFlicking;

    public bool CanInteract()
    {
        if (!isFlicking)
        {
            return true;
        }
        return false;
    }

    public void Interact()
    {
        if (CanInteract())
        {
            StartCoroutine(LeverFlick());
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.Lever, 1f);
        }
    }

    //hardcoded animation
    private IEnumerator LeverFlick()
    {
        isFlicking = true;
        spriteRenderer.sprite = offSprite;
        puzzleManager.ResetBlockPos();
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = onSprite;
        isFlicking=false;
    }
}
