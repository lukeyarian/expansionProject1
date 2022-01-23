using NaughtyAttributes;
using UnityEngine;

public class AudioSystem : SingletonMono<AudioSystem>
{
    public AudioClip Alarm;
    public AudioSource Source;

    [Button()]
    public void PlayAlarm()
    {
        Source.PlayOneShot(Alarm);
    }
}
