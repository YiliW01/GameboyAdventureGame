using UnityEngine;

public class LeverScript : MonoBehaviour, IInteractable
{
    public enum LeverState
    {
        On,
        Off
    }

    [SerializeField] private LeverPuzzleManager leverManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onSprite, offSprite;

    private LeverState currentState;
    [SerializeField] private LeverState answerState;
    public bool isCorrect => currentState == answerState;

    public bool CanInteract()
    {
        if (!leverManager.IsPuzzleSolved())
        { 
            return true; 
        }

        return false;
    }

    public void Interact()
    {
        SwitchState();
    }

    private void SwitchState()
    {
        switch (currentState)
        {
            case LeverState.On:
                currentState = LeverState.Off;
                spriteRenderer.sprite = offSprite;
                Debug.Log($"{currentState}");
                break;
            case LeverState.Off:
                currentState = LeverState.On;
                spriteRenderer.sprite = onSprite;
                Debug.Log($"{currentState}");
                break;
        }

        leverManager.CheckPuzzle();  
    }
}
