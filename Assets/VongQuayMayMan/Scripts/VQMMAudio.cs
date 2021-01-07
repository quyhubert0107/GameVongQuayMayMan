using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VQMMAudio : MonoBehaviour
{
    public static VQMMAudio Instance;
    private AudioSource _audioSound;

    private void Awake()
    {
        Instance = this;
        _audioSound = transform.GetComponent<AudioSource>();
    }

    public void LoadAudioBg()
    {
        _audioSound.clip = LoadSound(PathAudioBG);
        _audioSound.loop = true;
        _audioSound.volume = 1;
        _audioSound.Play();
    }

    public void LoadAudioStartGame()
    {
        _audioSound.clip = LoadSound(PathStartGame);
        _audioSound.loop = false;
        _audioSound.volume = 0.8f;
        _audioSound.Play();
    }

    public void LoadAudioStop()
    {
        _audioSound.loop = false;
        _audioSound.volume = 0;
        _audioSound.Stop();
    }

    public static AudioClip LoadSound(string name)
    {
        return Resources.Load<AudioClip>(name);
    }

    private string PathAudioBG = "Audio/background";
    private string PathStartGame = "Audio/batdauvaogame";
    
}
