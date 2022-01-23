using System;
using NaughtyAttributes;
using UnityEngine;

public class AudioSystem : SingletonMono<AudioSystem>
{
    [Header("Sounds")]
    public AudioClip Alarm;
    public AudioClip GetItemSound;
    public AudioClip EatPlant;
    public AudioClip WipeWindow;

    private float volumeForClick = 0.078f;
    private float pitchForClick = 2.16f;
    
    [Header("Others")]
    public AudioSource Source;

    public void PlayClick()
    {
        Source.volume = volumeForClick;
        Source.pitch = pitchForClick;
        Source.PlayOneShot(GetItemSound);
    }

    private void SetDefaultPitchVolume()
    {
        Source.volume = 1;
        Source.pitch = 1;
    }

    public void PlayAlarm()
    {
        SetDefaultPitchVolume();
        Source.PlayOneShot(Alarm);
    }
    
    public void PlayWipeWindow()
    {
        SetDefaultPitchVolume();
        Source.PlayOneShot(WipeWindow);
    }
    
    [Button()]
    public void PlayItemGotten()
    {
        SetDefaultPitchVolume();
        Source.PlayOneShot(GetItemSound);
    }
    
    public void PlayEatPlant()
    {
        SetDefaultPitchVolume();
        Source.PlayOneShot(EatPlant);
    }
}
