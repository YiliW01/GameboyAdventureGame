using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : Singleton<QuestTracker>
{
    [SerializeField] private DoorScript wizardDoor;

    public bool blockPuzzleSolved;

    //Wand tracker
    public bool hasWand;

    public void ObtainWand()
    {
        hasWand = true;
    }

    public void GiveWand()
    {
        wizardDoor.OpenDoor();
    }
}
