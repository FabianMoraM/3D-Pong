using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AUDIO_MANAGER : MonoBehaviour
{
    public Sound[] sounds;
    public static AUDIO_MANAGER instance;

    // Start is called before the first frame update
    void Awake()
    {
        // so it doesnt destroy the Audiomanagerwhen it restarts or changes scenes so sound doesnt get caught off
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
           // DontDestroyOnLoad(gameObject);

      foreach (Sound s in sounds)
      {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
      }  
    }
    void Start()
    {
        Play("Theme");
        
    }
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();

    }
}
