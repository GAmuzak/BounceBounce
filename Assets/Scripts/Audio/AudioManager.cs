using UnityEngine;
using Utilities;

namespace Audio
{
public class AudioManager : BaseManager
{
    [SerializeField] private AudioClipDirectory audioClipDirectory;

    [Header("Audio Channels")]
    [SerializeField] private AudioSource musicSource = null;
    [SerializeField] private AudioSource sfxSource = null;
    [SerializeField] private AudioSource ambienceSource = null;
    [SerializeField] private AudioSource unusedSource = null;

    private void Awake()
    {
        // register all callbacks here
        DashDirection.EndPullAction += OnLaunch;
    }

    private void OnDisable()
    {
        // deregister all callbacks here
        DashDirection.EndPullAction -= OnLaunch;
    }

    private void PlayMusicClip(AudioTag tag)
    {
        if (musicSource.isPlaying) return;

        musicSource.clip = audioClipDirectory.FindClip(tag);
        musicSource.Play();
    }

    #region Callbacks

    private void OnLaunch(Vector2 launchDirection)
    {
        PlayMusicClip(AudioTag.TestingClip);
    }

    #endregion
}
}
