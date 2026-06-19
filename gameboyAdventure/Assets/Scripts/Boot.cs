using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Boot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite instructionsSprite;
    [SerializeField] private Sprite mainMenuSprite;
    [SerializeField] private float instructionsDelay;
    [SerializeField] private string sceneToLoad;

    private bool isStarting;


    private void Start()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        isStarting = true;
        image.sprite = instructionsSprite;
        yield return new WaitForSeconds(instructionsDelay);
        image.sprite = mainMenuSprite;
        isStarting = false;
    }

    public void Input(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartGame();
            AudioMgr.Instance.PlaySound(AudioMgr.SoundType.UITick, 1f);
        }
    }

    public void StartGame()
    {
        if (!isStarting) { SceneLoader.Instance.LoadScene(sceneToLoad); }
    }
}
