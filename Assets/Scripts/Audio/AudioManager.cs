using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;
    public const int numMusicTracks = 9;
    public bool playBGM = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (playBGM)
        {
            StartCoroutine(PlayerOfBGM());
        }
    }

    public AudioSource Play(string name, float startTime = 0f)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }
        s.source.Play();
        s.source.time = startTime;
        return s.source;
    }

    private IEnumerator PlayerOfBGM()
    {
        AudioSource curBGM = Play(GetRandomBGM());

        while (playBGM)
        {
            if (!curBGM.isPlaying)
            {
                curBGM = Play(GetRandomBGM());
            }
            yield return null;
        }
    }

    private string GetRandomBGM()
    {
        int idx = UnityEngine.Random.Range(1, numMusicTracks + 1);
        Debug.Log("GotRandomBGM: BGM_" + idx);
        return "BGM_" + idx;
    }
}
