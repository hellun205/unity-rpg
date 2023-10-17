using System;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Object = UnityEngine.Object;

namespace Manager
{
  public class SoundManager : IClearable, IInitialable
  {
    private AudioSource[] audioSource = new AudioSource[(int)Define.Sound.MaxCount];
    
    private Dictionary<string, AudioClip> cache = new();

    public void Init()
    {
      var root = GameObject.Find("@Sound");
      if (root == null)
      {
        root = new GameObject("@Sound");
        Object.DontDestroyOnLoad(root);

        var soundNames = Enum.GetNames(typeof(Define.Sound));

        for (var i = 0; i < soundNames.Length - 1; i++)
        {
          var go = new GameObject(soundNames[i]);
          audioSource[i] = go.AddComponent<AudioSource>();
          go.transform.SetParent(root.transform);
        }

        audioSource[(int)Define.Sound.Bgm].loop = true;
      }
    }

    public void Clear()
    {
      cache.Clear();
    }

    public void Play(string path, Define.Sound type = Define.Sound.Sfx, float pitch = 1.0f)
    {
      path = path.Contains("Sounds/") ? path : $"Sounds/{path}";

      if (type == Define.Sound.Bgm || !cache.TryGetValue(path, out var clip))
      {
        clip = Managers.Resource.Load<AudioClip>(path);
        if (type != Define.Sound.Bgm) cache.Add(path, clip);
      }
      
      if (clip == null)
      {
        Debug.LogError($"AudioClip Missing! {path}");
        return;
      }
      
      Play(clip, type, pitch);
    }

    public void Play(AudioClip clip, Define.Sound type = Define.Sound.Sfx, float pitch = 1.0f)
    {
      var source = audioSource[(int)type];

      source.pitch = pitch;

      if (type == Define.Sound.Bgm)
      {
        if (source.isPlaying)
          source.Stop();
        source.clip = clip;
        source.Play();
      }
      else
      {
        source.PlayOneShot(clip);
      }
    }
  }
}