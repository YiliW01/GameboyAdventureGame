using UnityEngine;

public class Rune : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite[] _runeSprites;

    [Header("Answer Sprite Number:")]
    [SerializeField] private int _answerSpriteInt;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private RunePuzzleManager _puzzleManager;
    private int _currentSpriteIndex;
    public bool IsCorrect => _currentSpriteIndex == _answerSpriteInt;

    public bool CanInteract()
    {
        if(_puzzleManager.IsPuzzleSolved()) { return false; }
        return true;
    }

    public void Interact()
    {
        Debug.Log($"Current rune is: {IsCorrect}");
        RotateSprite();
    }

    private void RotateSprite()
    {
        _currentSpriteIndex++;

        if (_currentSpriteIndex >= _runeSprites.Length)
        {
            _currentSpriteIndex = 0;
        }

        _spriteRenderer.sprite = _runeSprites[_currentSpriteIndex];

        _puzzleManager.CheckPuzzle();
    }
}
