using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1f)]
    public float valume = .5f;
    [Range(0.5f, 1.5f)]
    public float pitch = .7f;
    private AudioSource source;
    [Range(0, 0.5f)]
    public float randomValume = 0.1f;
    [Range(0, 0.5f)]
    public float randomPitch = 0.1f;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }
    public void Play()
    {
        source.volume = valume * (1 + Random.Range(-randomValume / 2f, randomValume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField] Sound[] sounds;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {

        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _gm = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _gm.transform.SetParent(this.transform);
            sounds[i].SetSource(_gm.AddComponent<AudioSource>());
        }

    }
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not list - " + _name);
    }
}

