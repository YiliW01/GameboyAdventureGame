using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    //Set these using UIManager.Instance.variable
    //Then UIManager.Instance.panelVariable.SetActive(true);
    //Then SetActive(false) when done
    //Then use below to end dialogue
    //public void EndDialogue()
    //{
    //    isDialogueActive = false;
    //    dialogueText.SetText("");
    //    dialoguePanel.SetActive(false);
    //    PauseManager.Instance.SetPause(false);
    //}

    [Header("Dialogue Box")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    [Header("Popup")]
    public GameObject popUpPanel;
    public Image popUpImage;
}
