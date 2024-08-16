using System.Collections.Generic;
using UnityEngine;

namespace JGM.Engine
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField, Range(0, 1)]
        private float m_musicVolume = 0.3f;

        [SerializeField]
        private AudioClip[] m_audioClips;

        private readonly Dictionary<string, AudioClip> m_audioLibrary = new Dictionary<string, AudioClip>();
        private AudioSource m_musicAudioSource;
        private AudioSource m_sfxAudioSource;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetUpLibrary();
            SetUpMusicAudioSource();
            SetUpSfxAudioSource();
        }

        private void SetUpLibrary()
        {
            foreach (var clip in m_audioClips)
            {
                m_audioLibrary.Add(clip.name, clip);
            }
        }

        private void SetUpMusicAudioSource()
        {
            m_musicAudioSource = SetUpAudioSource("MusicAudioSource");
            m_musicAudioSource.loop = true;
            m_musicAudioSource.volume = m_musicVolume;
        }

        private void SetUpSfxAudioSource()
        {
            m_sfxAudioSource = SetUpAudioSource("SfxAudioSource");
        }

        private AudioSource SetUpAudioSource(string gameObjectName)
        {
            var audioSourceGameObject = new GameObject(gameObjectName, typeof(AudioSource));
            audioSourceGameObject.transform.SetParent(transform, false);
            var audioSource = audioSourceGameObject.GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
            return audioSource;
        }

        public void PlayMusic(string audioClipName)
        {
            PlaySound(audioClipName, m_musicAudioSource);
        }

        public void PlaySfx(string audioClipName)
        {
            PlaySound(audioClipName, m_sfxAudioSource);
        }

        private void PlaySound(string audioClipName, AudioSource audioSource)
        {
            if (m_audioLibrary.TryGetValue(audioClipName, out AudioClip audioClip))
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning($"{audioClipName} not found in audio library!");
            }
        }
    }
}
