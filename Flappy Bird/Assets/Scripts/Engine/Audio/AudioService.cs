using System;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Engine
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField, Range(0, 1)]
        private float m_musicVolume = 0.3f;        
        
        [SerializeField, Range(1, 10)]
        private float m_simultaneousSfxs = 5;

        [SerializeField]
        private AudioClip[] m_audioClips;

        private readonly Dictionary<string, AudioClip> m_audioLibrary = new Dictionary<string, AudioClip>();
        private readonly List<AudioSource> m_sfxAudioSources = new List<AudioSource>();
        private AudioSource m_musicAudioSource;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetUpLibrary();
            SetUpMusicAudioSource();
            SetUpSfxAudioSources();
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

        private void SetUpSfxAudioSources()
        {
            for (int i = 0; i < m_simultaneousSfxs; i++)
            {
                m_sfxAudioSources.Add(SetUpAudioSource("SfxAudioSource"));
            }
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
            var availableSfxAudioSource = GetAvailableSfxAudioSource();
            PlaySound(audioClipName, availableSfxAudioSource);
        }

        private AudioSource GetAvailableSfxAudioSource()
        {
            foreach (var audioSource in m_sfxAudioSources)
            {
                if (!audioSource.isPlaying)
                {
                    return audioSource;
                }
            }

            return null;
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
