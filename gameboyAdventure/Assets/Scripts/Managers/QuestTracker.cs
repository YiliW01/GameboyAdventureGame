using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : Singleton<QuestTracker>
{
    [SerializeField] private PaperInteract paper;

    public bool blockPuzzleSolved;

    //Wand tracker
    public bool hasWand;

    public void ObtainWand()
    {
        hasWand = true;
    }

    public void GiveWand()
    {
        paper.SpawnPaper();
    }
}
