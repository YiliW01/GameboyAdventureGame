using Unity.VisualScripting;
using UnityEngine;

public class PauseManager: Singleton<PauseManager>
{
    public bool IsGamePaused { get; private set; }

    public void SetPause(bool pause)
    {
        IsGamePaused = pause;
    }
}
