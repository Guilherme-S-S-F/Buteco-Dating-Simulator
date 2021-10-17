using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class AudioSystem :MonoBehaviour
{
    #region Properties
    [HideInInspector]
    public static AudioSystem instance;
    [Header("AudioChannels")]
    public AudioSource[] Musicsource;
    public AudioSource[] Soundsource;
        

    [Header("PlayLists")]
    public AudioClip[] MenuMusic;
    public List<Music> MusicList = new List<Music>();
    public List<Sound> SoundList = new List<Sound>();

    #endregion Properties
    private void Start()
    {
        instance = this;
    }
    //Play all the musics on menu playlist
    public void PlayPlaylist()
    {
        if(!Musicsource[0].isPlaying)
        {
            instance.PlaylistGetRandom();
            Musicsource[0].Play();
        }  
    }
    public AudioClip PlaylistGetRandom()
    {
        return Musicsource[0].clip = MenuMusic[UnityEngine.Random.Range(0, MenuMusic.Length)];        
    }
    //Play and Stop methods of the Musics of the game
    public void PlayMusic(int Channel,string name)
    {
        foreach(Music c in MusicList)
        {
            if(c.Name == name)
            {
                Musicsource[Channel].clip = c.Clip;
                Musicsource[Channel].Play();
            }
        }
    }

    public void StopMusic(int Channel)
    {
       Musicsource[Channel].Stop();
    }

    public void PauseMusic(int Channel)
    {
        //Pause the channel
        Musicsource[Channel].Pause();
    }

    //Play and Stop methods of the Sonds of the game
    public void PlaySound(int Channel, string name)
    {
        foreach(Sound c in SoundList)
        {
            if (c.Name == name)
            { Soundsource[Channel].clip = c.Clip; Soundsource[Channel].Play(); }
        }
    }

    public void StopSound(int Channel)
    {
       Soundsource[Channel].Stop();
    }

    public void PauseSound(int Channel)
    {
        Soundsource[Channel].Pause();
    }

    #region Class
    [Serializable]
    public class Music
    {
        public String Name;
        public AudioClip Clip;
    }
    [Serializable]
    public class Sound
    {
         public String Name;
         public AudioClip Clip;
    }
    #endregion
}
