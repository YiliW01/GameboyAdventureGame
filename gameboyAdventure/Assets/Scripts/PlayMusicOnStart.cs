using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    private void Start()
    {
        AudioMgr.Instance.PlayMusic(AudioMgr.MusicType.Gameplay, 1f);
        Destroy(gameObject);
    }
}
