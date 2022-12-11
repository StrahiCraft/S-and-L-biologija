using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] SoundEffect[] soundEffects;
    List<AudioSource> audioSourceList = new List<AudioSource>();

    private void Update()
    {
        DestroyInactiveAudioSources();
    }

    void DestroyInactiveAudioSources()
    {
        int currentAudioSourceIndex = 0;
        while(currentAudioSourceIndex < audioSourceList.Count)
        {
            if (!audioSourceList[currentAudioSourceIndex].isPlaying)
            {
                Destroy(audioSourceList[currentAudioSourceIndex]);
                audioSourceList.RemoveAt(currentAudioSourceIndex);
                return;
            }
            currentAudioSourceIndex++;
        }
    }

    public void Play(string soundEffectName)
    {
        AudioSource currentAudioSource = gameObject.AddComponent<AudioSource>();

        SoundEffect currentSoundEffect = soundEffects[GetSoundEffectIndex(soundEffectName)];
        SetUpCurrentAudioSource(ref currentAudioSource, currentSoundEffect);

        audioSourceList.Add(currentAudioSource);
        currentAudioSource.Play();
    }

    void SetUpCurrentAudioSource(ref AudioSource currentAudioSource, SoundEffect currentSoundEffect)
    {
        currentAudioSource.playOnAwake = false;
        currentAudioSource.clip = currentSoundEffect.clip;
        currentAudioSource.volume = currentSoundEffect.volume;
        currentAudioSource.pitch = currentSoundEffect.pitch;
        currentAudioSource.loop = currentSoundEffect.loop;
    }

    int GetSoundEffectIndex(string soundEffectName)
    {
        for(int currentSoundEffectIndex = 0; currentSoundEffectIndex < soundEffects.Length; currentSoundEffectIndex++)
        {
            if(soundEffectName == soundEffects[currentSoundEffectIndex].name)
            {
                return currentSoundEffectIndex;
            }
        }
        return 0;
    }

    [System.Serializable]
    public class SoundEffect
    {
        public string name;
        public AudioClip clip;
        [Range(0f,1f)]
        public float volume;
        [Range(-3f, 3f)]
        public float pitch;
        public bool loop;
    }
}
