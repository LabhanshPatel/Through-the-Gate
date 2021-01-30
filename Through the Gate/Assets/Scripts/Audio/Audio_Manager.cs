using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio_Manager : MonoBehaviour
{
    [SerializeField] Custom_sound_class[] sounds;

    AudioSource music_audio_source;

    [HideInInspector]public bool flag = true;
    void Awake()
    {
        if (FindObjectsOfType<Audio_Manager>().Length <= 1)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);

        foreach (Custom_sound_class s in sounds)
        {
            s.audio_source = gameObject.AddComponent<AudioSource>();
            s.audio_source.volume = s.volume;
            s.audio_source.pitch = s.pitch;
            s.audio_source.clip = s.clip;
        }


    }

    private void Start()
    {
        music_audio_source = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (flag == true)
        {
            if (Scene_Loader.scene_index == 0 && PlayerPrefs.HasKey("Show_Tutorial"))
            {
                StartCoroutine(Change_Music_Volume());
                flag = false;
            }
        }
    }
    public void Play(string name)
    {
        for(int i=0; i < sounds.Length; i++)
        {
            if(name == sounds[i].name)
            {          
                sounds[i].audio_source.PlayOneShot(sounds[i].audio_source.clip);           
                return;
            }
        }
    }

    public void Adjust_Audio(float vol, int pos)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (i == pos)
            {
                sounds[i].audio_source.volume = vol;
                return;
            }
        }

    }


    IEnumerator Change_Music_Volume()
    {
        music_audio_source.volume = 0f;
        music_audio_source.Play();

        float change_factor = 0.01f;

        while (change_factor <= 0.1f)
        {
            music_audio_source.volume = change_factor;
            change_factor += 0.003f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
