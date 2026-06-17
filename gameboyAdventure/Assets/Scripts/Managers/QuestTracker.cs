using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : Singleton<QuestTracker>
{
    [Header("PuzzleManagers")]
    [SerializeField] private BlockPuzzleManager blockPuzzleManager;
    [SerializeField] private RunePuzzleManager runePuzzleManager;
    [SerializeField] private LeverPuzzleManager leverPuzzleManager;

    [SerializeField] private DoorScript wizardDoor;

    //Quest finished flag
    public bool questComplete;

    //Wand tracker
    public bool hasWand;

    private void Start()
    {
        hasWand = false;
        questComplete = false;
    }

    public void ObtainWand()
    {
        hasWand = true;
    }

    public void GiveWand()
    {
        hasWand = false;
        questComplete = true;
        wizardDoor.OpenDoor();
    }
}
