
using System.Collections.Generic;
using UnityEngine;
using SoundManager;


public class SoundGameManager :MonoBehaviour
{
    [SerializeField] private List<Sound> _soundMusic;
    [SerializeField] private List<Sound> _soundsSFX;
    [SerializeField] private AudioSource musicSound;
    [SerializeField] private AudioSource sfxSound;
    private void Start()
    {
        PlayMusicSound("BackGround");
        
    }

    public void PlayMusicSound(string namesound)
    {
        var soundplay = GetSound(_soundMusic, namesound);
        if(soundplay == null) return;
        musicSound.clip = soundplay.sound;
        musicSound.Play();
    }

    public void PlayMussicSFXsound(string namesound)
    {
        var soundplay = GetSound(_soundsSFX, namesound);
        if(soundplay == null) return;
        sfxSound.clip = soundplay.sound;
        sfxSound.Play();
    }

    public void TroggleMusic()
    {
        if (musicSound.isPlaying)
        {
            musicSound.Stop();
        }
        else
        {
            musicSound.Play();
        }
        
    }

    public void TroggleSFX()
    {
        if (sfxSound.isPlaying)
        {
            sfxSound.Stop();
        }
        else
        {
            sfxSound.Play();
        }
    }

    public void SetValueMusic(float volume)
    {
        musicSound.volume = volume;
    }
    public void SetValueSFX(float volume)
    {
        sfxSound.volume = volume;
    }
    private Sound GetSound(List<Sound> sounds, string namesound)
    {
        foreach (var sound in sounds)
        {
            if(!sound.namesound.Equals(namesound)) continue;
            return sound;
        }

        return null;
    }

    public void AddSoundSFX(string namesound, AudioClip sound)
    {
        _soundsSFX.Add(new Sound(namesound,sound));
    }
    public void AddSoundMusic(string namesound, AudioClip sound)
    {
        _soundMusic.Add(new Sound(namesound,sound));
    }

    
}
