using UnityEngine;
using static AudioMgr;

public class AudioMgr : Singleton<AudioMgr>
{
    public enum MusicType
    {
        Gameplay,
        Menus,
    }

    public enum SoundType
    {
        UITick,
        PuzzleSolve,
        Lever,
        Rune,
    }

    [SerializeField] private AudioClip[] _musicClips;
    [SerializeField] private AudioClip[] _soundClips;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    private AudioSource MusicPlayer => _musicSource;
    private AudioSource SoundPlayer => _soundSource;

    public void PlayMusic(MusicType music, float volumeMod)
    {
        var index = (int)music;
        if (_musicClips.Length < index)
        {
            Debug.LogWarning($"Music type {music.ToString()} not found in music clips");
            return;
        }

        StartMusicPlayer(_musicClips[(int)music], volumeMod);
    }

    private void StartMusicPlayer(AudioClip clip, float volumeMod)
    {
        if (volumeMod <= 0f) return;
        MusicPlayer.clip = clip;
        MusicPlayer.volume = volumeMod;
        MusicPlayer.loop = true;
        MusicPlayer.Play();
    }

    public void StopMusic()
    {
        MusicPlayer.Stop();
    }

    public void PlaySound(SoundType sound, float volumeMod = 1f)
    {
        var index = (int)sound;
        if (_soundClips.Length < index)
        {
            Debug.LogWarning($"Sound type {sound.ToString()} not found in sound clips");
            return;
        }

        PlaySound(_soundClips[(int)sound], volumeMod);
    }

    private void PlaySound(AudioClip clip, float volumeMod = 1f)
    {
        if (volumeMod <= 0f) return;
        if (clip != null) SoundPlayer.PlayOneShot(clip, volumeMod);
    }
}
