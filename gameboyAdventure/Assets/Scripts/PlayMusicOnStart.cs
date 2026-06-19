using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] private AudioMgr.MusicType song;

    [Range(0f,1f)]
    [SerializeField] private float volume;

    private void Start()
    {
        AudioMgr.Instance.PlayMusic(song, volume);
        Destroy(gameObject);
    }
}
