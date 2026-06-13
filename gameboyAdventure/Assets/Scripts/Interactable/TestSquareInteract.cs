using UnityEngine;

public class TestSquareInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        _spriteIndex++;

        if (_spriteIndex >= _sprites.Length) 
        { 
            _spriteIndex = 0; 
        }

        _spriteRenderer.sprite = _sprites[_spriteIndex];
    }
}
