using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Dialogue Box")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    [Header("Popup")]
    public GameObject popUpPanel;
    public Image popUpImage;
}
