using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Dialogue Box")]
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
}
